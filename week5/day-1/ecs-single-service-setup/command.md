# Command
o
```bash

aws ecs create-cluster --cluster-name studentblogg-cluster

aws ecs register-task-definition --cli-input-json file://studentblogg-task.json

aws ecs create-service --cli-input-json file://create-service.json

# delete service
aws ecs update-service --cluster studentblogg-cluster --service studentblogg-service --desired-count 0
aws ecs delete-service --cluster studentblogg-cluster --service studentblogg-service

aws ecs delete-cluster --cluster studentblogg-cluster

```