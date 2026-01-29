# Upload image to repository

```bash

# 1. Create repository (if not exists)
aws ecr create-repository --repository-name ga-studblogg-api

# 2. get authentication token and authorizeDocker-client
aws ecr get-login-password --region eu-north-1 | docker login --username AWS --password-stdin 359512443914.dkr.ecr.eu-north-1.amazonaws.com

# 3. Build image if not exist
docker build -t <image name>

# 4. tag image to aws-repository
docker tag student-blogg-api:latest 359512443914.dkr.ecr.eu-north-1.amazonaws.com/student-blogg-api:latest

# 5. Push image to aws
docker push 359512443914.dkr.ecr.eu-north-1.amazonaws.com/student-blogg-api:latest

```