# AWS ECR (Elastic Container Registry)

## Hva er ECR?

Amazon Elastic Container Registry (ECR) er en fullt administrert containerregistertjeneste som lar deg lagre, dele og administrere containerbilder. ECR integreres sømløst med Amazon Elastic Container Service (ECS), Amazon Elastic Kubernetes Service (EKS) og andre Docker-arbeidsflyter, noe som forenkler prosessen med å distribuere containerbaserte applikasjoner.

---

## Hva brukes ECR til?

1. **Lagring av containerbilder**: Sikre lagring for Docker-bilder som brukes i produksjon, utvikling og testing.
2. **Integrasjon med orkestreringstjenester**: Brukes sammen med ECS og EKS for å levere containerbilder.
3. **Deling av bilder**: Gjør det enkelt å dele containerbilder mellom team og applikasjoner.
4. **CI/CD-pipelines**: Automatiser bygg, testing og distribusjon av containerbaserte applikasjoner.

---

## Nøkkelkomponenter i ECR

### 1. **Repositories**

- **Hva:** Lagringsplass for containerbilder.
- **Bruk:** Organiser bilder etter applikasjon, versjon eller miljø (f.eks. `webapp`, `api-service`, `test-environment`).

### 2. **Docker Images**

- **Hva:** Containerbilder som inneholder applikasjonens kode, avhengigheter og miljø.
- **Bruk:** Last opp, hent og distribuer bilder som brukes av containerorkestreringstjenester.

### 3. **Image Tagging**

- **Hva:** Versjonskontroll av bilder ved hjelp av tags.
- **Bruk:** Bruk tags som `latest`, `v1.0`, eller `release-candidate` for enkel administrasjon.

### 4. **Access Management**

- **Hva:** Kontroll av tilgang til repositories og bilder.
- **Bruk:** Bruk AWS IAM for å gi spesifikke tillatelser til team og tjenester.

### 5. **Image Scanning**

- **Hva:** Sikkerhetsfunksjon som oppdager sårbarheter i containerbilder.
- **Bruk:** Skann bilder automatisk for å identifisere potensielle sikkerhetsproblemer før distribusjon.

### 6. **Lifecycle Policies**

- **Hva:** Regler for automatisk styring av gamle eller ubrukte bilder.
- **Bruk:** Behold kun de nyeste eller mest relevante bildene for å spare lagringsplass.

---

## Typiske scenarier

- **Produksjonsdistribusjon**: Lagring og henting av containerbilder som brukes av ECS eller EKS.
- **Utviklingsmiljøer**: Deling av Docker-bilder mellom utviklingsteam for testing og iterasjon.
- **CI/CD-pipelines**: Automatisert prosess for bygging og pushing av containerbilder til ECR.
- **Sikkerhet og samsvar**: Bruk image scanning for å sikre at bilder oppfyller sikkerhetsstandarder.

---

## Fordeler med ECR

- **Fullt administrert**: AWS håndterer underliggende infrastruktur for registeret.
- **Høy tilgjengelighet**: Sikrer pålitelig lagring og tilgang til containerbilder.
- **Integrasjon**: Sømløst integrert med andre AWS-tjenester som ECS, EKS, og CodePipeline.
- **Sikkerhet**: Bruk IAM-policyer og image scanning for å beskytte bildene.
- **Skalerbarhet**: Støtter lagring og distribusjon av et stort antall bilder.

---

## Kom i gang med ECR

1. **Opprett et repository:**

   ```bash
   aws ecr create-repository --repository-name <repository-name>
   ```

2. **Logg inn i ECR:**

   ```bash
   aws ecr get-login-password --region <region> | docker login --username AWS --password-stdin <aws_account_id>.dkr.ecr.<region>.amazonaws.com
   ```

3. **Bygg og tag et bilde:**

   ```bash
   docker build -t <image-name> .
   docker tag <image-name>:latest <aws_account_id>.dkr.ecr.<region>.amazonaws.com/<repository-name>:latest
   ```

4. **Push bildet til ECR:**

   ```bash
   docker push <aws_account_id>.dkr.ecr.<region>.amazonaws.com/<repository-name>:latest
   ```

5. **Bruk bildet i ECS eller EKS:** Konfigurer containerorkestreringstjenester til å hente bilder fra ECR.

---

Ved å bruke ECR kan du effektivt administrere containerbilder og integrere dem i skybaserte arbeidsflyter.
