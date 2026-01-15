# Bygge og publisere Docker images for både `amd64` og `arm64` (grundig guide)

Denne guiden forklarer **hva** kommandoene gjør, **hvorfor** du trenger dem, og **hvordan** du kjører dem på **Windows, macOS og Linux**. Den dekker også en mer profesjonell løsning: **multi-arch image** (ett image som fungerer på begge arkitekturer automatisk).

---

## Innhold

1. [Bakgrunn: hvorfor arkitektur betyr noe](#bakgrunn-hvorfor-arkitektur-betyr-noe)  
2. [Begreper: image, tag, registry, push/pull](#begreper-image-tag-registry-pushpull)  
3. [Hva gjør `--platform`?](#hva-gjør---platform)  
4. [Kommandoene du viste: linje for linje](#kommandoene-du-viste-linje-for-linje)  
5. [Windows / macOS / Linux: slik bruker du kommandoene](#windows--macos--linux-slik-bruker-du-kommandoene)  
6. [Vanlige feil og hvordan du løser dem](#vanlige-feil-og-hvordan-du-løser-dem)  
7. [Anbefalt: multi-arch image med `buildx`](#anbefalt-multi-arch-image-med-buildx)  
8. [Sjekk hva du har bygget (verifisering)](#sjekk-hva-du-har-bygget-verifisering)  
9. [Praktisk oppskrift: fra null til publisert](#praktisk-oppskrift-fra-null-til-publisert)

---

## Bakgrunn: hvorfor arkitektur betyr noe

CPU-arkitektur bestemmer hvilken **maskinkode** programmet i imaget er bygget for.

De to vanligste i dag:

- **`amd64`** (også kalt `x86_64`): Intel/AMD – vanlig på PC-er og mange servere.
- **`arm64`**: Apple Silicon (M1/M2/M3), mange ARM-servere (f.eks. AWS Graviton), Raspberry Pi 64-bit.

Et Docker-image inneholder OS-filer + applikasjonen din. Hvis applikasjonen (eller base-imaget) inneholder binærfiler for feil arkitektur, vil containeren typisk feile med:

> `exec format error`

Derfor: skal imaget kjøre på både Intel/AMD og Apple Silicon/ARM, må du enten:

1) bygge **to images** (ett per arkitektur), eller  
2) bygge et **multi-arch image** (ett navn, flere arkitekturer).

---
<div style="page-break-after:always;"></div>

## Begreper: image, tag, registry, push/pull

- **Image**: En “mal” (lag med filer) som containeren starter fra.
- **Tag**: En versjons-/variant-etikett etter kolon `:`.  
  Eksempel: `myapp:amd64` og `myapp:arm64`.
- **Registry**: Et sted images lagres (f.eks. Docker Hub).  
  Eksempel: `dockerhub-username/image-name`.
- **push**: Last opp image til registry.
- **pull**: Last ned image fra registry.

---

## Hva gjør `--platform`?

Flagget `--platform` forteller Docker hvilken plattform imaget skal bygges for.

Eksempel:

- `--platform linux/amd64` betyr: bygg for Linux + amd64 (Intel/AMD).
- `--platform linux/arm64` betyr: bygg for Linux + arm64 (Apple Silicon / ARM).

Dette er viktig selv om du bygger på Windows/macOS, fordi containeren **som regel kjører Linux** i Docker (Docker Desktop bruker en Linux-VM i bakgrunnen).

---

<div style="page-break-after:always;"></div>

## Kommandoene du viste: linje for linje

Du hadde disse:

```bash
# Build for Intel/AMD (amd64)
docker build --platform linux/amd64 -t dockerhub-username/image-name:amd64 .
docker push dockerhub-username/image-name:amd64

# Build for Apple Silicon (arm64)
docker build --platform linux/arm64 -t dockerhub-username/image-name:arm64 .
docker push dockerhub-username/image-name:arm64
```

### 1) `docker build ...`

Generelt mønster:

```bash
docker build --platform <os/arch> -t <registry>/<repo>:<tag> <context>
```

- `docker build`: bygger et image fra Dockerfile.
- `--platform linux/amd64` eller `--platform linux/arm64`: tvinger arkitektur.
- `-t ...`: navngir imaget (inkl. tag).
- `.` (context): “bygg-kontekst” = mappen som sendes til Docker build.  
  Dockerfile må typisk ligge her (eller pekes til med `-f`).

### 2) `docker push ...`

```bash
docker push dockerhub-username/image-name:amd64
```

- Laster opp imaget (med den taggen) til Docker Hub.

---
<div style="page-break-after:always;"></div>

## Windows / macOS / Linux: slik bruker du kommandoene

### Før du begynner (alle OS)

1. **Installer Docker**
   - Windows/macOS: Docker Desktop.
   - Linux: Docker Engine (evt. Docker Desktop på noen distroer).

2. **Logg inn på Docker Hub** (må gjøres før push)

   ```bash
   docker login
   ```

   Du blir bedt om brukernavn og passord / token.

3. Sørg for at du står i mappen som inneholder `Dockerfile`:

   ```bash
   cd path/to/project
   ```

> Tips: Bygg alltid med “repeterbarhet” i tankene: pin base image (f.eks. `python:3.12-slim`), og unngå “latest” i produksjon.

---

### macOS (Intel vs Apple Silicon)

#### Terminal (macOS)

Bruk vanlig Terminal eller iTerm.

**Bygg amd64:**

```bash
docker build --platform linux/amd64 -t dockerhub-username/image-name:amd64 .
docker push dockerhub-username/image-name:amd64
```

**Bygg arm64:**

```bash
docker build --platform linux/arm64 -t dockerhub-username/image-name:arm64 .
docker push dockerhub-username/image-name:arm64
```

<div style="page-break-after:always;"></div>

**Viktig på Apple Silicon:**  
Når du bygger `linux/amd64`, vil Docker ofte bruke **emulering (QEMU)**. Det fungerer, men kan være tregere.

---

### Linux

På Linux kjører du dette i shell (bash/zsh).

**Bygg amd64:**

```bash
docker build --platform linux/amd64 -t dockerhub-username/image-name:amd64 .
docker push dockerhub-username/image-name:amd64
```

**Bygg arm64:**

```bash
docker build --platform linux/arm64 -t dockerhub-username/image-name:arm64 .
docker push dockerhub-username/image-name:arm64
```

> Merk: På en “vanlig” Intel/AMD Linux-maskin vil arm64-bygg ofte kreve `buildx`/QEMU (se multi-arch-delen) for å funke smertefritt.

---

### Windows

På Windows kan du bruke:

- **PowerShell**
- **Windows Terminal**
- **Command Prompt (cmd)**

Kommandoene er de samme.

**PowerShell / cmd:**

```powershell
docker build --platform linux/amd64 -t dockerhub-username/image-name:amd64 .
docker push dockerhub-username/image-name:amd64

docker build --platform linux/arm64 -t dockerhub-username/image-name:arm64 .
docker push dockerhub-username/image-name:arm64
```

#### Viktig Windows-notat: Linux containers

I Docker Desktop må du bruke **Linux containers** (standard i nyere Docker Desktop).  
Hvis du ved et uhell kjører Windows-containere, kan plattform/bygg oppføre seg annerledes.

---

## Vanlige feil og hvordan du løser dem

### 1) `exec format error`

**Årsak:** du kjører et image bygget for feil arkitektur.

**Løsning:** bygg riktig `--platform`, eller bruk multi-arch image.

---

### 2) `denied: requested access to the resource is denied`

**Årsak:** du er ikke logget inn eller repo-navn stemmer ikke.

**Sjekk:**

- Har du kjørt `docker login`?
- Er navnet nøyaktig `dockerhub-username/image-name` (og at repoet finnes eller kan opprettes)?

---

### 3) Bygg feiler fordi base image ikke finnes for arkitekturen

Noen base images støtter ikke begge arkitekturer.

**Løsning:**

- Velg et base image som støtter både `amd64` og `arm64` (mange offisielle images gjør det).
- Alternativt, bruk en annen base (f.eks. slim/alpine-varianter eller nyere tag).

---
<div style="page-break-after:always;"></div>

## Anbefalt: multi-arch image med `buildx`

I stedet for å publisere to ulike tags (`:amd64` og `:arm64`), kan du publisere **ett image** (f.eks. `:latest` eller `:1.0.0`) som inneholder en “manifest” med begge arkitekturer.

### Hva er fordelen?

Da kan andre gjøre:

```bash
docker pull dockerhub-username/image-name:latest
```

…og Docker velger automatisk riktig variant for maskinen.

### Multi-arch bygg + push (én kommando)

```bash
docker buildx build \
  --platform linux/amd64,linux/arm64 \
  -t dockerhub-username/image-name:latest \
  --push .
```

**Forklaring:**

- `buildx` bruker “BuildKit” og kan bygge flere arkitekturer.
- `--push` er viktig: multi-arch resultatet legges i registry, ikke bare lokalt.

### Sette opp buildx (hvis nødvendig)

Sjekk builders:

```bash
docker buildx ls
```

Lag og bruk en builder:

```bash
docker buildx create --name multiarch-builder --use
docker buildx inspect --bootstrap
```

Deretter kjør multi-arch-bygg.

> På Docker Desktop (Windows/macOS) fungerer dette ofte “rett ut av boksen”.

---
<div style="page-break-after:always;"></div>

## Sjekk hva du har bygget (verifisering)

### Se lokale images

```bash
docker images
```

### Se detaljer om et image (lokalt)

```bash
docker image inspect dockerhub-username/image-name:amd64
```

### Sjekk arkitektur

Du kan se etter felt som `Architecture` i inspect-output.

### Sjekk remote manifest (nyttig for multi-arch)

```bash
docker buildx imagetools inspect dockerhub-username/image-name:latest
```

Dette viser hvilke plattformer som ligger bak taggen.

---
<div style="page-break-after:always;"></div>

## Praktisk oppskrift: fra null til publisert

### A) To separate tags (enkelt og tydelig)

1. Logg inn:

   ```bash
   docker login
   ```

2. Bygg + push amd64:

   ```bash
   docker build --platform linux/amd64 -t dockerhub-username/image-name:amd64 .
   docker push dockerhub-username/image-name:amd64
   ```

3. Bygg + push arm64:

   ```bash
   docker build --platform linux/arm64 -t dockerhub-username/image-name:arm64 .
   docker push dockerhub-username/image-name:arm64
   ```

Brukere må da velge riktig:

```bash
docker pull dockerhub-username/image-name:amd64
# eller
docker pull dockerhub-username/image-name:arm64
```

---
<div style="page-break-after:always;"></div>

### B) Én tag som funker overalt (anbefalt)

1. Logg inn:

   ```bash
   docker login
   ```

2. Multi-arch build + push:

   ```bash
   docker buildx build --platform linux/amd64,linux/arm64 -t dockerhub-username/image-name:latest --push .
   ```

Brukere gjør bare:

```bash
docker pull dockerhub-username/image-name:latest
```

---
<div style="page-break-after:always;"></div>

## Ekstra tips (best practice)

- Bruk versjonstagger i tillegg til `latest`:
  - `:1.0.0`, `:1.0`, `:latest`
- Hold `Dockerfile` ryddig:
  - cache-vennlig rekkefølge (installer dependencies før kopiering av hele prosjektet)
- Test lokalt:

  ```bash
  docker run --rm -p 8080:8080 dockerhub-username/image-name:amd64
  ```

---

## Mini-cheatsheet

**Bygg amd64**

```bash
docker build --platform linux/amd64 -t USER/REPO:amd64 .
```

**Bygg arm64**

```bash
docker build --platform linux/arm64 -t USER/REPO:arm64 .
```

**Multi-arch**

```bash
docker buildx build --platform linux/amd64,linux/arm64 -t USER/REPO:latest --push .
```
