# Docker Commands Reference

## General Docker Commands

| Command          | Description |
|------------------|-------------|
| `docker run`     | Brukes til å kjøre et containerbilde. |
| `docker ps`      | Brukes til å liste alle kjørende containere på en lokal maskin. |
| `docker start`   | Brukes til å starte en stoppet container. |
| `docker stop`    | Brukes til å stoppe en kjørende container. |
| `docker restart` | Restarter en kjørende container. |
| `docker pause`   | Suspenderer en kjørende container. |
| `docker unpause` | Gjenopptar en suspendert container. |
| `docker rm`      | Brukes til å fjerne en container. |
| `docker rmi`     | Fjern et bilde fra en lokal maskin. |
| `docker exec`    | Brukes til å kjøre en kommando inne i en kjørende container. |

## Additional Container Operations

| Command         | Description |
|-----------------|-------------|
| `docker create` | Oppretter en ny container, men starter den ikke. |
| `docker attach` | Kobler til en kjørende container for å se container's output. |
| `docker logs`   | Viser loggene for en container. |
| `docker wait`   | Blokkerer kommando linjen inntil en container stopper. |
| `docker export` | Eksporterer container til en tar-fil som kan importeres til en annen host. |
| `docker import` | Importerer container til en tar-fil som er eksportert fra en annen host. |
| `docker cp`     | Kopierer filer eller mapper mellom host og container eller mellom to containere. |

## Image Management Commands

| Command          | Description |
|------------------|-------------|
| `docker pull`    | Last ned et bilde fra en container-registreringsserver. |
| `docker push`    | Last opp et bilde til en container-registreringsserver. |
| `docker build`   | Bygg et bilde fra en Dockerfile. |
| `docker images`  | List alle lagrede bilder på en lokal maskin. |
| `docker tag`     | Tagg et eksisterende bilde med en ny referanse. |
| `docker save`    | Lagre et bilde til en tar-fil. |
| `docker load`    | Last inn et bilde fra en tar-fil. |
| `docker history` | Vis historikk for et bilde. |
| `docker inspect` | Vis detaljert informasjon om et bilde eller en container. |

## Dockerfile Instructions

| Instruction      | Description |
|------------------|-------------|
| `ADD`           | Kopierer filer og mapper fra byggekonteksten til containeren. |
| `ARG`           | Definerer bygge-tid argumenter. |
| `CMD`           | Angir hvilken kommando som skal kjøres når containeren starter. |
| `COPY`          | Kopierer filer og mapper fra byggekonteksten til containeren. |
| `ENTRYPOINT`    | Angir hva som skal kjøres som standard når containeren starter. |
| `ENV`           | Setter miljøvariabler inne i containeren. |
| `EXPOSE`        | Angir hvilke portene som skal være åpne inne i containeren. |
| `FROM`          | Angir hvilken base-image som skal brukes for å bygge containeren. |
| `HEALTHCHECK`   | Definerer hvordan containeren skal sjekkes. |
| `LABEL`         | Legger til metadata til containeren. |
| `MAINTAINER`    | Angir vedlikeholdsansvarlig for containeren. |
| `RUN`           | Kjører kommandoer inne i containeren under byggingen. |
| `VOLUME`        | Angir mapper som skal være volumer i containeren. |
| `WORKDIR`       | Angir hvilken mappe som skal være current working directory i containeren. |

## Volume Management Commands

| Command                | Description |
|------------------------|-------------|
| `docker volume create` | Opprett et nytt volum. |
| `docker volume ls`     | List opp alle eksisterende volumer. |
| `docker volume inspect`| Viser detaljert informasjon om et volum. |
| `docker volume rm`     | Fjerner et volum. |
| `docker volume prune`  | Fjerner alle volumer som ikke er tilknyttet noen container. |

## Docker Networking Commands

| Command                    | Description |
|----------------------------|-------------|
| `docker network create`    | Oppretter et nytt nettverk. |
| `docker network ls`        | List opp alle eksisterende nettverk. |
| `docker network inspect`   | Viser detaljert informasjon om et nettverk. |
| `docker network rm`        | Fjerner et nettverk. |
| `docker network connect`   | Tilkobler en container til et eksisterende nettverk. |
| `docker network disconnect`| Fjerner tilkoblingen mellom en container og et nettverk. |
| `docker network prune`     | Fjerner alle nettverk som ikke er tilknyttet noen container. |

## Docker Compose Key Elements

| Element        | Description |
|----------------|-------------|
| `version`      | Angir versjonen av Compose-filformatet som skal brukes. |
| `services`     | Definerer tjenestene som skal kjøres i konteinerne. |
| `networks`     | Definerer nettverkene som skal opprettes og brukes av konteinerne. |
| `volumes`      | Definerer volumene som skal opprettes og brukes av konteinerne. |
| `build`        | Definerer byggeinstruksjoner for tjenestene. |
| `environment`  | Angir miljøvariabler for tjenestene. |
| `ports`        | Publiserer portene til en containeren til verten. |

<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>
## Example `docker-compose.yml`

```yaml
services:
  webapp:
    build: ./webapp
    image: nginx:latest
    command: 
      nginx -g "daemon off;"
    ports:
      - "8080:80"
    volumes:
      - ./webapp:/usr/share/nginx/html
    environment:
      - NGINX_PORT=80
    labels:
      - "com.example.description=Web Application Server"
    depends_on:
      - db
    networks:
      - webnet
    restart: always
    deploy:
      replicas: 3
      update_config:
        parallelism: 2
        delay: 10s
    entrypoint: ["/entrypoint.sh"]
    hostname: webapp
    user: "nginx"
    working_dir: /app

networks:
  webnet:
    driver: bridge

volumes:
  vol-name:
```
