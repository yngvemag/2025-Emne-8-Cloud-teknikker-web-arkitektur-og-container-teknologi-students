# AWS SNS - Simple Notification Service

## Hva er AWS SNS?

AWS Simple Notification Service (SNS) er en fullstendig administrert meldings- og varslingsløsning som gjør det mulig å sende meldinger til flere abonnenter eller systemer samtidig. SNS støtter publisering og abonnementsmønstre ("pub/sub"), og er ideell for distribuert kommunikasjon.

### Egenskaper ved AWS SNS

- **Fullt administrert:** Ingen administrasjon av servere eller infrastruktur.
- **Massedistribusjon:** Lever meldinger til millioner av abonnenter.
- **Støtte for flere protokoller:** Send meldinger via e-post, SMS, mobil push, HTTP(S), eller AWS Lambda.
- **Pålitelig:** Innebygd redundans for høy tilgjengelighet.
- **Sikker:** Meldinger kan krypteres og tilgang kontrolleres via IAM.

## Hva brukes AWS SNS til?

AWS SNS brukes til:

1. **Varslinger:**
   - Sende alarmer eller systemhendelser til utviklere eller applikasjoner.
2. **Meldingsdistribusjon:**
   - Distribuere meldinger til mange mottakere samtidig.
3. **Integrasjon med AWS-tjenester:**
   - Bruke SNS som varslingssystem for Amazon CloudWatch, S3, Lambda, osv.
4. **Brukervarsler:**
   - Sende e-post eller SMS til sluttbrukere.
5. **Automatisering:**
   - Aktivere arbeidsflyter ved å integrere med AWS Lambda.

## Nøkkelkomponenter i AWS SNS

1. **Topic:**
   - Et logisk navngitt emne som fungerer som en mellomliggende kanal mellom utgivere og abonnenter.
   - Produsenter sender meldinger til et "topic", og alle abonnenter på dette emnet mottar meldingen.

2. **Publisher (Utgiver):**
   - En tjeneste eller applikasjon som sender meldinger til et SNS-topic.

3. **Subscriber (Abonnent):**
   - En entitet som mottar meldinger fra et SNS-topic.
   - Eksempler inkluderer e-post, SMS, Lambda-funksjoner, eller HTTP(S)-endepunkter.

4. **Message:**
   - Data som sendes via SNS.
   - Kan være tekst, JSON eller annen strukturert informasjon.

5. **Delivery Policy:**
   - Angir hvordan og hvor ofte meldinger skal sendes til abonnenter.

6. **Access Control:**
   - Bruk IAM-policyer for å administrere tilgang til topics og meldinger.

## Hvordan AWS SNS fungerer

1. En utgiver sender en melding til et SNS-topic.
2. SNS distribuerer meldingen til alle abonnenter som har registrert seg for dette topicet.
3. Abonnenter mottar meldingen via den valgte protokollen (e-post, SMS, Lambda, osv.).

```mermaid
digraph sns_workflow {
    Publisher -> SNS_Topic [label="Publiser melding"];
    SNS_Topic -> Subscriber1 [label="Send til abonnent 1"];
    SNS_Topic -> Subscriber2 [label="Send til abonnent 2"];
    SNS_Topic -> Subscriber3 [label="Send til abonnent 3"];
}
```

## Protokoller støttet av AWS SNS

- **E-post:** Send e-poster til registrerte adresser.
- **SMS:** Lever tekstmeldinger globalt.
- **AWS Lambda:** Utfør serverløs logikk ved mottak av meldinger.
- **HTTP/HTTPS:** Send meldinger til API-er eller webhooks.
- **Amazon SQS:** Kombiner SNS og SQS for meldingsfan-out.

## Typisk bruksmønster

- Distribusjon av alarmer og varslinger.
- Sanntidsoppdateringer for applikasjoner.
- Automatisering av arbeidsflyter via AWS Lambda.
- Masseutsendelser av meldinger eller oppdateringer til brukere.

## Sammenligning med andre tjenester

- **AWS SQS:**
  - SNS er basert på publisering-abonnement og brukes til sanntidsvarsler.
  - SQS brukes til å lagre meldinger i en kø for asynkron behandling.

- **Amazon MQ:**
  - MQ brukes for eldre systemer som krever spesifikke protokoller.
  - SNS er lettere å bruke og integrere med AWS-tjenester.

## Fordeler med AWS SNS

- Enkel å konfigurere og bruke.
- Høy ytelse og skalerbarhet.
- Sømløs integrasjon med andre AWS-tjenester.
- Fleksibilitet til å bruke flere protokoller.

## Begrensninger

- Begrenset meldingstørrelse (256 KB).
- Håndtering av abonnementer krever oppfølging for å unngå utdaterte kontaktpunkter.

AWS SNS er et kraftig verktøy for sanntidskommunikasjon og distribusjon av meldinger, ideelt for distribuerte systemer og varslinger.
