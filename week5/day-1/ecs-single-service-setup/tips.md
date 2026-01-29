# Tips

## studentblogg-task.json

```bash

# bytt ut imagenamnet med eget eget
"image": "127214158791.dkr.ecr.eu-north-1.amazonaws.com/studentblogg-db:latest",
```

## create-service.json

```bash

# bytt subnets og security-group med eget

 "networkConfiguration": {
    "awsvpcConfiguration": {
      "subnets": ["<>", "<>", "<>"],
      "securityGroups": ["<>"],
      "assignPublicIp": "ENABLED"
    }
  },

# bytt ut namespace med eget
"namespace": "<>",
```