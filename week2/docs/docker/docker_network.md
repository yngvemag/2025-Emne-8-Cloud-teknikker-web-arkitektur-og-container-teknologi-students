# Docker Network Reference

## Nettverkstyper og Bruksområder

### Bridge

**Beskrivelse:**

- Standard nettverkstypen som brukes når ingen nettverkstype er spesifisert.
- Isolerer containere fra hverandre og fra vertsmaskinen.
- Egnet for kjøring av flere stand-alone containere som trenger å kommunisere.

**Brukseksempel:**

```bash
# Opprett nettverk
docker network create my-network

# Koble containere til nettverket
docker run -d --name my-container1 --network my-network myimage
docker run -d --name my-container2 --network my-network myimage
```

### Host

**Beskrivelse:**

- Fjerner nettverksisoleringen mellom containeren og Docker-verten, og bruker direkte vertens nettverk.

**Bruksområder:**

- Gir høyere ytelse ved å unngå nettverksoverhead.
- Brukes når containeren trenger full tilgang til vertens nettverk.

**Brukseksempel:**

```bash
docker run -d --network host myimage
```

**Viktige punkter å vurdere:**

1. **Portkonflikter:**
   - Siden containeren deler vertens nettverksstack, må du sørge for at applikasjonen i containeren ikke prøver å lytte på porter som allerede er i bruk på vertsmaskinen.
2. **Sikkerhet:**
   - Bruk av host-nettverk kan ha sikkerhetsimplikasjoner, ettersom applikasjonen i containeren får større tilgang til vertssystemets nettverksressurser.
3. **Plattformbegrensninger:**
   - `--network host` fungerer ikke på Docker for Mac eller Docker for Windows når du kjører Linux-containere.
4. **Bruksområder:**
   - Ytelsesintensive applikasjoner eller applikasjoner som trenger lavnivå nettverkskontroll.

### Overlay

**Beskrivelse:**

- Brukes i Docker Swarm for å koble flere Docker-demoner sammen.

**Bruksområder:**

- Muliggjør kommunikasjon mellom Docker-demoner.
- Brukes i klynger for å koble containere på forskjellige Docker-verter.

### Macvlan

**Beskrivelse:**

- Lar deg tilordne en MAC-adresse til en container, noe som gjør den synlig som en fysisk enhet på nettverket.

**Bruksområder:**

- Brukes når containere trenger å være synlige som fysiske enheter på nettverket.
- Nyttig for avanserte nettverksbehov.

### None

**Beskrivelse:**

- Deaktiverer all nettverk.

**Bruksområder:**

- For containere som ikke skal ha noen nettverkstilgang.
- Brukes for sikkerhet eller testing i isolerte miljøer.

## Forklaring av Nettverkstyper

1. **Bridge:**
   - Standard nettverkstypen i Docker.
   - Skaper et nytt nettverkssegment isolert fra andre nettverk.
   - Containere på samme bridge-nettverk kan kommunisere med hverandre, og NAT brukes for å koble til det eksterne nettverket.

2. **Host:**
   - Containeren deler nettverksstacken med vertsmaskinen.
   - Nettverksportene åpnet av containeren er direkte tilgjengelige på vertsmaskinen.

3. **Overlay:**
   - Designet for Docker Swarm, kobler flere Docker-demoner sammen.
   - Muliggjør sikker kommunikasjon mellom containere på forskjellige noder i en klynge.

4. **Macvlan:**
   - Lar containere få en unik MAC-adresse på det eksisterende fysiske nettverket.
   - Nyttig for legacy-applikasjoner som forventer fysiske nettverksforbindelser.

5. **None:**
   - Deaktiverer all nettverkstilgang til en container.
   - Nyttig for containere som skal kjøre helt isolert.

## Eksempler

**Opprett og bruk nettverk:**

```bash
# Opprett nettverk
docker network create net_student_blogg

# Start database container
docker run --name student_blogg_db --network net_student_blogg -p 3310:3306 -d db_student_blogg

# Start API container
docker run -p 8080:80 --network net_student_blogg -d studenbloggapi
