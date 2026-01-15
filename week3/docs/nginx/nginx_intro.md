# Introduksjon til NGINX og Viktige Konsepter

## 1. Introduksjon til NGINX

### **Historie:**

- NGINX ble opprinnelig utviklet i 2002 av Igor Sysoev som en rask og effektiv webserver for å håndtere høye trafikkmengder på russiske nettsteder.
- Siden lanseringen har NGINX blitt en av de mest populære webserverne på Internett, brukt av mange av verdens største nettsteder og tjenester.

### **Formål:**

- NGINX er primært designet som en webserver, men har utviklet seg til å tjene som:
  - En kraftig reverse proxy
  - Lastbalanserer
  - Container-proxyserver
- Hovedformålet med NGINX er å håndtere høye trafikkmengder med høy ytelse, skalerbarhet og tilgjengelighet.

### **Fordeler:**

- **Høy ytelse:** Kjent som en av de raskeste webserverne, som kan håndtere høy trafikk med lav forsinkelse og høy gjennomstrømming.
- **Fleksibilitet:** Støtter ulike protokoller og formater, inkludert HTTP, HTTPS, FastCGI og flere API-baserte formater, som gir utviklere fleksibilitet til å velge den beste løsningen for sine behov.
- **Skalerbarhet:** Kan enkelt skaleres opp ved å legge til flere servere i en lastbalanseringskonfigurasjon, som gjør det enkelt å håndtere økende trafikk.

### **Plassering i Nettverksarkitektur:**

- NGINX plasseres ofte i frontend-delen av nettverksarkitekturen, mellom brukere og backend-applikasjoner eller databaser.
- I denne rollen fungerer NGINX som en reverse proxy, som håndterer inngående forespørsler fra brukere, videresender dem til backend-tjenester, og returnerer svarene til brukerne.
- Viktige fordeler inkluderer:
  - **Sikkerhet:** Skjuler backend-tjenester fra direkte tilgang.
  - **Optimalisering:** Håndterer caching, komprimering og routing.
  - **Feilsøking:** Gir et sentralisert sted for overvåking og analyse av forespørsler og svar.

---
<br><br><br><br><br><br>

## 2. Reverse Proxy

### **Hva er en Reverse Proxy?**

- En reverse proxy er en server som fungerer som et mellomledd mellom klienten og en eller flere servere.
- Den håndterer forespørsler fra klienter på vegne av de bakliggende serverne, og gir svar tilbake til klientene.
- Reverse proxy brukes for å beskytte og optimalisere tilgang til nettservere, samt for å legge til sikkerhetsfunksjoner som brannmur og SSL-kryptering.

### **Slik setter du opp en reverse proxy i NGINX:**

1. **Installer NGINX:**
   - Installer NGINX på serveren der du vil kjøre det.

2. **Konfigurer nginx.conf:**
   - Konfigurer NGINX-konfigurasjonsfilen (vanligvis `nginx.conf`) for å inkludere en virtuell server for reverse proxy-tjenesten.
   - Filplassering: `/etc/nginx/nginx.conf`

3. **Definer virtuell server:**
   - Angi en lytteadresse og port, og definer en plassering med `proxy_pass` som angir bakliggende server.

4. **Start NGINX-tjenesten:**
   - Start tjenesten på serveren for å aktivere konfigurasjonene.

5. **Konfigurer klienten:**
   - Klienten sender forespørsler til NGINX i stedet for direkte til bakliggende server.

### **Eksempel på reverse proxy-konfigurasjon:**

```nginx
http {
    server {
        listen 80;
        server_name example.com;
        location / {
            proxy_pass http://backend-server;
            proxy_set_header Host $host;
            proxy_set_header X-Real-IP $remote_addr;
        }
    }
}
```
<div style="page-break-after:always"></div>

## 2. Viktige NGINX-folderstrukturer

### **1. Konfigurasjonsfiler:**

- **Sti:** `/etc/nginx/conf.d/`
  - Inneholder tilleggs-konfigurasjonsfiler for NGINX.
  - Brukes til å definere serverblokker (virtuelle servere) for spesifikke domener, porter og tjenester.
  - Alle filer med `.conf` i denne mappen inkluderes automatisk i NGINX-hovedkonfigurasjonen.

### **Eksempel:**

```bash
cd /etc/nginx/conf.d/
```

I denne mappen kan du opprette separate `.conf`-filer for ulike tjenester. For eksempel:

```bash
sudo nano /etc/nginx/conf.d/reverse_proxy.conf
```

### **2. Statisk innhold:**

- **Sti:** `/usr/share/nginx/html/`
  - Standardplasseringen for statisk innhold som HTML-, CSS-, og JS-filer.
  - Hvis du bruker NGINX som en statisk webserver, lagres filene her.

#### Eksempel

```bash
cd /usr/share/nginx/html/
```

Plasser filene dine i denne mappen, og NGINX vil tjene dem som standard når noen besøker serverens IP-adresse eller domenenavn.

---
<br><br><br><br><br><br><br><br><br><br><br>

## 3. Forklaring av en NGINX-konfigurasjonsfil

### Eksempel på en `.conf`-fil

```nginx
server {
    listen 81;
    #server_name localhost;  # svarer på forespørsler fra localhost ( i produksjon -> domenenavn )
    server_name _;        # svarer på alle forespørsler uavhengig av host

    # http://localhost:81/api/Users/hello

    location /api/ {
        proxy_pass http://stud-blogg-api-compose:8080/api/v1/;
        proxy_http_version 1.1;
        proxy_set_header Upgrade $http_upgrade;
        proxy_set_header Connection 'upgrade';
        proxy_set_header Host $host;
        proxy_cache_bypass $http_upgrade;
    }
}
```

### Forklaring av elementene

#### **1. `server {}`**

- En serverblokk definerer en virtuell server.
- Kan håndtere spesifikke domener, porter og stier.

#### **2. `listen 81;`**

- Angir hvilken port NGINX skal lytte på.
- Port 81 brukes her som et eksempel. Standard HTTP-port er 80.

#### **3. `server_name _;`**

- Angir hvilke forespørsler serveren skal svare på.
- **`_`**: Svarer på alle forespørsler, uavhengig av domenenavn eller IP.
- I produksjon bør dette erstattes med et spesifikt domenenavn, f.eks.:

  ```nginx
  server_name example.com;
  ```

#### **4. `location /api/ {}`**

- Definerer regler for håndtering av forespørsler til URL-er som starter med `/api/`.

#### **5. `proxy_pass http://stud-blogg-api-compose:8080/api/v1/;`**

- Viderekobler forespørsler til en backend-tjeneste.
- I dette eksemplet sendes alle forespørsler til `http://stud-blogg-api-compose:8080/api/v1/`.

#### **6. `proxy_http_version 1.1;`**

- Angir at HTTP-versjon 1.1 skal brukes for forespørsler mellom NGINX og backend-tjenesten.

#### **7. `proxy_set_header ...`**

- **`Upgrade $http_upgrade;`** og **`Connection 'upgrade';`**: Nødvendig for WebSocket-støtte.
- **`Host $host;`**: Bevarer det opprinnelige domenenavnet i forespørselen.
- **`proxy_cache_bypass $http_upgrade;`**: Sikrer at caching ikke påvirker oppgraderte forbindelser.

---
<div style="page-break-after:always"></div>

## 4. Testing og Feilsøking

### **Testing av Konfigurasjon:**

- Sjekk syntaksen i konfigurasjonsfilene før du starter NGINX:

  ```bash
  sudo nginx -t
  ```

### **Restart NGINX:**

- Hvis testen er vellykket, last inn NGINX på nytt:

  ```bash
  sudo systemctl reload nginx
  ```

### **Feilsøking:**

- Sjekk feil i loggene:

  ```bash
  sudo tail -f /var/log/nginx/error.log
  ```

---
<div style="page-break-after:always"></div>

## 4. Lastbalansering

### Typer Lastbalansering

1. **Roundrobin:** Trafikk sendes til hver server i en jevn rotasjon.
2. **Vektorbasert:** Servere tildeles en vekt basert på kapasitet, og trafikk sendes til servere med høyere vekt.
3. **IP-basert:** Trafikk tildeles en server basert på klientens IP-adresse.
4. **Geografisk:** Trafikk tildeles en server basert på geografisk plassering.
5. **Portbasert:** Trafikk tildeles en server basert på portnummer.
6. **Cookiebasert:** Trafikk tildeles en server basert på informasjon lagret i en cookie.

### Eksempel på Loadbalancer-konfigurasjon

```nginx
http {
  upstream backend {
    server container1:80;
    server container2:80;
  }

  server {
    listen 80;
    location / {
      proxy_pass http://backend;
    }
  }
}
```

I denne konfigurasjonen:

- **Upstream-gruppe:** Definerer en gruppe med servere som trafikken kan lastbalanseres mellom.
- **Server-blokker:** Angir individuelle servere og porter.
- **Proxy_pass:** Viderekobler forespørsler til backend-gruppen for lastbalansering.

> Referer til NGINX-dokumentasjonen for å konfigurere mer komplekse lastbalanseringsscenarier.

---
<div style="page-break-after:always"></div>

## 5. Routing

- Hvordan NGINX videresender forespørsler til andre servere (som en reverse proxy).

---

## 6. Ytelse

- Optimaliseringer for å øke ytelsen til NGINX, inkludert caching, komprimering og reduksjon av responstid.

---

## 7. Sikkerhet

### Viktige Sikkerhetskonfigurasjoner

1. **SSL/TLS Kryptering:**
   - Beskytter kommunikasjonen mellom klienter og serveren.

2. **Begrensning av Tilgang:**
   - Definerer regler for å kontrollere tilgang til nettstedet eller tjenesten ved hjelp av IP-adresser eller vertsnavn.

3. **HTTP Sikkerhetshoder:**
   - Støtter sikkerhetshoder som Strict-Transport-Security (HSTS) og X-XSS-Protection for å beskytte mot sårbarheter.

4. **Caching-begrensninger:**
   - Forhindrer lagring av sensitive data på disk.

5. **Loggføring av Tilgang:**
   - Logger detaljer om nettstedbesøk, inkludert informasjon om hvem som har besøkt, hvilke sider som er besøkt, og statuskoder.

6. **Brannmurkonfigurasjoner:**
   - Brukes med en brannmur for å beskytte mot uønsket trafikk og angrep.

> Merk: Dette er grunnleggende konfigurasjoner. Ytterligere sikkerhetstiltak kan være nødvendig avhengig av nettstedets eller tjenestens behov.


---
