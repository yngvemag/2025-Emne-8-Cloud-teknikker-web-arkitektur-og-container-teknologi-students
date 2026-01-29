# AWS RDS - Relational Database Service

## Hva er AWS RDS?

AWS Relational Database Service (RDS) er en administrert databaseplattform som gjør det enkelt å sette opp, operere og skalere relasjonsdatabaser i skyen. Tjenesten håndterer oppgaver som maskinvareadministrasjon, databaseoppdateringer, sikkerhetskopiering, og høy tilgjengelighet.

### Egenskaper ved AWS RDS

- **Fullt administrert:** AWS håndterer databaseadministrasjon som sikkerhetskopiering, oppdateringer, og skalering.
- **Flere databasevalg:** Støtte for databaser som MySQL, PostgreSQL, MariaDB, Oracle, Microsoft SQL Server og Amazon Aurora.
- **Skalerbart:** Støtte for vertikal og horisontal skalering.
- **Sikker:** Kryptering av data i hvilemodus og i transit, IAM-integrasjon for tilgangskontroll.
- **Høy tilgjengelighet:** Muligheter for Multi-AZ distribusjon for failover.

## Hva brukes AWS RDS til?

AWS RDS brukes til:

1. **Webapplikasjoner:**
   - Håndtere backend-databaser for web- og mobilapplikasjoner.
2. **ERP-systemer:**
   - Administrere store mengder strukturert data for forretningsapplikasjoner.
3. **Dataanalyse:**
   - Bruke RDS-databaser som kilde for analyser i data lakes.
4. **SaaS-applikasjoner:**
   - Støtte multi-tenant arkitekturer med dedikerte databaser.

## Nøkkelkomponenter i AWS RDS

1. **Database Engine:**
   - Velg mellom MySQL, PostgreSQL, MariaDB, Oracle, SQL Server, eller Aurora.

2. **DB Instance:**
   - Den primære ressursen i RDS som representerer den kjørende databasen.

3. **Multi-AZ Deployment:**
   - Replikerer databasen synkront på tvers av flere tilgjengelighetssoner for høy tilgjengelighet.

4. **Read Replica:**
   - Oppretter replikaer av databasen for å håndtere leseintensive arbeidsmengder.

5. **Backup og Restore:**
   - Automatisk daglig sikkerhetskopiering og manuelle sikkerhetskopier for gjenoppretting.

6. **Monitoring:**
   - Integrasjon med Amazon CloudWatch for overvåking av ytelse og helsetilstand.

7. **Security:**
   - Bruk IAM-roller for tilgangskontroll.
   - Støtte for VPC for nettverksisolasjon.

## Hvordan AWS RDS fungerer

1. Velg en database engine og konfigurer en DB Instance.
2. AWS oppretter og administrerer infrastrukturen.
3. Databasen kan kobles til via en applikasjon eller verktøy.
4. Bruk Multi-AZ og read replicas for skalerbarhet og redundans.

```mermaid
graph TD
    A[Web Application] -->|Query| B[RDS Primary DB]
    B -->|Read| C[Read Replica]
    B -->|Backup| D[Daily Backup]
    B -->|Failover| E[Secondary Instance (Multi-AZ)]
```

## Fordeler med AWS RDS

- **Reduserer administrasjon:** Minimerer behovet for databaseadministrasjon.
- **Skalerbarhet:** Tilpass ressursene etter arbeidsmengde.
- **Sikkerhet:** Kryptering og VPC-støtte beskytter data.
- **Pålitelighet:** Muligheter for automatisk failover med Multi-AZ.

## Begrensninger

- **Kostnad:** Kan bli dyrere sammenlignet med selvadministrerte databaser ved høye arbeidsmengder.
- **Begrenset tilgang:** Mindre fleksibilitet i konfigurasjon sammenlignet med selvadministrerte løsninger.
- **Regionbasert:** Data er låst til en spesifikk region med mindre du bruker replikering på tvers av regioner.

## Sammenligning med andre AWS-tjenester

- **DynamoDB:**
  - RDS er relasjonsbasert og bruker SQL, mens DynamoDB er en nøkkel-verdi database som er ikke-relasjonsbasert.
- **Amazon Redshift:**
  - Redshift er designet for datalagring og analyse, mens RDS er optimalisert for transaksjonsbehandling.

## Typisk bruksmønster

- **OLTP-systemer:**
  - Ideelt for applikasjoner som krever raske transaksjoner.
- **Flere brukere:**
  - Bruk read replicas for applikasjoner med mange samtidige brukere.
- **Automatisk skalering:**
  - Aurora Serverless muliggjør dynamisk skalering uten manuell intervensjon.

AWS RDS er et robust verktøy for å håndtere relasjonsdatabaser i skyen, og det gjør det enklere å administrere, skalere og sikre databaser med minimalt vedlikehold.
