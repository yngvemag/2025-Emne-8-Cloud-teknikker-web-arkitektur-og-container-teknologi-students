using AWSUploadFileS3API.Services;
using Microsoft.AspNetCore.Mvc;

namespace AWSUploadFileS3API.Endpoints;

public static class AwsS3FileEndpoints
{
    public static void MapAwsS3FileEndpoints(this WebApplication app)
    {
        var awsGroup = app.MapGroup("/aws-s3");

        awsGroup.MapPost("/upload", UploadFileAsync).WithName("UploadFileAsync").DisableAntiforgery();
        
        awsGroup.MapGet("/listbucket", ListBucketContentAsync)
            .WithName("ListBucketContent");
            
        
        awsGroup.MapDelete("/deletefile", DeleteFileAsync)
            .WithName("DeleteFile");
            

        awsGroup.MapDelete("/deletebucket", DeleteBucketAsync)
            .WithName("DeleteBucket"); 
        
    }

    private static async Task<IResult> UploadFileAsync(
        IAwsS3Service awsS3Service,
        IFormFile file,
        string bucketName)
    {
        var httpStatusCode = await awsS3Service.UploadFileAsync(file, bucketName);
        return Results.StatusCode((int)httpStatusCode);
    }
    
    private static async Task<IResult> DeleteBucketAsync(
        IAwsS3Service awsS3Service,
        [FromQuery] string bucketName,
        [FromQuery] bool isForceDelete=false)
    {
        var response = await awsS3Service.DeleteBucketAsync(bucketName, isForceDelete);
        return Results.Ok(response);
    }

    private static async Task<IResult> DeleteFileAsync(
        IAwsS3Service awsS3Service,
        string bucketName, string fileName)
    {
        var response = await awsS3Service.DeleteFileAsync(bucketName, fileName);
        return Results.Ok(response);
    }

    private static async Task<IResult> ListBucketContentAsync(
        IAwsS3Service awsS3Service,
        string bucketName)
    {
        var result = await awsS3Service.ListBucketsFilesUriAsync(bucketName);
        return Results.Ok(result);
        
    }
}