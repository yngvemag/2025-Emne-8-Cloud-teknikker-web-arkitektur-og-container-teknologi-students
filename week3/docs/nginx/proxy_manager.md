# Introduksjon til Nginx Proxy Manager

## Hva er Nginx Proxy Manager?

Nginx Proxy Manager er et brukervennlig verktøy som forenkler oppsett og administrasjon av en Nginx-reverse proxy. Det tilbyr en grafisk brukergrensesnitt (GUI) som gjør det enkelt å konfigurere proxy-regler, SSL-sertifikater, videresending av domener og mer.

### Funksjoner

- Enkel oppsett av reverse proxy-regler.
- Støtte for gratis SSL-sertifikater via Let's Encrypt.
- Administrasjon av flere domener.
- Mulighet til å legge til tilgangskontroll for tjenester.
- Dynamisk videresending av HTTP/HTTPS.

---

## Hva kan det brukes til?

Nginx Proxy Manager kan brukes til en rekke bruksområder, inkludert:

- **Reverse Proxy**: Videresending av trafikk fra et domene til en spesifikk applikasjon eller tjeneste som kjører på en annen port eller server.
- **SSL-håndtering**: Enkelt å legge til SSL-sertifikater for å sikre webtrafikken.
- **Flere domener og tjenester**: Administrere flere applikasjoner på samme server ved hjelp av forskjellige domener/subdomener.
- **Tilgangskontroll**: Begrense tilgangen til spesifikke applikasjoner ved hjelp av autentisering.

---

## Hvorfor bruke Nginx Proxy Manager?

- **Brukervennlighet**: GUI-en gjør det enkelt å administrere komplekse proxy-konfigurasjoner.
- **SSL-håndtering**: Automatisk opprettelse og fornyelse av Let's Encrypt-sertifikater.
- **Sentralisert administrasjon**: Mulighet for å administrere flere tjenester og domener fra én enkelt plass.
- **Tidseffektivt**: Reduserer kompleksiteten i oppsett og vedlikehold av Nginx.
- **Tilpasningsmuligheter**: Støtte for avanserte Nginx-konfigurasjoner når det er nødvendig.

---

## Hvordan sette opp Nginx Proxy Manager som en Reverse Proxy

Her er en kort guide basert på [Nginx Proxy Manager dokumentasjonen](https://nginxproxymanager.com/guide/#quick-setup):

### **1. Krav**

- En server som kjører Docker og Docker Compose.
- Basiskunnskap om nettverk og domenenavn.

### **2. Hurtigoppsett med Docker Compose**

Opprett en `docker-compose.yml`-fil med følgende innhold:

```yaml
version: '3'
services:
  app:
    image: 'jc21/nginx-proxy-manager:latest'
    restart: unless-stopped
    ports:
      - '80:80'       # HTTP-port
      - '81:81'       # Admin-GUI-port
      - '443:443'     # HTTPS-port
    volumes:
      - ./data:/data  # Data for Nginx Proxy Manager
      - ./letsencrypt:/etc/letsencrypt  # SSL-sertifikater
```

### **3. Start Proxy Manager**

Kjør følgende kommando for å starte tjenesten:

```bash
docker-compose up -d
```

### **4. Åpne Admin-GUI**

- Gå til `http://<server-ip>:81` i nettleseren din.
- Logg inn med standardbruker:
  - **E-post**: `admin@example.com`
  - **Passord**: `changeme`
- Endre passord etter første pålogging.

### **5. Konfigurer en Reverse Proxy**

- Gå til "Proxy Hosts"-delen i GUI-en.
- Klikk på "Add Proxy Host".
- Fyll ut nødvendig informasjon:
  - **Domain Names**: Domenenavn/subdomener som skal håndteres.
  - **Forward Hostname / IP**: IP eller hostname til applikasjonen som proxyen skal videresende til.
  - **Forward Port**: Porten applikasjonen kjører på.
  - **SSL**: Aktiver SSL og velg "Request a new SSL Certificate" hvis du trenger HTTPS.
- Lagre innstillingene.

### **6. Test Oppsettet**

- Besøk domenenavnet du konfigurerte.
- Bekreft at det videresender trafikk til riktig tjeneste.

---

## Eksempel: Reverse Proxy for en Node.js-applikasjon

La oss si at du har en Node.js-applikasjon som kjører på port 3000. Du ønsker å gjøre den tilgjengelig via `https://example.com`:

1. Åpne "Add Proxy Host" i Nginx Proxy Manager.
2. Fyll ut følgende:
   - **Domain Names**: `example.com`
   - **Forward Hostname / IP**: `192.168.1.10` (serveren som kjører Node.js-applikasjonen).
   - **Forward Port**: `3000`
   - **SSL**: Aktiver "Force SSL" og be om et nytt Let's Encrypt-sertifikat.
3. Lagre innstillingene.
4. Test ved å besøke `https://example.com`.

---

## Oppsummering

Nginx Proxy Manager er et kraftig og brukervennlig verktøy for å sette opp og administrere en reverse proxy. Det gjør det enkelt å håndtere SSL, flere tjenester og domener, og gir deg fleksibilitet til å bygge en sikker og skalerbar webinfrastruktur.

For mer detaljer, besøk den offisielle [dokumentasjonen](https://nginxproxymanager.com/guide/#quick-setup).
