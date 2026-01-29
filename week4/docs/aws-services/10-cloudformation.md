# AWS CloudFormation

## Hva er AWS CloudFormation?

AWS CloudFormation er en infrastruktur-som-kode (IaC) tjeneste som lar deg definere og administrere AWS-ressurser ved hjelp av skriptbare malfiler (templates). Ved å bruke CloudFormation kan du automatisk opprette, oppdatere og slette AWS-infrastruktur på en konsistent og repeterbar måte.

### Egenskaper ved AWS CloudFormation

- **Automatisering:** Opprett, oppdater og slett AWS-ressurser programmatisk.
- **Deklarativ tilnærming:** Beskriv ønsket infrastrukturtilstand i en mal (YAML eller JSON).
- **Infrastruktur-som-kode (IaC):** Håndter AWS-ressurser som kode, noe som forbedrer versjonskontroll og samarbeid.
- **Rollback-mekanisme:** Automatisk tilbakeføring ved feil under opprettelse eller oppdatering av ressurser.
- **Integrasjon med DevOps:** Kan kombineres med CI/CD-verktøy som AWS CodePipeline og Terraform.

## Nøkkelkomponenter i AWS CloudFormation

1. **Stack**
   - En samling av AWS-ressurser som er administrert som én enhet.
   - Opprettet basert på en **CloudFormation-template**.
   - Endringer i stacken håndteres ved hjelp av oppdateringer.

2. **Template**
   - En deklarativ fil skrevet i **YAML** eller **JSON** som definerer AWS-ressurser og konfigurasjoner.
   - Inneholder seksjoner som **Resources**, **Parameters**, **Outputs**, osv.

3. **Resources**
   - Hoveddelen av en CloudFormation-template.
   - Definerer AWS-ressurser som EC2, S3, RDS, Lambda, VPC, osv.

4. **Parameters**
   - Tillater inndata fra brukeren for å gjøre malene mer dynamiske.
   - Eksempel: Definere en database-instansstørrelse som en parameter.

5. **Outputs**
   - Viser verdier fra stacken etter opprettelse.
   - Brukes for å hente verdier som **ARN**, **IP-adresser**, eller **eksporterte variabler**.

6. **Mappings**
   - Lar deg definere faste verdier basert på region eller miljø.
   - Nyttig for konfigurasjoner som varierer basert på AWS-region.

7. **Conditions**
   - Brukes til å aktivere eller deaktivere ressurser basert på spesifikke betingelser.
   - Eksempel: Opprettelse av ressurser kun hvis miljøet er "Production".

8. **Change Sets**
   - Viser foreslåtte endringer før oppdatering av en stack.
   - Gir oversikt over hvordan en oppdatering vil påvirke eksisterende ressurser.

## Hva brukes AWS CloudFormation til?

AWS CloudFormation brukes til:

1. **Automatisert infrastrukturhåndtering:**
   - Opprette og administrere AWS-ressurser uten manuell konfigurering.
2. **DevOps og CI/CD:**
   - Automatisere miljøopprettelse i utviklings- og produksjonsmiljøer.
3. **Sikkerhetskontroll:**
   - Implementere sikkerhetskonfigurasjoner som IAM-policyer og VPC-oppsett.
4. **Multi-region og multi-konto distribusjon:**
   - Rulle ut identiske ressurser på tvers av AWS-regioner og kontoer.
5. **Skalerbare applikasjoner:**
   - Definere lastbalansering, autoskalering, og databaseoppsett i én template.

## Eksempel på en CloudFormation-template

Nedenfor er en enkel CloudFormation-template for å opprette en S3-bucket:

```yaml
AWSTemplateFormatVersion: '2010-09-09'
Resources:
  MyS3Bucket:
    Type: 'AWS::S3::Bucket'
    Properties:
      BucketName: my-cloudformation-bucket
Outputs:
  BucketName:
    Value: !Ref MyS3Bucket
    Description: "Navnet på den opprettede S3-bucketen."
```

## Fordeler med AWS CloudFormation

- **Automatisert ressursopprettelse**: Ingen manuell oppsett nødvendig.
- **Skalerbarhet**: Enkel kloning av infrastruktur på tvers av miljøer.
- **Sikkerhet og revisjon**: Endringer kan spores gjennom versjonskontroll.
- **Tidsbesparende**: Reduserer feil og manuelle konfigurasjonsprosesser.

## Begrensninger

- **Kompleksitet**: Store CloudFormation-mal kan bli vanskelig å håndtere.
- **Ressursavhengigheter**: Feil i én ressurs kan føre til rollback av hele stacken.
- **Begrenset støtte for tredjepartsverktøy**: Ikke like fleksibel som Terraform for ikke-AWS tjenester.

AWS CloudFormation er et kraftig verktøy for å administrere AWS-infrastruktur på en organisert og repeterbar måte. Det passer spesielt godt for DevOps-team og organisasjoner som ønsker skalerbarhet og automasjon i sin skyinfrastruktur.
