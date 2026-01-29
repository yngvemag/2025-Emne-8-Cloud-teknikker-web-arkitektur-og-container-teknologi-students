## EC2 - Deploy Docker-compose

### Kopierer docker-compose.yml til server

```bash

# copy docker-compose.yml to server
scp -i .\studentblogg.pem .\docker-compose.yml ubuntu@13.48.55.93:

# update apt and install docker
sudo apt update
sudo apt upgrade
sudo apt install docker-compose
```

- open ports on aws-server
![1737112993446](image/ssh-connect/1737112993446.png)
![1737113000261](image/ssh-connect/1737113000261.png)
![1737113006639](image/ssh-connect/1737113006639.png)
![1737113013994](image/ssh-connect/1737113013994.png)

### Run docker-compose

```bash
sudo docker-compose up -d
```