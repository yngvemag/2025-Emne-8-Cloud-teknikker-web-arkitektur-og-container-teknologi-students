using System.Net;
using Amazon.S3.Model;

namespace AWSUploadFileS3API.Services;

public interface IAwsS3Service
{
    Task<HttpStatusCode> UploadFileAsync(IFormFile file, string bucketName);
    Task<HttpStatusCode> DeleteFileAsync(string bucketName, string fileName);
    Task<HttpStatusCode> DeleteBucketAsync(string bucketName, bool isForceDelete);
    Task<IEnumerable<string>> ListBucketsFilesUriAsync(string bucketName);
}