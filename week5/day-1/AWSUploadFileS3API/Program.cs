using Scalar.AspNetCore;
using Amazon;
using Amazon.Extensions.NETCore.Setup;
using Amazon.S3;
using AWSUploadFileS3API.Endpoints;
using AWSUploadFileS3API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAwsS3Service, AwsS3Service>();


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());
builder.Services.AddAWSService<IAmazonS3>();
    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapAwsS3FileEndpoints();

app.UseHttpsRedirection();
app.Run();

