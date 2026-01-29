# AWS ECS (Elastic Container Service)

## Hva er ECS?

Amazon Elastic Container Service (ECS) er en administrert containerorchestreringstjeneste som lar deg kjøre, stoppe og administrere Docker-containere i en klynge. ECS integreres tett med andre AWS-tjenester og gjør det enkelt å distribuere, skalere og overvåke containerbaserte applikasjoner.

---

## Hva brukes ECS til?

1. **Kjøring av containerbaserte applikasjoner**: Administrer applikasjoner pakket som containere uten å måtte sette opp og vedlikeholde en orkestreringsplattform selv.
2. **Mikrotjenester**: Implementer og skaler mikrotjenestearkitekturer.
3. **Batch-jobber**: Kjør batch-prosesser i containere som automatisk skaleres.
4. **Hybrid distribusjon**: Distribuer containere både på skyen og on-premise ved hjelp av AWS Outposts.

---

## Nøkkelkomponenter i ECS

### 1. **Clusters**

- **Hva:** En logisk gruppering av ressurser som EC2-instanser eller Fargate.
- **Bruk:** Alt containerarbeid kjøres innenfor en klynge.

### 2. **Tasks og Task Definitions**

- **Hva:**
  - **Task:** En kjørende forekomst av en beholder eller et sett med beholdere.
  - **Task Definition:** En mal som beskriver hvilke beholdere som skal kjøres og deres konfigurasjon.
- **Bruk:** Definer miljøvariabler, nettverksinnstillinger, og ressursbehov (CPU og minne).

### 3. **Services**

- **Hva:** Tillater deg å kjøre og vedlikeholde et spesifisert antall oppgaver.
- **Bruk:** Oppretthold ønsket antall oppgaver som kjører samtidig og balanser last med en load balancer.

### 4. **Launch Types**

- **Hva:** To alternativer for hvordan containere kjøres.
  - **EC2 Launch Type:**
    - Kjør containere på en klynge av EC2-instanser som du administrerer. Dette gir full kontroll over underliggende infrastruktur, inkludert valg av instanstyper, nettverksoppsett og skalering.
    - **Fordeler:**
      - Full kontroll over infrastrukturen.
      - Mulighet til å bruke reserved instances for å redusere kostnader.
    - **Bruksscenario:** Når du trenger spesifikke nettverksoppsett, egendefinerte EC2-instanser, eller integrasjon med annen EC2-basert infrastruktur.

  - **Fargate Launch Type:**
    - Kjør containere uten å administrere underliggende infrastruktur. AWS håndterer opprettelse, skalering og vedlikehold av maskinressurser.
    - **Fordeler:**
      - Ingen behov for å administrere servere.
      - Skaler automatisk basert på oppgavenes behov.
      - Forenklet kostnadsstyring siden du kun betaler for ressursene hver oppgave bruker.
    - **Bruksscenario:** Når du vil fokusere utelukkende på applikasjoner og oppgaver uten å bekymre deg for infrastrukturen.

- **Hvordan velge:**
  - Bruk **EC2 Launch Type** når du trenger kontroll over serverne og deres konfigurasjoner.
  - Bruk **Fargate Launch Type** når du vil unngå serveradministrasjon og prioriterer enkelhet.

### 5. **Container Agent**

- **Hva:** Programvare som kjører på EC2-instanser og lar dem kommunisere med ECS.
- **Bruk:** Sikrer at oppgaver distribueres og overvåkes på EC2-instanser.

### 6. **Elastic Load Balancing (ELB)**

- **Hva:** Fordeler trafikk til oppgaver som kjører i ECS.
- **Bruk:** Sikrer høy tilgjengelighet og jevn trafikkfordeling.

### 7. **IAM Policies og Rollen**

- **Hva:** Gir tillatelser for ressurser og tjenester i ECS.
- **Bruk:** Administrer tilgang til beholdere, loggføring, og nettverksressurser.

### 8. **ECS Anywhere**

- **Hva:** Tillater deg å kjøre og administrere containere på lokale maskiner eller andre skyløsninger.
- **Bruk:** Ideelt for hybrid- og multisky-løsninger.

---

## Typiske scenarier

- **Webapplikasjoner**: Drift av containerbaserte webapplikasjoner ved hjelp av ELB.
- **Dataanalyse**: Kjør beholdere som analyserer data i parallelle batch-jobber.
- **Maskinlæring**: Distribuer modeller pakket som containere.
- **CI/CD-pipelines**: Bygg og distribuer containere raskt ved bruk av automatiserte verktøy som AWS CodePipeline.

---

## Fordeler med ECS

- **Fullt administrert**: AWS håndterer infrastruktur og orkestrering.
- **Integrasjon**: Sømløst integrert med AWS-tjenester som CloudWatch, IAM og ELB.
- **Fleksibilitet**: Velg mellom EC2- eller Fargate-basert distribusjon.
- **Skalerbarhet**: Skaler opp eller ned oppgaver basert på trafikk eller ressurskrav.
- **Kostnadseffektivitet**: Betal kun for de ressursene du bruker.

---
