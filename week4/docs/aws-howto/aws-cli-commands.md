# AWS CLI Commands

```bash
# create cluster
aws ecs create-cluster --cluster-name studentblogg-cluster

# registrate task definition
aws ecs register-task-definition --cli-input-json file://studentblogg-api-task.json
aws ecs register-task-definition --cli-input-json file://studentblogg-db-task.json

# create service
aws ecs create-service --cluster studentblogg-cluster --service-name studentblogg-api --task-definition studentblogg-api --desired-count 1 --launch-type FARGATE --network-configuration "awsvpcConfiguration={subnets=[subnet-0abc1234,subnet-0def5678],securityGroups=[sg-0ghijkl9],assignPublicIp=ENABLED}"

aws ecs create-service --cluster studentblogg-cluster --service-name studentblogg-db --task-definition studentblogg-db --desired-count 1 --launch-type FARGATE --network-configuration "awsvpcConfiguration={subnets=[subnet-0abc1234,subnet-0def5678],securityGroups=[sg-0mnopqr1],assignPublicIp=ENABLED}"
    


```