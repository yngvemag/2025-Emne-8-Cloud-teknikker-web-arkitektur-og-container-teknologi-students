# ECS Setup

## Roles

### With Json

![1737484093477](image/10-setup-ecs-fargate/1737484093477.png)
![1737484194555](image/10-setup-ecs-fargate/1737484194555.png)
```bash
{
  "Version": "2012-10-17",
  "Statement": [
    {
      "Effect": "Allow",
      "Action": [
        "logs:CreateLogGroup",
        "logs:CreateLogStream",
        "logs:PutLogEvents"
      ],
      "Resource": "arn:aws:logs:eu-north-1:127214158791:log-group:/ecs/*"
    }
  ]
}
```

### Web Interface

![1737971310496](image/10-setup-ecs-fargate/1737971310496.png)
![1737971332173](image/10-setup-ecs-fargate/1737971332173.png)
![1737971360306](image/10-setup-ecs-fargate/1737971360306.png)
![1737971376536](image/10-setup-ecs-fargate/1737971376536.png)
![1737971419527](image/10-setup-ecs-fargate/1737971419527.png)


![1737484273738](image/10-setup-ecs-fargate/1737484273738.png)
![1737484303309](image/10-setup-ecs-fargate/1737484303309.png)

## Cluster Setup
![1737484063886](image/10-setup-ecs-fargate/1737484063886.png)

![1737480766580](image/10-setup-ecs-fargate/1737480766580.png)

## Create cluster

### CLR

```bash
aws ecs create-cluster --cluster-name studentblogg-cluster
aws ecs delete-service --cluster studentblogg-cluster --service-name <service-name> --force
```

## DB Task
![1737480788003](image/10-setup-ecs-fargate/1737480788003.png)
![1737480798177](image/10-setup-ecs-fargate/1737480798177.png)


### Create Task Definition
![1737480833940](image/10-setup-ecs-fargate/1737480833940.png)
![1737480892515](image/10-setup-ecs-fargate/1737480892515.png)
![1737480922444](image/10-setup-ecs-fargate/1737480922444.png)

### Get URI from ECR: 

![1737480997759](image/10-setup-ecs-fargate/1737480997759.png)
![1737481153961](image/10-setup-ecs-fargate/1737481153961.png)

### -> Default values -> Create
![1737481275703](image/10-setup-ecs-fargate/1737481275703.png)


## API-Task

![1737481355227](image/10-setup-ecs-fargate/1737481355227.png)
![1737481559505](image/10-setup-ecs-fargate/1737481559505.png)
```bash
ConnectionStrings__DefaultConnection=Server=studentblogg-db;Database=ga_emne7_avansert;User ID=ga-app;Password=ga-5ecret-%;
```
![1737481669465](image/10-setup-ecs-fargate/1737481669465.png)



## Create Services

![1737481736706](image/10-setup-ecs-fargate/1737481736706.png)
![1737481773473](image/10-setup-ecs-fargate/1737481773473.png)
![1737481861390](image/10-setup-ecs-fargate/1737481861390.png)
![1737481885656](image/10-setup-ecs-fargate/1737481885656.png)
![1737481945018](image/10-setup-ecs-fargate/1737481945018.png)

**(ONLY PUBLIC NETWORK - NEED Network Address Translation (NAT) to use private )**
![1737482004069](image/10-setup-ecs-fargate/1737482004069.png)

### Create

![1737482081408](image/10-setup-ecs-fargate/1737482081408.png)
![1737482139228](image/10-setup-ecs-fargate/1737482139228.png)
![1737482169522](image/10-setup-ecs-fargate/1737482169522.png)
## Start
