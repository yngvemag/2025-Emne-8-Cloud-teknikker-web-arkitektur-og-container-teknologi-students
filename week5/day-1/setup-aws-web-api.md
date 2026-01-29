```bash

dotnet new webapi -n AWSUploadFileS3API

cd .\AWSUploadFileS3API\
dotnet new sln -n aws
dotnet sln migrate
rm aws.sln

dotnet sln add .\AWSUploadFileS3API.csproj

dotnet add package Scalar.AspNetCore
dotnet package search AWSSDK
dotnet add package AWSSDK.S3
dotnet package search AWSSDK
dotnet add package AWSSDK.Extensions.NetCore.Setup
```