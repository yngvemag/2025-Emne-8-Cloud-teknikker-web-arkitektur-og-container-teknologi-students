using System.Net;
using Amazon.Lambda.Core;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;

namespace AwsS3ImportFileLambda;

internal static class AwsS3BucketHandler
{
    public static async Task<bool> CreateBucketIfNotExistAsync(
        ILambdaContext context,
        IAmazonS3 s3Client,
        string bucketName)
    {
        var bucketExist = await AmazonS3Util.DoesS3BucketExistV2Async(s3Client, bucketName);
        if (!bucketExist)
        {
            context.Logger.LogInformation("Bucket does not exist, creating bucket '{bucketName}'", bucketName);
            var createBucketRequest = new PutBucketRequest()
            {
                BucketName = bucketName,
                UseClientRegion = true
            };
            await s3Client.PutBucketAsync(createBucketRequest);
            return true;
        }
        return false;
    }
    
    public static async Task<bool> CopyS3FileAsync(
        ILambdaContext context,
        IAmazonS3 s3Client,
        string sourceBucketName,
        string sourceKey,
        string destinationBucketName,
        string destinationKey)
    {
        var response = await s3Client.CopyObjectAsync(
            new CopyObjectRequest()
            {
                SourceBucket = sourceBucketName,
                SourceKey = sourceKey,
                DestinationBucket = destinationBucketName,
                DestinationKey = destinationKey
            });

        if (response.HttpStatusCode == HttpStatusCode.OK)
        {
            context.Logger.LogInformation(
                "Copied file '{sourceKey}' from bucket '{sourceBucketName}' " + 
                "to bucket '{destinationBucketName}'",sourceKey, sourceBucketName, destinationBucketName);
            return true;
        }

        return false;
    }

    public static async Task<bool> DeleteS3FileAsync(
        ILambdaContext context, 
        IAmazonS3 s3Client, 
        string bucketName, 
        string fileName)
    {
        var response = await s3Client.DeleteObjectAsync(
            new DeleteObjectRequest()
            {
                BucketName = bucketName,
                Key = fileName
            });
        
        if (response.HttpStatusCode == HttpStatusCode.OK)
        {
            context.Logger.LogInformation("Deleted file '{fileName}' from bucket '{bucketName}'", fileName, bucketName);
            return true;
        }

        return false;
                
    }
}