using System.Net;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;

namespace AWSUploadFileS3API.Services;

public class AwsS3Service(
    IAmazonS3 s3Client,
    ILogger<AwsS3Service> logger) : IAwsS3Service
{
    public async Task<HttpStatusCode> UploadFileAsync(IFormFile file, string bucketName)
    {
        var bucketExists = await AmazonS3Util.DoesS3BucketExistV2Async(s3Client, bucketName);
        if (!bucketExists)
        {
            // Create bucket if not exists
            var bucketRequest = new PutBucketRequest
            {
                BucketName = bucketName,
                UseClientRegion = true
            };
            // create bukcket
            await s3Client.PutBucketAsync(bucketRequest);
        }
        
        // create object request
        var objectRequest = new PutObjectRequest
        {
            BucketName = bucketName,
            Key = file.FileName,
            InputStream = file.OpenReadStream(),
            StorageClass = S3StorageClass.Standard
        };
        
        var response = await s3Client.PutObjectAsync(objectRequest);
        return response.HttpStatusCode;
    }

    public async Task<HttpStatusCode> DeleteFileAsync(string bucketName, string fileName)
    {
        var response = await s3Client.DeleteObjectAsync(bucketName, fileName);        
        return response.HttpStatusCode;
    }

    public async Task<HttpStatusCode> DeleteBucketAsync(string bucketName, bool isForceDelete)
    {
        var bucketExists = await AmazonS3Util.DoesS3BucketExistV2Async(s3Client, bucketName);
        if (!bucketExists)
        {
            logger.LogWarning("Bucket '{bucketName}' does not exist", bucketName);
            return HttpStatusCode.NotFound;
        }

        if (isForceDelete)
        {
            var files = await this.ListBucketFileNames(bucketName);
            if (files.Any())
            {
                foreach( var file in files)
                {
                    await this.DeleteFileAsync(bucketName, file);
                }
            }
        }        

        var response = await s3Client.DeleteBucketAsync(bucketName);        
        return response.HttpStatusCode;
    }

    public async Task<IEnumerable<string>> ListBucketsFilesUriAsync(string bucketName)
    {
        var response = await s3Client.ListObjectsV2Async(new ListObjectsV2Request() 
        {
            BucketName = bucketName, 
            Prefix = ""
        });

        // vi lager url av responsen (filene)
        IEnumerable<string>? preSignedUrls = response.S3Objects.Select(o =>
        {
            // ny spørring mot aws: GetPreSignedUrlRequest
            var req = new GetPreSignedUrlRequest
            {
                BucketName = bucketName,
                Key = o.Key,
                Expires = DateTime.UtcNow.AddSeconds(60)
            };

            // get presigned url og legger svaret i variabel 'preSignedUrls'
            return s3Client.GetPreSignedURL(req);
        });

        return preSignedUrls;
    }
    
    private async Task<IEnumerable<string>> ListBucketFileNames(string bucketName)
    {
        var request = new ListObjectsV2Request
        {
            BucketName = bucketName,
            Prefix = ""
        };

        var response = await s3Client.ListObjectsV2Async(request);

        // vi lager url av responsen (filene)
        IEnumerable<string>? fileNames = response.S3Objects.Select(o => o.Key);
        return fileNames;
        
    }
    
    public async Task<IEnumerable<string>> ListBucketFilesUriAsync(string bucketName)
    {
        var response = await s3Client.ListObjectsV2Async(new ListObjectsV2Request() 
        {
            BucketName = bucketName, 
            Prefix = ""
        });

        // vi lager url av responsen (filene)
        IEnumerable<string>? preSignedUrls = response.S3Objects.Select(o =>
        {
            // ny spørring mot aws: GetPreSignedUrlRequest
            var req = new GetPreSignedUrlRequest
            {
                BucketName = bucketName,
                Key = o.Key,
                Expires = DateTime.UtcNow.AddSeconds(60)
            };

            // get presigned url og legger svaret i variabel 'preSignedUrls'
            return s3Client.GetPreSignedURL(req);
        });

        return preSignedUrls;
    }
}