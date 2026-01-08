# Docker Persistence

## Oversikt over lagringstyper

### Docker Volumes

**Beskrivelse:**

- Dette er den mest brukte metoden for persistent lagring i Docker.
- Volumes lagres i en del av vertsmaskinens filsystem som er administrert av Docker (`/var/lib/docker/volumes/` på Linux).
- De er helt isolert fra vertsmaskinens filsystem, noe som gir en høy grad av sikkerhet og portabilitet.
- Volumes kan enkelt deles mellom flere containere og er ideelle for produksjonsbruk.
- Volumes er anbefalt fremfor å binde vertsmapper direkte til containere (såkalte bind mounts), spesielt i produksjonsmiljøer, da de er mer bærbare og bedre administrert av Docker.

**Brukseksempel:**

```bash
# Opprett Volume
docker volume create myvolume

# Bruk Volume
docker run -v myvolume:/data myimage
```

### Bind Mounts

**Beskrivelse:**

- Bind mounts lar deg mappe en spesifikk fil eller mappe på vertsmaskinen direkte inn i en container.
- De gir direkte tilgang til vertsmaskinens filsystem, noe som kan være nyttig for utviklingsformål.
- Bind mounts er avhengige av vertsmaskinens filsystem og struktur, noe som kan påvirke portabiliteten.

**Brukseksempel:**

```bash
# Bruk Bind Mount
docker run -v /path/on/host:/path/in/container myimage
```

### tmpfs Mounts

**Beskrivelse:**

- tmpfs mounts lagrer data i vertsmaskinens minne, ikke på disken.
- Dette betyr at dataene ikke er persistente mellom omstarter av containeren; de forsvinner når containeren stoppes.
- tmpfs mounts er nyttige for lagring av sensitive data som du ikke ønsker skal skrives til disk, eller for midlertidige data som ikke trenger å være persistente.

**Brukseksempel:**

```bash
# Bruk tmpfs
docker run --tmpfs /path/in/container myimage
```

## Eksempler på filsystemstier i Docker Desktop

```bash
cd \\wsl.localhost\docker-desktop-data\
cd \\wsl.localhost\docker-desktop-data\data\docker\volumes

evt.
cd \\wsl$\docker-desktop\mnt\docker-desktop-disk\data\docker\volumes
```
