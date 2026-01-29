
# Docker ECR Setup

## Build docker images locally

```bash
# if via docker-compose
docker-compose build

# if docker
docker build -t <tagname> .
```

## Login Docker-AWS

```bash
aws ecr get-login-password --region eu-north-1 | docker login --username AWS --password-stdin 127214158791.dkr.ecr.eu-north-1.amazonaws.com
```

## Tag images to AWS containers

```bash
docker tag 3-composecomplete-db:latest 127214158791.dkr.ecr.eu-north-1.amazonaws.com/studentblogg-db 

docker tag 3-composecomplete-api:latest 127214158791.dkr.ecr.eu-north-1.amazonaws.com/studentblogg-api

docker tag 3-composecomplete-web:latest 127214158791.dkr.ecr.eu-north-1.amazonaws.com/studentblogg-web
```

## Create Repository

```bash
aws ecr create-repository --repository-name studentblogg-api

aws ecr create-repository --repository-name studentblogg-db

aws ecr create-repository --repository-name studentblogg-web
```   

## Push containers to Repo
   
```bash
docker push 127214158791.dkr.ecr.eu-north-1.amazonaws.com/studentblogg-api

docker push 127214158791.dkr.ecr.eu-north-1.amazonaws.com/studentblogg-db

docker push 127214158791.dkr.ecr.eu-north-1.amazonaws.com/studentblogg-web
```
