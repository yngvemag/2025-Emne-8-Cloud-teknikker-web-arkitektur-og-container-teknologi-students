# Forklaring av multi-stage Dockerfile for StudentBloggAPI

Dette dokumentet forklarer **linje for linje** hvordan en enkel multi-stage Dockerfile for en ASP.NET Core API fungerer, og *hvorfor* den er skrevet på denne måten.

Dockerfile som forklares:

```dockerfile
# Enkel multi-stage Dockerfile for StudentBloggAPI

# ===============================
# 1. Build stage
# ===============================
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Kopier prosjektfil først for cache-vennlig restore
COPY StudentBloggAPI.csproj ./
RUN dotnet restore

# Kopier resten av kildekoden og bygg
COPY . .
RUN dotnet publish -c Release -o /app/publish

# ===============================
# 2. Runtime stage
# ===============================
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

# Appen lytter på 8080 som i oppskriften
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# Kopier ferdig publisert binær og start API-et
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "StudentBloggAPI.dll"]
```

---

## Hva er en multi-stage Dockerfile?

En **multi-stage Dockerfile** bruker flere `FROM`-instruksjoner for å:

1. Bygge applikasjonen i et image som inneholder alle verktøy (SDK)
2. Kjøre applikasjonen i et mye mindre image som kun inneholder runtime

Fordeler:

- Mindre Docker image
- Bedre sikkerhet
- Raskere deploy
- Ingen SDK eller kildekode i produksjon

---

## Stage 1 – Build stage

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
```

- Bruker Microsoft sitt offisielle .NET SDK-image
- `AS build` gir steget et navn som brukes senere

```dockerfile
WORKDIR /src
```

- Setter arbeidsmappen inni containeren til `/src`

---

### Cache-vennlig restore

```dockerfile
COPY StudentBloggAPI.csproj ./
RUN dotnet restore
```

Dette er et viktig Docker-mønster:

- Kun `.csproj` kopieres først
- `dotnet restore` laster ned NuGet-pakker

Docker cacher dette laget. Så lenge `.csproj` ikke endres, slipper du å laste ned pakker på nytt.

---

### Kopier resten av koden og publish

```dockerfile
COPY . .
RUN dotnet publish -c Release -o /app/publish
```

- Kopierer resten av kildekoden
- `dotnet publish`:
  - `-c Release`: optimalisert produksjonsbuild
  - `-o /app/publish`: ferdig output

Resultatet er en mappe med:

- `.dll`-filer
- konfigurasjon
- alle nødvendige dependencies

---

## Stage 2 – Runtime stage

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
```

- Bruker et mye mindre image som kun inneholder ASP.NET runtime
- Ingen SDK eller build-verktøy

---

### Port og URL-binding

```dockerfile
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
```

#### EXPOSE

- Dokumenterer hvilken port applikasjonen bruker
- Åpner ikke porten alene

#### ASPNETCORE_URLS

- Forteller Kestrel hvilken port den skal lytte på
- `+` betyr alle nettverksinterfaces (0.0.0.0)
- Viktig for at appen skal være tilgjengelig utenfor containeren

---

### Kopier kun publish-output

```dockerfile
COPY --from=build /app/publish .
```

- Kopierer kun ferdig bygget applikasjon
- Ingen kildekode eller SDK følger med

---

### Start applikasjonen

```dockerfile
ENTRYPOINT ["dotnet", "StudentBloggAPI.dll"]
```

- Kommandoen som kjøres når containeren starter
- Starter ASP.NET Core-applikasjonen

---

## Typisk bruk

### Bygg image

```bash
docker build -t studentbloggapi .
```

### Kjør container

```bash
docker run -p 8080:8080 studentbloggapi
```

---

## Vanlige problemer dette løser

- Appen er ikke tilgjengelig utenfra containeren  
- Bygg tar lang tid på grunn av manglende cache  
- Docker image blir unødvendig stort  

---

## Videre forbedringer (valgfritt)

- Legg til `.dockerignore` for å utelate `bin/`, `obj/`, `.git/`
- Bruk `DOTNET_ENVIRONMENT=Production`
- Bruk Docker Compose eller ECS for secrets og config

---

Dette dokumentet kan brukes både som **referanse**, **undervisningsmateriell** og **eksamensforklaring**.
