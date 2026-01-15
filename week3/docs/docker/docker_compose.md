# Docker Compose Reference

## Hva er Docker Compose?

Docker Compose er et verktøy for definering og kjøring av multi-container Docker-apper. Det lar deg:

- Definere alle containere, deres konfigurasjoner, miljøvariabler, volumer, nettverk, og andre egenskaper som kreves for å kjøre en app i en enkelt fil kalt `docker-compose.yml`.
- Sette opp, konfigurere og kjøre komplekse Docker-apper med en enkelt kommando.
- Enkelt administrere Docker-apper på en organisert måte, og forenkle overføring av Docker-apper til andre miljøer.

## Root Elementer i Docker Compose

| Element        | Description |
|----------------|-------------|
| `version`      | Angir versjonen av Compose-filformatet som skal brukes. |
| `services`     | Definerer tjenestene som skal kjøres i containere. |
| `networks`     | Definerer nettverkene som skal opprettes og brukes av containere. |
| `volumes`      | Definerer volumene som skal opprettes og brukes av containere. |
| `configs`      | Definerer konfigurasjonsfilene som skal lastes inn i containere. |
| `secrets`      | Definerer hemmeligheter som skal lastes inn i containere. |
| `extends`      | Arver egenskapene fra en annen Compose-fil. |
| `extra_hosts`  | Legger til vertsnavn til IP-adresser i containere. |
| `build`        | Definerer byggeinstruksjoner for tjenestene. |
| `cap_add`/`cap_drop` | Spesifiserer tilgang til systemressurser for containere. |
| `devices`      | Monter enheter i containere. |
| `dns`          | Angir DNS-servere til containere. |
| `env_file`     | Angir en ekstern fil for miljøvariabler til containere. |
| `environment`  | Angir miljøvariabler til containere. |
| `labels`       | Tilordner etiketter til containere for organisering og identifisering. |
| `volumes_from` | Monter volumer fra andre containere til containere. |

<br><br><br><br><br><br>

## Service Elementer

| Element         | Description |
|-----------------|-------------|
| `build`         | Spesifiserer stien til Dockerfile for å bygge en container. |
| `image`         | Spesifiserer bildet som skal kjøres som en container. |
| `command`       | Spesifiserer kommandoen som skal kjøres når containeren startes. |
| `ports`         | Publiserer portene til en container til verten. |
| `volumes`       | Monteringspunkter for data mellom verten og containeren. |
| `environment`   | Setter miljøvariabler for containeren. |
| `labels`        | Tilordner etiketter til en container. |
| `depends_on`    | Angir avhengigheter mellom tjenester i en Compose-fil. |
| `networks`      | Spesifiserer hvilke nettverk en container skal koble til. |
| `restart`       | Angir hvordan containeren skal håndtere omstart. |
| `deploy`        | Spesifiserer deploy-relaterte instruksjoner, inkludert replikasjoner og oppdateringsstrategier. |
| `entrypoint`    | Angir standard inngangspunkt for containeren. |
| `hostname`      | Angir vertsnavnet til containeren. |
| `user`          | Angir brukeren som skal kjøre kommandoen i containeren. |
| `working_dir`   | Angir standard arbeidsmappe for kommandoen som kjøres i containeren. |

## Eksempel på `docker-compose.yml`

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

## Docker Compose Commands

| Command                                    | Description |
|-------------------------------------------|-------------|
| `docker-compose build`                    | Builds the services defined in the `docker-compose.yml` file. |
| `docker-compose up`                       | Creates and starts all services defined in the `docker-compose.yml` file. |
| `docker-compose down`                     | Stops and removes all containers, networks, and volumes. |
| `docker-compose logs`                     | Shows logs for all services. |
| `docker-compose ps`                       | Lists all containers created from the services. |
| `docker-compose scale <service>=<number>` | Scales the specified service to the specified number of replicas. |
| `docker-compose exec <service> <command>` | Executes a command in a running container for a specified service. |
| `docker-compose run <service> <command>`  | Runs a one-time command in a new container for a specified service. |
| `docker-compose pause`                    | Pauses all services. |
| `docker-compose unpause`                  | Resumes all paused services. |
| `docker-compose kill`                     | Sends a SIGKILL to all containers. |
| `docker-compose rm`                       | Removes all containers. |
| `docker-compose pull`                     | Pulls the latest version of the image for all services. |
| `docker-compose push`                     | Pushes the image for all services to the specified registry. |
| `docker-compose config`                   | Validates and shows the configuration. |
| `docker-compose port <service> <port>`    | Shows the public-facing port for a specified private port. |
