# ECR - Setup, Create and Delete Repository

## CLR

```bash
# create repository 
aws ecr create-repository --repository-name student-blogg-api

# response
{
    "repository": {
        "repositoryArn": "arn:aws:ecr:eu-north-1:127214158791:repository/student-blogg-api",
        "registryId": "127214158791",
        "repositoryName": "student-blogg-api",
        "repositoryUri": "127214158791.dkr.ecr.eu-north-1.amazonaws.com/student-blogg-api",
        "createdAt": "2025-01-17T12:30:53.770000+01:00",
        "imageTagMutability": "MUTABLE",
        "imageScanningConfiguration": {
            "scanOnPush": false
        },
        "encryptionConfiguration": {
            "encryptionType": "AES256"
        }
    }
}
```
![1737113537320](image/9-ecr-create-repo/1737113537320.png)

<br><br><br><br><br><br><br><br><br>

```bash

# delete repository
aws ecr delete-repository --repository-name student-blogg-api --force

# response
{
    "repository": {
        "repositoryArn": "arn:aws:ecr:eu-north-1:127214158791:repository/student-blogg-api",
        "registryId": "127214158791",
        "repositoryName": "student-blogg-api",
        "repositoryUri": "127214158791.dkr.ecr.eu-north-1.amazonaws.com/student-blogg-api",
        "createdAt": "2025-01-17T12:30:53.770000+01:00",
        "imageTagMutability": "MUTABLE"
    }
}
```

![1737113836203](image/9-ecr-create-repo/1737113836203.png)

---
<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>

## WEB

### Create Repository

![1737113554178](image/9-ecr-create-repo/1737113554178.png)
![1737113603250](image/9-ecr-create-repo/1737113603250.png)
![1737113617606](image/9-ecr-create-repo/1737113617606.png)

### Delete Repository

![1737113937298](image/9-ecr-create-repo/1737113937298.png)
![1737113948518](image/9-ecr-create-repo/1737113948518.png)
![1737113959308](image/9-ecr-create-repo/1737113959308.png)