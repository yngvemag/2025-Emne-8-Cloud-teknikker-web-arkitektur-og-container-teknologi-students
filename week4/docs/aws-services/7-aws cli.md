# AWS CLI (Command Line Interface)

## Hva er AWS CLI?

AWS Command Line Interface (CLI) er et verktøy som lar deg administrere AWS-tjenester direkte fra kommandolinjen. CLI gir deg muligheten til å samhandle med AWS via skript og automatisering, i stedet for å bruke AWS Management Console.

---

## Hvordan installere AWS CLI

### Windows

1. Last ned AWS CLI fra den offisielle [nedlastingssiden](https://aws.amazon.com/cli/).
   [Download (windows)](https://awscli.amazonaws.com/AWSCLIV2.msi)
2. Kjør installasjonsprogrammet.
3. Verifiser installasjonen ved å skrive:

   ```bash
   aws --version
   ```

### macOS

1. Installer AWS CLI med Homebrew:

   ```bash
   brew install awscli
   ```

2. Verifiser installasjonen:

   ```bash
   aws --version
   ```

### Linux

1. Last ned installasjonsfilen:

   ```bash
   curl "https://awscli.amazonaws.com/awscli-exe-linux-x86_64.zip" -o "awscliv2.zip"
   ```

2. Pakk ut filen:

   ```bash
   unzip awscliv2.zip
   ```

3. Installer CLI:

   ```bash
   sudo ./aws/install
   ```

4. Verifiser installasjonen:

   ```bash
   aws --version
   ```

---

## Sette opp AWS CLI

1. **Konfigurer CLI med Access Key og Secret Key:**

   ```bash
   aws configure
   ```

   - **Spørsmål du vil bli stilt:**
     1. AWS Access Key ID: *Skriv inn din Access Key ID*
     2. AWS Secret Access Key: *Skriv inn din Secret Access Key*
     3. Default region name: *Velg region (f.eks. us-east-1)*
     4. Default output format: *Velg JSON, table, eller text*

2. **Valider konfigurasjonen:**
   Sjekk at CLI er riktig konfigurert ved å liste S3-bøtter:

   ```bash
   aws s3 ls
   ```

---

## Eksempel på kommandoer

### EC2

| Tjeneste | Kommando | Beskrivelse |
|----------|----------|-------------|
| EC2 | `aws ec2 describe-instances` | Viser informasjon om EC2-instanser |
| EC2 | `aws ec2 start-instances --instance-ids i-1234567890abcdef0` | Starter en spesifikk EC2-instans |
| EC2 | `aws ec2 stop-instances --instance-ids i-1234567890abcdef0` | Stopper en spesifikk EC2-instans |
| EC2 | `aws ec2 terminate-instances --instance-ids i-1234567890abcdef0` | Avslutter en spesifikk EC2-instans |

### ECR

| Tjeneste | Kommando | Beskrivelse |
|----------|----------|-------------|
| ECR | `aws ecr describe-repositories` | Viser informasjon om ECR-repositorier |
| ECR | `aws ecr get-login --no-include-email` | Henter en autentiserings-token for å logge på ECR |
| ECR | `aws ecr create-repository --repository-name my-repo` | Oppretter et nytt ECR-repositorium |

### ECS

| Tjeneste | Kommando | Beskrivelse |
|----------|----------|-------------|
| ECS | `aws ecs list-clusters` | Lister ECS-klustre |
| ECS | `aws ecs describe-clusters --clusters my-cluster` | Viser informasjon om et spesifikt ECS-kluster |
| ECS | `aws ecs update-service --cluster my-cluster --service my-service --desired-count 3` | Oppdaterer en tjeneste i et ECS-kluster |

### S3

| Tjeneste | Kommando | Beskrivelse |
|----------|----------|-------------|
| S3 | `aws s3 ls` | Lister alle S3-bøtter |
| S3 | `aws s3 cp my-file.txt s3://my-bucket` | Kopierer en fil til en S3-bøtte |

### IAM

| Tjeneste | Kommando | Beskrivelse |
|----------|----------|-------------|
| IAM | `aws iam list-users` | Lister IAM-brukere |
| IAM | `aws iam create-user --user-name new-user` | Oppretter en ny IAM-bruker |

---

Ved å bruke AWS CLI kan du effektivt administrere AWS-tjenester og bygge automatiserte arbeidsflyter for infrastrukturadministrasjon. Dette gir deg økt fleksibilitet og effektivitet i skyarbeidet ditt.
