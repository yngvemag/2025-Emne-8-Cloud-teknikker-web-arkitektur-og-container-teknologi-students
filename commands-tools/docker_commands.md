# Docker Command Cheat Sheet

This document provides a comprehensive overview of essential Docker commands, with descriptions and examples for each.

## Table of Contents

- [Installation and Setup](#installation-and-setup)
- [Basic Commands](#basic-commands)
- [Images](#images)
- [Containers](#containers)
- [Volumes](#volumes)
- [Networks](#networks)
- [Docker Compose](#docker-compose)
- [Docker Swarm](#docker-swarm)
- [Docker Registry](#docker-registry)
- [Container Management](#container-management)
- [Docker System](#docker-system)
- [Docker Context](#docker-context)
- [Docker Debugging](#docker-debugging)
- [Docker Workflow Examples](#docker-workflow-examples)
- [Best Practices](#best-practices)

## Installation and Setup
_Get Docker installed on your system and verify its proper operation with basic configuration._

### Installing Docker

```powershell
# Windows: Install Docker Desktop
# Download from: https://www.docker.com/products/docker-desktop

# Linux: Install using package manager
# Ubuntu/Debian:
# sudo apt update
# sudo apt install docker.io docker-compose

# RHEL/CentOS:
# sudo yum install docker docker-compose

# Check Docker version
docker --version
docker version

# Check Docker info
docker info

# Start Docker service (Linux)
# sudo systemctl start docker
# sudo systemctl enable docker
```
<div style="page-break-after:always;"></div>

### Docker Configuration

```powershell
# Config file locations
# Windows: %USERPROFILE%\.docker\config.json
# Linux: $HOME/.docker/config.json

# Configure Docker to start on boot (Windows)
# In Docker Desktop settings

# Check Docker service status (Linux)
# sudo systemctl status docker

# Configure user to run Docker without sudo (Linux)
# sudo usermod -aG docker $USER
```

## Basic Commands
_The fundamental Docker commands you'll use daily for working with Docker._

### Help and Information

```powershell
# Get help on Docker commands
docker --help

# Get help on specific command
docker run --help

# Show Docker system info
docker info

# Show Docker version
docker version
```
<div style="page-break-after:always;"></div>

### Authentication

```powershell
# Log in to Docker Hub
docker login

# Log in to private registry
docker login registry.example.com

# Log out from registry
docker logout

# View current login information
cat $HOME/.docker/config.json
```

## Images
_Work with Docker images - the templates used to create Docker containers._

### Listing and Searching Images

```powershell
# List local images
docker images
docker image ls

# Search for images in Docker Hub
docker search nginx
docker search --filter stars=100 nginx

# Show image details
docker image inspect nginx

# Show image history/layers
docker history nginx
```

### Pulling and Pushing Images

```powershell
# Pull an image
docker pull nginx
docker pull nginx:1.21

# Pull from private registry
docker pull registry.example.com/myapp:latest

# Push image to Docker Hub
docker push username/image:tag

# Push to private registry
docker push registry.example.com/myapp:latest
```
<div style="page-break-after:always;"></div>

### Building Images

```powershell
# Build an image from a Dockerfile in current directory
docker build -t myapp:1.0 .

# Build with different Dockerfile name
docker build -f Dockerfile.prod -t myapp:production .

# Build with build arguments
docker build --build-arg ENV=production -t myapp:prod .

# Build with no cache
docker build --no-cache -t myapp:latest .

# Build for specific platform
docker build --platform linux/amd64 -t myapp:amd64 .
```

### Managing Images

```powershell
# Tag an image
docker tag myapp:latest myapp:1.0
docker tag myapp:latest username/myapp:latest

# Remove an image
docker rmi nginx
docker image rm nginx:latest
docker rmi -f nginx  # Force remove

# Remove all unused images
docker image prune
docker image prune -a  # Remove all unused images, not just dangling ones

# Save image to tar file
docker save -o nginx.tar nginx:latest

# Load image from tar file
docker load -i nginx.tar
```
<div style="page-break-after:always;"></div>

### Image Layers and Cleanup

```powershell
# View dangling images
docker images -f "dangling=true"

# Remove dangling images
docker image prune

# Show image disk usage
docker system df -v

# Export container as new image
docker export my-container > container.tar
docker import container.tar imported-image:latest
```

## Containers
_Create, run, and manage Docker containers - the running instances of Docker images._

### Running Containers

```powershell
# Run a container
docker run nginx

# Run container in detached mode (background)
docker run -d nginx

# Run with a name
docker run -d --name my-nginx nginx

# Run and publish ports
docker run -d -p 8080:80 nginx

# Run with environment variables
docker run -d -e MYSQL_ROOT_PASSWORD=secret mysql

# Run with mounted volume
docker run -d -v /host/path:/container/path nginx

# Run and remove after exit
docker run --rm nginx

# Run interactively with terminal
docker run -it ubuntu bash

# Run with specific network
docker run --network my-network nginx

# Run with resource limits
docker run -d --memory="512m" --cpus="0.5" nginx
```
<div style="page-break-after:always;"></div>

### Container Lifecycle

```powershell
# List running containers
docker ps

# List all containers (including stopped)
docker ps -a

# Start a stopped container
docker start my-container

# Stop a container
docker stop my-container

# Restart a container
docker restart my-container

# Pause a container
docker pause my-container

# Unpause a container
docker unpause my-container

# Kill a container
docker kill my-container

# Remove a container
docker rm my-container
docker rm -f my-container  # Force remove running container

# Remove all stopped containers
docker container prune
```

### Container Interaction

```powershell
# Execute command in running container
docker exec my-container ls -la

# Get interactive terminal in container
docker exec -it my-container bash

# Copy files from container to host
docker cp my-container:/file/path/in/container /host/path

# Copy files from host to container
docker cp /host/path my-container:/file/path/in/container

# View container logs
docker logs my-container
docker logs -f my-container  # Follow logs
docker logs --tail 100 my-container  # Last 100 lines
docker logs --since 2025-06-01 my-container  # Logs since date

# Show container resource usage stats
docker stats
docker stats my-container
```
<div style="page-break-after:always;"></div>

### Container Information

```powershell
# Show container details
docker inspect my-container

# Show mapped ports
docker port my-container

# Show running processes in container
docker top my-container

# Show container resource usage
docker stats my-container

# Show container changes
docker diff my-container

# Rename container
docker rename old-name new-name

# Update container configuration
docker update --memory 1G --memory-swap 1G my-container
```

## Volumes
_Persist and share data between the host system and Docker containers or between containers._

### Volume Management

```powershell
# List volumes
docker volume ls

# Create a volume
docker volume create my-volume

# Inspect a volume
docker volume inspect my-volume

# Remove a volume
docker volume rm my-volume

# Remove all unused volumes
docker volume prune

# Use a volume with a container
docker run -v my-volume:/path/in/container nginx
```
<div style="page-break-after:always;"></div>

### Volume Types and Mounts

```powershell
# Named volume
docker run -v my-volume:/var/lib/mysql mysql

# Host path binding
docker run -v /host/path:/container/path nginx
docker run -v C:\data:/container/path nginx  # Windows

# Read-only mount
docker run -v my-volume:/container/path:ro nginx

# Tmpfs mount (in-memory)
docker run --tmpfs /tmp nginx

# Volume with specific driver
docker volume create --driver local my-volume

# Using bind mounts with run
docker run --mount type=bind,source=/host/path,target=/container/path nginx

# Using volume mounts with run
docker run --mount type=volume,source=my-volume,target=/container/path nginx
```

### Sharing Data Between Containers

```powershell
# Create data volume container
docker create -v /data --name data-container busybox

# Use volumes from another container
docker run --volumes-from data-container nginx

# Backup volume data
docker run --rm --volumes-from data-container -v $(pwd):/backup busybox tar cvf /backup/data.tar /data

# Restore volume data
docker run --rm --volumes-from data-container -v $(pwd):/backup busybox tar xvf /backup/data.tar
```
<div style="page-break-after:always;"></div>

## Networks
_Create and manage Docker networks for container communication._

### Network Management

```powershell
# List networks
docker network ls

# Create a network
docker network create my-network

# Create network with subnet
docker network create --subnet=172.18.0.0/16 my-network

# Create overlay network (for Swarm)
docker network create --driver overlay my-overlay-network

# Connect container to network
docker network connect my-network my-container

# Disconnect container from network
docker network disconnect my-network my-container

# Remove a network
docker network rm my-network

# Remove all unused networks
docker network prune
```

### Network Inspection and Configuration

```powershell
# Inspect network
docker network inspect my-network

# Run container with specific network
docker run --network my-network nginx

# Run container with static IP
docker run --network my-network --ip 172.18.0.10 nginx

# Run container with DNS settings
docker run --dns 8.8.8.8 nginx

# Run container with hostname
docker run --hostname myhost nginx

# Add network aliases
docker run --network my-network --network-alias myalias nginx
```
<div style="page-break-after:always;"></div>

## Docker Compose
_Define and run multi-container Docker applications with YAML files._

### Basic Docker Compose Commands

```powershell
# Run services defined in docker-compose.yml
docker-compose up

# Run in detached mode
docker-compose up -d

# Build or rebuild services
docker-compose build

# Stop services
docker-compose stop

# Stop and remove containers, networks
docker-compose down

# Stop and remove containers, networks, volumes
docker-compose down -v

# View logs
docker-compose logs
docker-compose logs -f service-name  # Follow logs for specific service

# List containers
docker-compose ps

# Run a command in a service container
docker-compose exec service-name command

# Scale services
docker-compose up -d --scale service-name=3
```

### Working with Docker Compose Files

```powershell
# Use specific compose file
docker-compose -f custom-compose.yml up

# Run with multiple compose files
docker-compose -f docker-compose.yml -f docker-compose.prod.yml up

# Validate compose file
docker-compose config

# Show services
docker-compose config --services

# Pull images for services
docker-compose pull

# Push images for services
docker-compose push
```
<div style="page-break-after:always;"></div>

### Example docker-compose.yml

```yaml
version: '3.8'

services:
  web:
    image: nginx:latest
    ports:
      - "80:80"
    volumes:
      - ./html:/usr/share/nginx/html
    depends_on:
      - app

  app:
    build: ./app
    environment:
      - DB_HOST=db
      - DB_PASSWORD=secret
    volumes:
      - ./app:/code
    depends_on:
      - db

  db:
    image: postgres:13
    environment:
      - POSTGRES_PASSWORD=secret
    volumes:
      - db-data:/var/lib/postgresql/data

volumes:
  db-data:
```

## Docker Swarm
_Create and manage a cluster of Docker hosts for orchestrating containers._

### Swarm Initialization and Management

```powershell
# Initialize a new swarm
docker swarm init --advertise-addr <MANAGER-IP>

# Get join token for worker
docker swarm join-token worker

# Get join token for manager
docker swarm join-token manager

# Join a swarm as worker
docker swarm join --token <TOKEN> <MANAGER-IP:PORT>

# Join a swarm as manager
docker swarm join --token <TOKEN> <MANAGER-IP:PORT>

# Leave the swarm
docker swarm leave
docker swarm leave --force  # For manager

# List nodes in swarm
docker node ls
```
<div style="page-break-after:always;"></div>

### Swarm Services

```powershell
# Create a service
docker service create --name my-service nginx

# Create service with replicas
docker service create --name my-service --replicas 3 nginx

# List services
docker service ls

# List service tasks (containers)
docker service ps my-service

# Scale a service
docker service scale my-service=5

# Update a service
docker service update --image nginx:1.21 my-service
docker service update --publish-add 8080:80 my-service

# Remove a service
docker service rm my-service

# Inspect a service
docker service inspect my-service
```

### Swarm Stacks

```powershell
# Deploy stack from compose file
docker stack deploy -c docker-compose.yml my-stack

# List stacks
docker stack ls

# List services in stack
docker stack services my-stack

# List tasks in stack
docker stack ps my-stack

# Remove a stack
docker stack rm my-stack
```
<div style="page-break-after:always;"></div>

## Docker Registry
_Work with private Docker registries for storing and sharing images._

### Registry Management

```powershell
# Run a local registry
docker run -d -p 5000:5000 --name registry registry:2

# Tag image for local registry
docker tag myimage:latest localhost:5000/myimage:latest

# Push to local registry
docker push localhost:5000/myimage:latest

# Pull from local registry
docker pull localhost:5000/myimage:latest

# List images in local registry
curl -X GET http://localhost:5000/v2/_catalog

# List tags for specific image
curl -X GET http://localhost:5000/v2/myimage/tags/list
```

### Secure Registry Operations

```powershell
# Log in to private registry
docker login registry.example.com

# Tag for private registry
docker tag myimage:latest registry.example.com/username/myimage:latest

# Push to private registry
docker push registry.example.com/username/myimage:latest

# Pull from private registry
docker pull registry.example.com/username/myimage:latest

# Log out from registry
docker logout registry.example.com
```
<div style="page-break-after:always;"></div>

## Container Management
_Advanced container operations for effective Docker management._

### Resource Constraints

```powershell
# Set memory limits
docker run -d --memory="512m" --memory-swap="1g" nginx

# Set CPU limits
docker run -d --cpus="1.5" nginx
docker run -d --cpu-shares=512 nginx

# Set I/O limits
docker run -d --device-write-bps /dev/sda:1mb nginx

# Update resource constraints on running container
docker update --memory="1g" --cpus="2" my-container
```

### Container Health Checks

```powershell
# Run with health check
docker run --health-cmd="curl -f http://localhost/ || exit 1" --health-interval=5s nginx

# View container health
docker inspect --format='{{.State.Health.Status}}' my-container

# Dockerfile health check example
# HEALTHCHECK --interval=5s --timeout=3s --start-period=5s --retries=3 \
#   CMD curl -f http://localhost/ || exit 1
```

### Logging

```powershell
# View container logs
docker logs my-container

# Follow logs
docker logs -f my-container

# Show timestamps
docker logs -t my-container

# Show recent logs
docker logs --tail=100 my-container

# Show logs since timestamp
docker logs --since="2025-06-01T00:00:00" my-container

# Show logs until timestamp
docker logs --until="2025-06-02T00:00:00" my-container

# Configure logging driver
docker run --log-driver=syslog --log-opt syslog-address=udp://syslog-server:514 nginx
```
<div style="page-break-after:always;"></div>

## Docker System
_Manage Docker system resources, settings, and perform maintenance operations._

### System Information and Cleanup

```powershell
# Show Docker system information
docker system info

# Show Docker disk usage
docker system df
docker system df -v  # Verbose

# Remove all unused containers, networks, images, and optionally, volumes
docker system prune
docker system prune -a  # Include unused images
docker system prune -a --volumes  # Include unused volumes

# Clean up builder cache
docker builder prune
```

### Docker Events and Monitoring

```powershell
# View real-time events
docker events

# Filter events by type
docker events --filter 'type=container'
docker events --filter 'event=start'

# Filter events by time
docker events --since '2025-06-01'
docker events --until '2025-06-02'

# Show disk usage by container
docker ps -s
```
<div style="page-break-after:always;"></div>

### Docker Daemon Configuration

```powershell
# Location of Docker daemon config file
# Linux: /etc/docker/daemon.json
# Windows: C:\ProgramData\docker\config\daemon.json

# Example daemon.json content
# {
#   "log-driver": "json-file",
#   "log-opts": {
#     "max-size": "10m",
#     "max-file": "3"
#   },
#   "registry-mirrors": ["https://mirror.example.com"],
#   "insecure-registries": ["registry.local:5000"],
#   "storage-driver": "overlay2",
#   "default-address-pools": [
#     {"base": "172.30.0.0/16", "size": 24}
#   ]
# }

# Restart Docker daemon (Linux)
# sudo systemctl restart docker
```

## Docker Context
_Work with Docker contexts to manage multiple Docker endpoints from a single client._

```powershell
# List Docker contexts
docker context ls

# Create new context
docker context create my-context --docker "host=tcp://host:2375"

# Use specific context
docker context use my-context

# Show current context
docker context show

# Inspect context
docker context inspect my-context

# Remove context
docker context rm my-context

# Update context
docker context update my-context --docker "host=tcp://new-host:2375"
```
<div style="page-break-after:always;"></div>

## Docker Debugging
_Troubleshoot and debug issues with Docker containers and the Docker engine._

### Container Debugging

```powershell
# Get container details
docker inspect my-container

# Check logs for errors
docker logs my-container

# Get interactive shell in running container
docker exec -it my-container /bin/sh

# Check container resource usage
docker stats my-container

# Check container processes
docker top my-container

# See layer changes in container
docker diff my-container

# Check container networking
docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' my-container
```

### Docker Engine Debugging

```powershell
# Check Docker engine status
docker info

# View Docker daemon logs
# Linux:
# sudo journalctl -u docker.service

# Check for errors in daemon log
# sudo journalctl -u docker.service | grep -i error

# Test Docker API
curl --unix-socket /var/run/docker.sock http://localhost/version

# View Docker events in real-time
docker events

# View Docker network debugging info
docker network inspect bridge
```
<div style="page-break-after:always;"></div>

## Docker Workflow Examples
_Common patterns and procedures for using Docker effectively in different scenarios._

### Development Workflow

```powershell
# Clone repository
git clone https://github.com/example/project
cd project

# Build development image
docker build -t project-dev -f Dockerfile.dev .

# Run development container with volume mounts
docker run -d -p 3000:3000 -v $(pwd):/app --name dev project-dev

# View logs
docker logs -f dev

# Execute tests in container
docker exec dev npm test

# Stop and clean up
docker stop dev
docker rm dev
```

### CI/CD Pipeline Example

```powershell
# Build image
docker build -t myapp:$CI_COMMIT_SHA .

# Run tests
docker run --rm myapp:$CI_COMMIT_SHA npm test

# Tag image for registry
docker tag myapp:$CI_COMMIT_SHA registry.example.com/myapp:$CI_COMMIT_SHA
docker tag myapp:$CI_COMMIT_SHA registry.example.com/myapp:latest

# Push to registry
docker push registry.example.com/myapp:$CI_COMMIT_SHA
docker push registry.example.com/myapp:latest

# Deploy to production
docker-compose -f docker-compose.prod.yml pull
docker-compose -f docker-compose.prod.yml up -d
```
<div style="page-break-after:always;"></div>

### Microservices Workflow

```powershell
# Create a Docker network
docker network create microservices

# Start database service
docker run -d --name db --network microservices -e POSTGRES_PASSWORD=secret postgres

# Start cache service
docker run -d --name redis --network microservices redis

# Start API service
docker run -d --name api --network microservices -p 8080:8080 -e DB_HOST=db -e REDIS_HOST=redis my-api

# Start web service
docker run -d --name web --network microservices -p 80:80 -e API_URL=http://api:8080 my-web

# Check if services are running
docker ps

# View logs from all services
docker-compose logs -f

# Scale API service
docker-compose up -d --scale api=3
```

### Multi-stage Build Example

```dockerfile
# Dockerfile with multi-stage build

# Build stage
FROM node:18 AS builder
WORKDIR /app
COPY package*.json ./
RUN npm ci
COPY . .
RUN npm run build

# Production stage
FROM node:18-slim
WORKDIR /app
ENV NODE_ENV=production
COPY --from=builder /app/package*.json ./
RUN npm ci --only=production
COPY --from=builder /app/dist ./dist
CMD ["node", "dist/server.js"]
```
<div style="page-break-after:always;"></div>

## Best Practices
_Guidelines for writing efficient, secure, and maintainable Docker configurations._

### Dockerfile Best Practices

```dockerfile
# Use specific version tags
FROM node:18.16.1-slim

# Use multi-stage builds
FROM node:18.16.1 AS builder
# ... build steps ...
FROM node:18.16.1-slim
COPY --from=builder /app/dist /app/dist

# Group RUN commands to reduce layers
RUN apt-get update \
    && apt-get install -y --no-install-recommends ca-certificates curl \
    && rm -rf /var/lib/apt/lists/*

# Set non-root user
RUN useradd -r appuser
USER appuser

# Use .dockerignore file
# .dockerignore example:
# node_modules
# npm-debug.log
# Dockerfile
# .git
# .gitignore

# Use ENTRYPOINT and CMD correctly
ENTRYPOINT ["node"]
CMD ["app.js"]

# Use health checks
HEALTHCHECK --interval=30s --timeout=3s \
  CMD curl -f http://localhost/ || exit 1
```

### Security Best Practices

```powershell
# Scan image for vulnerabilities
docker scan myapp:latest

# Run container with minimal privileges
docker run --security-opt=no-new-privileges myapp

# Run container with read-only filesystem
docker run --read-only myapp

# Use secrets for sensitive data
docker secret create db_password secrets.txt
docker service create --secret db_password myapp

# Run as non-root user
docker run -u 1000:1000 myapp

# Limit container capabilities
docker run --cap-drop=ALL --cap-add=NET_BIND_SERVICE myapp
```
<div style="page-break-after:always;"></div>

### Performance Tips

```powershell
# Use container resource limits
docker run -d --memory=1g --cpus=0.5 myapp

# Use appropriate storage driver
# Check current:
docker info | grep "Storage Driver"

# Use volume mounts for databases
docker run -v db-data:/var/lib/postgresql/data postgres

# Use tmpfs for temporary files
docker run --tmpfs /tmp myapp

# Monitor container stats
docker stats

# Use appropriate network driver
docker network create --driver overlay production

# Optimize Docker daemon settings
# In /etc/docker/daemon.json:
# {
#   "max-concurrent-downloads": 10,
#   "max-concurrent-uploads": 5
# }
```

### Docker Compose Best Practices

```yaml
# docker-compose.yml

version: '3.8'

services:
  app:
    build:
      context: ./app
      dockerfile: Dockerfile.prod
      args:
        - ENV=production
    image: myapp:${TAG:-latest}
    restart: unless-stopped
    env_file: .env.production
    healthcheck:
      test: ["CMD", "curl", "-f", "http://localhost/health"]
      interval: 30s
      timeout: 10s
      retries: 3
      start_period: 40s

volumes:
  app-data:
    driver: local
    driver_opts:
      type: none
      device: ${PWD}/data
      o: bind

networks:
  app-network:
    driver: overlay
    ipam:
      driver: default
      config:
        - subnet: 172.28.0.0/16
```