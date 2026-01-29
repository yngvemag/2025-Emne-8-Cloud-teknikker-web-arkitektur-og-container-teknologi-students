# AWS VPC (Virtual Private Cloud)

## Hva er en VPC?

En Virtual Private Cloud (VPC) er en isolert del av AWS-skyen som du kan bruke til å lansere ressurser som EC2-instanser, RDS-databaser, og andre tjenester. Den gir deg kontroll over nettverksinnstillinger som IP-adresser, subnett, og rutetabeller, og lar deg definere en virtuell nettverksarkitektur som ligner et tradisjonelt datanettverk i en on-premise infrastruktur.

---

## Hva brukes en VPC til?

1. **Isolasjon og sikkerhet**: VPC isolerer ressursene dine fra andre kunders ressurser i AWS-skyen.
   - Du kan bruke sikkerhetsgrupper og nettverkstilgangskontrollister (NACLs) for å begrense tilgang.
2. **Tilpasset nettverk**: Du kan konfigurere subnett, private og offentlige IP-adresser, og nettverksruting for å passe dine applikasjoner.
3. **Hybrid skyarkitektur**: Med VPN eller AWS Direct Connect kan du koble VPC-en til ditt lokale nettverk for en hybrid infrastruktur.
4. **Regelstyrt trafikk**: Bruk rutetabeller og gateway-konfigurasjoner for å kontrollere utgående og innkommende trafikk.

---

## Nøkkelkomponenter i en VPC

### 1. **Subnets**

- **Hva:** Deler opp VPC-en i mindre nettverkssegmenter.
- **Bruk:**
  - Offentlige subnett: For ressurser som trenger internett-tilgang (f.eks. webservere).
  - Private subnett: For ressurser som ikke skal eksponeres mot internett (f.eks. databaser).

### 2. **Route Tables**

- **Hva:** Bestemmer hvordan trafikk dirigeres innenfor VPC-en og til andre nettverk.
- **Bruk:**
  - Legg til ruter for å definere kommunikasjon mellom subnett.
  - Opprett tilkoblinger til internett, VPN, eller andre VPC-er.

### 3. **Internet Gateway (IGW)**

- **Hva:** En komponent som muliggjør kommunikasjon mellom VPC og internett.
- **Bruk:** Koble offentlige subnett til internett.

### 4. **NAT Gateway**

- **Hva:** Gir private subnett mulighet til å sende trafikk til internett uten å bli eksponert direkte.
- **Bruk:** Brukes av ressurser i private subnett for å laste ned oppdateringer eller sende ut data.

### 5. **Elastic IP (EIP)**

- **Hva:** En statisk offentlig IP-adresse som kan knyttes til ressurser i VPC-en.
- **Bruk:** Sikrer at en ressurs alltid har en kjent IP-adresse for kommunikasjon med internett.

### 6. **Security Groups**

- **Hva:** Virtuelle brannmurer for ressurser i VPC-en.
- **Bruk:** Tillater eller blokkerer innkommende og utgående trafikk basert på regler.

### 7. **Network Access Control Lists (NACLs)**

- **Hva:** Et ekstra lag med sikkerhet for subnett i VPC-en.
- **Bruk:** Tilbyr stateless kontroll over trafikk til og fra subnett.

### 8. **VPC Peering**

- **Hva:** Lar deg koble to VPC-er for å dele ressurser.
- **Bruk:** For applikasjoner som spenner over flere VPC-er.

### 9. **Virtual Private Gateway (VGW)**

- **Hva:** Brukes til å koble VPC-en til ditt lokale nettverk via VPN.
- **Bruk:** Til hybrid skyarkitekturer.

### 10. **Endpoints**

- **Hva:** Gjør det mulig å koble til AWS-tjenester uten å gå via internett.
- **Bruk:** For sikker tilgang til tjenester som S3 og DynamoDB fra innenfor VPC.

---

## Typiske scenarier

- **Hosting av applikasjoner**: Kjør web- og applikasjonsservere i offentlige subnett, og databaser i private subnett.
- **Dataanalyse**: Bruk VPC-en til å kjøre databehandlingstjenester som Amazon EMR i et isolert miljø.
- **Hybrid sky**: Utvid din on-premise infrastruktur ved å koble den til VPC-en din via VPN eller Direct Connect.

---

## Fordeler med VPC

- **Sikkerhet**: Kontroll over nettverksadgang og kommunikasjon.
- **Skalerbarhet**: Tilpass nettverksinfrastrukturen etter behov.
- **Kostnadseffektivitet**: Betal kun for de ressursene du bruker.

---
