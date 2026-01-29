# AWS CloudWatch

## Hva er AWS CloudWatch?

Amazon CloudWatch er en overvåkning og administrasjonstjeneste for AWS-ressurser og applikasjoner. Den gir innsyn i systemytelse, ressursutnyttelse og applikasjonsloggdata, og hjelper deg med å reagere raskt på problemer og optimalisere ressursbruk.

---

## Hva brukes AWS CloudWatch til?

1. **Overvåking**: Følg med på metrikker som CPU-bruk, minneutnyttelse, disk I/O, og nettverksaktivitet for AWS-ressurser.
2. **Logganalyse**: Samle og analyser applikasjons- og systemlogger for å feilsøke problemer.
3. **Automatisering**: Konfigurer alarmer og handlinger som automatisk skalerer ressurser eller sender varsler.
4. **Systemarkitekturvisualisering**: Bruk dashboards for å få oversikt over systemytelse og helsestatus i sanntid.
5. **Kostnadskontroll**: Optimaliser ressursbruk ved å identifisere ineffektive tjenester.

---

## Viktige komponenter i CloudWatch

### 1. **Metrikker**

- **Hva:** Måleverdier som sporer helsestatus og ytelse for AWS-ressurser.
- **Eksempler:**
  - EC2: CPU-utnyttelse, nettverksinngang/-utgang.
  - RDS: Databasekoblinger, lagringsutnyttelse.
  - Lambda: Antall forespørsler, varighet.

### 2. **Logggrupper og Loggstrømmer**

- **Hva:** Samling av loggdata fra applikasjoner og ressurser.
- **Bruk:** Analyser applikasjonsoppførsel og feilsøk problemer.
- **Eksempel:** Behandle webserverlogger eller applikasjonslogger.

### 3. **Alarmer**

- **Hva:** Varsler deg når en metrikk går utenfor definerte grenser.
- **Bruk:**
  - Send e-post via Amazon SNS.
  - Utfør handlinger som å starte en EC2-instans eller skalere tjenester.

### 4. **Dashboards**

- **Hva:** Visuelle representasjoner av metrikker og logger.
- **Bruk:** Opprett tilpassede dashbord for å overvåke spesifikke applikasjoner eller ressurser.
- **Eksempel:** Se CPU-bruk for flere EC2-instanser på ett sted.

### 5. **Events (CloudWatch Events)**

- **Hva:** Hendelsesbaserte handlinger.
- **Bruk:**
  - Start Lambda-funksjoner.
  - Send varsler.
  - Utfør handlinger basert på endringer i AWS-ressurser.

### 6. **Insights**

- **Hva:** Avanserte søk og analyseverktøy for loggdata.
- **Bruk:** Utfør komplekse søk for å identifisere mønstre og feil i loggene.

### 7. **Syntetiske overvåkninger (CloudWatch Synthetics)**

- **Hva:** Opprett syntetiske tester for applikasjonsytelse og tilgjengelighet.
- **Bruk:** Kontroller at API-er og sluttpunkter fungerer som forventet.

### 8. **ServiceLens**

- **Hva:** Tilbyr innsikt i applikasjonsytelse ved å kombinere CloudWatch Logs, Traces og Metrikker.
- **Bruk:** Spor applikasjonsflyt og feilsøk ytelsesproblemer.

---

## Typiske scenarier

- **Overvåking av EC2-instanser**: Følg med på CPU- og minnebruk for å unngå overbelastning.
- **Feilsøking av applikasjonsfeil**: Analyser applikasjonslogger for å identifisere og løse problemer raskt.
- **Kostnadsoptimalisering**: Identifiser underbrukte ressurser og optimaliser arbeidsbelastninger.
- **Automatisk skalering**: Bruk alarmer til å skalere opp eller ned ressurser automatisk.

---

## Fordeler med AWS CloudWatch

1. **Sentralt overvåkningsverktøy**: Gir innsikt i hele AWS-miljøet.
2. **Automatisering**: Reduser manuelt arbeid ved å konfigurere automatiske handlinger.
3. **Kostnadseffektivitet**: Optimaliser ressursutnyttelse og reduser kostnader.
4. **Sikkerhet**: Overvåk logger for uvanlig aktivitet og identifiser potensielle sikkerhetsbrudd.
5. **Fleksibilitet**: Tilpass overvåkningen til å passe spesifikke applikasjonsbehov.

---

AWS CloudWatch er et kraftig verktøy for overvåking, feilsøking og optimalisering av applikasjoner og AWS-ressurser. Ved å utnytte de forskjellige komponentene kan du bygge et robust system for å administrere og vedlikeholde skyinfrastrukturen din.
