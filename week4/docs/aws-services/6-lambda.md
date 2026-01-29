# AWS Lambda

## Hva er AWS Lambda?

AWS Lambda er en serverløs databehandlingstjeneste som lar deg kjøre kode uten å administrere servere. Lambda kjører koden din som svar på hendelser og administrerer den underliggende infrastrukturen automatisk. Du betaler kun for datakapasitet som brukes under utførelse av koden.

---

## Hva brukes AWS Lambda til?

1. **Hendelsesdrevet behandling**: Kjør kode som svar på hendelser fra tjenester som S3, DynamoDB, Kinesis, eller API Gateway.
2. **Automatisering**: Utfør oppgaver som sikkerhetskopiering, databehandling, eller systemvedlikehold.
3. **API-er**: Bygg serverløse API-er ved å kombinere Lambda med API Gateway.
4. **Databehandling**: Behandle store datasett i sanntid med hendelser fra Kinesis eller S3.
5. **Integrasjoner**: Koble til tredjeparts tjenester eller AWS-tjenester som DynamoDB og SQS.

---

## Nøkkelkomponenter i AWS Lambda

### 1. **Functions**

- **Hva:** Koden du ønsker å kjøre.
- **Bruk:** Last opp eller skriv kode direkte i Lambda. Støtter språk som Python, Node.js, Java, Go, .NET, og Ruby.

### 2. **Triggers**

- **Hva:** Hendelser som starter en Lambda-funksjon.
- **Bruk:** Integrer med tjenester som S3 (opplastninger), DynamoDB (tabellendringer), eller API Gateway (API-kall).

### 3. **Execution Role**

- **Hva:** IAM-rolle som gir Lambda tillatelser til å samhandle med andre AWS-tjenester.
- **Bruk:** Gi funksjonen tilgang til å lese/skrive til tjenester som S3 eller DynamoDB.

### 4. **Layers**

- **Hva:** Del bibliotek, avhengigheter eller annen delt kode mellom flere funksjoner.
- **Bruk:** Reduser duplisering av kode og forenkle vedlikehold.

### 5. **Concurrency**

- **Hva:** Antall samtidige kjøringer av en funksjon.
- **Bruk:** Administrer ytelse og kostnader ved å begrense eller øke samtidighet.

### 6. **Event Source Mappings**

- **Hva:** Automatisk trigging av funksjoner fra tjenester som SQS, DynamoDB Streams eller Kinesis.
- **Bruk:** Behandle meldinger eller datastrømmer i sanntid.

### 7. **Logs og Monitoring**

- **Hva:** CloudWatch Logger og Metrics for å overvåke funksjonens ytelse.
- **Bruk:** Identifiser feil, optimaliser ytelse, og overvåk ressursbruk.

### 8. **Environment Variables**

- **Hva:** Nøkkel-verdi par som brukes i funksjonen.
- **Bruk:** Konfigurer funksjoner uten å endre koden.

---

## Typiske scenarier

- **Bildeprosessering**: Behandle bilder lastet opp til S3 ved å generere miniatyrbilder.
- **Real-time dataanalyse**: Prosesser datastrømmer fra Kinesis eller DynamoDB.
- **Serverløse API-er**: Bygg API-er med API Gateway og Lambda.
- **Chatbots**: Implementer chatbots som behandler meldinger via Lambda.
- **Automatiserte oppgaver**: Slett eldre filer i S3 eller oppdater dynamiske konfigurasjoner.

---

## Fordeler med AWS Lambda

- **Ingen serveradministrasjon**: Ingen behov for å administrere infrastruktur.
- **Skalerbarhet**: Skalerer automatisk basert på antall innkommende hendelser.
- **Kostnadseffektivitet**: Betal kun for brukstid. Ingen kostnader for inaktivitet.
- **Fleksibilitet**: Støtter flere programmeringsspråk og brukstilfeller.
- **Integrasjon**: Sømløst integrert med de fleste AWS-tjenester.

---

## Kom i gang med AWS Lambda

1. **Opprett en Lambda-funksjon:**
   - Velg et programmeringsspråk.
   - Last opp kode eller skriv den direkte i AWS-konsollen.

2. **Konfigurer en trigger:**
   - Koble funksjonen til en hendelseskilde som S3 eller API Gateway.

3. **Test funksjonen:**
   - Bruk en testhendelse for å bekrefte funksjonaliteten.

4. **Distribuer:**
   - Bruk funksjonen i produksjon ved å koble den til ønskede hendelseskilder.

5. **Overvåk og optimaliser:**
   - Bruk CloudWatch Logger og Metrics for å overvåke og forbedre ytelsen.

---

AWS Lambda gir deg muligheten til å bygge fleksible, skalerbare og kostnadseffektive applikasjoner uten å måtte bekymre deg for underliggende infrastruktur.
