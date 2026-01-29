# AWS Secrets Manager

## Hva er AWS Secrets Manager?

AWS Secrets Manager er en tjeneste fra Amazon Web Services (AWS) som brukes til å lagre, administrere og hente hemmeligheter ("secrets") som API-nøkler, passord, databasetilkoblingsstrenger og andre sensitive data på en sikker måte.

Secrets Manager tilbyr funksjoner som automatisk rotasjon av hemmeligheter, tilgangskontroll og sikkerhetslogging, noe som bidrar til å redusere risikoen for datalekkasjer og forbedrer sikkerheten i applikasjoner.

---

## Hva brukes AWS Secrets Manager til?

### 1. **Sikker lagring av hemmeligheter**

   Secrets Manager beskytter hemmeligheter ved å kryptere dem med AWS Key Management Service (KMS). Dette sikrer at hemmelighetene ikke lagres i klartekst.

### 2. **Automatisk rotasjon av hemmeligheter**

   Med Secrets Manager kan hemmeligheter som databasenøkler og API-nøkler automatisk roteres i faste intervaller. Dette bidrar til å redusere sikkerhetsrisikoer ved bruk av utdaterte hemmeligheter.

### 3. **Enkel tilgang til hemmeligheter**

   Tjenesten gjør det enkelt for applikasjoner og brukere å hente hemmeligheter ved hjelp av SDK-er, CLI, eller API-er uten behov for hardkoding av sensitive data i kildekoden.

### 4. **Integrasjon med andre AWS-tjenester**

   Secrets Manager kan integreres med tjenester som Amazon RDS, AWS Lambda og Amazon EC2, noe som gjør det enkelt å sikre tilkoblinger til ressurser.

---

## Nøkkelkomponenter i AWS Secrets Manager

### 1. **Secrets**

- En "secret" er selve den sensitive informasjonen, som kan være et passord, en tilkoblingsstreng, eller en API-nøkkel.
- Secrets lagres som JSON-strukturer, noe som gjør det fleksibelt å lagre komplekse hemmeligheter.

### 2. **Secret Versions**

- Hver gang en hemmelighet oppdateres, opprettes en ny versjon. Versjoner kan spores og brukes til å hente tidligere hemmeligheter.

### 3. **Resource-based Policies**

- Tillatelsespolicier definerer hvem som kan få tilgang til hemmeligheter, og hvilke operasjoner de kan utføre (lese, skrive, rotere, etc.).

### 4. **Automatic Rotation**

- Secrets Manager har innebygde funksjoner for å oppdatere hemmeligheter uten manuell intervensjon.
- Dette krever en "Lambda-rotasjonsfunksjon" som implementerer logikken for hvordan hemmeligheten skal oppdateres.

### 5. **AWS SDK og CLI-støtte**

- Secrets Manager støtter AWS SDK-er og CLI, noe som gjør det enkelt å integrere tjenesten med applikasjoner.

---

## Hvordan bruke AWS Secrets Manager i en .NET Core-applikasjon

### Trinn 1: Legg til AWS SDK i prosjektet

Installer AWS SDK for .NET Core:

```bash
Install-Package AWSSDK.SecretsManager
```

### Trinn 2: Konfigurer AWS-legitimasjon

Legg til AWS-legitimasjon i `appsettings.json` eller bruk IAM-roller hvis applikasjonen kjører i AWS:

```json
{
  "AWS": {
    "Region": "eu-west-1",
    "Profile": "default"
  }
}
```

### Trinn 3: Hente en hemmelighet i koden

Her er et eksempel på hvordan du kan hente en hemmelighet fra AWS Secrets Manager:

```csharp
using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        string secretName = "MySecretName";
        string region = "eu-west-1";

        IAmazonSecretsManager client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region));

        try
        {
            GetSecretValueRequest request = new GetSecretValueRequest
            {
                SecretId = secretName
            };

            GetSecretValueResponse response = await client.GetSecretValueAsync(request);

            if (response.SecretString != null)
            {
                Console.WriteLine($"Secret Value: {response.SecretString}");
            }
            else
            {
                Console.WriteLine("Secret is stored as binary.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching secret: {ex.Message}");
        }
    }
}
```

### Trinn 4: Rotasjon av hemmeligheter

Hvis hemmeligheten din krever rotasjon, må du implementere en AWS Lambda-funksjon som tar seg av oppdateringen. Lambda-funksjonen kan opprettes ved hjelp av AWS Console og knyttes til hemmeligheten i Secrets Manager.

---

## Tips for bruk

- **Bruk IAM-roller:** Hvis applikasjonen kjører på EC2, Lambda eller ECS, bruk IAM-roller for å unngå hardkoding av AWS-legitimasjon.
- **Automatiser rotasjon:** Sett opp rotasjon for å forbedre sikkerheten.
- **Loggfør hemmelighetstilgang:** Aktiver CloudTrail for å overvåke hvem som har tilgang til hemmeligheter.

---

Ved å bruke AWS Secrets Manager sikrer du at sensitiv informasjon håndteres på en sikker og effektiv måte, samtidig som du reduserer risikoen for menneskelige feil og datalekkasjer.
