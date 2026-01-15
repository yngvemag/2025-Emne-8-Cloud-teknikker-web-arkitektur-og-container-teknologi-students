# Introduksjon til Grunnleggende Linux-kommandoer og bruk av `vi`-editoren

## Grunnleggende Linux-kommandoer

Linux tilbyr en rekke kommandoer for å administrere filer, mapper og systemet. Her er en introduksjon til noen grunnleggende kommandoer:

### Navigasjon og filhåndtering

- **`pwd`**: Viser den nåværende arbeidskatalogen.
- **`ls`**: Lister filer og kataloger i den nåværende katalogen.
  - `ls -l`: Viser detaljer som filstørrelse, tillatelser, eier, osv.
  - `ls -a`: Viser også skjulte filer.
- **`cd [katalog]`**: Endrer den nåværende katalogen.
  - Eksempel: `cd /home/user`
- **`mkdir [katalognavn]`**: Oppretter en ny katalog.
  - Eksempel: `mkdir prosjekter`
- **`rm [filnavn]`**: Sletter en fil.
  - For mapper: `rm -r [katalognavn]`.
- **`cp [kilde] [destinasjon]`**: Kopierer filer eller mapper.
  - Eksempel: `cp fil.txt backup/`
- **`mv [kilde] [destinasjon]`**: Flytter eller gir nytt navn til en fil eller katalog.
  - Eksempel: `mv fil.txt ny_fil.txt`

### Filvisning og redigering

- **`cat [filnavn]`**: Viser innholdet av en fil.
- **`more [filnavn]`**: Viser filinnhold én side av gangen.
- **`less [filnavn]`**: Som `more`, men gir mer fleksibilitet for navigering.
- **`nano [filnavn]`**: Enkel teksteditor i terminalen.

### Systeminformasjon

- **`whoami`**: Viser hvilken bruker du er logget inn som.
- **`df -h`**: Viser diskkapasitet og bruk på systemet.
- **`top`**: Viser sanntids informasjon om systemprosesser.

### Tillatelser

- **`chmod [tillatelser] [fil]`**: Endrer fil- eller maptillatelser.
  - Eksempel: `chmod 755 script.sh`
- **`chown [eier] [fil]`**: Endrer eierskap av en fil.

---
<br><br><br><br>
## Introduksjon til `vi`-editoren

`vi` er en kraftig og allsidig teksteditor som er tilgjengelig på nesten alle Linux-systemer. Den har to hovedmoduser:

1. **Kommandomodus**: Utfør kommandoer som å lagre eller avslutte.
2. **Innstastingsmodus**: Skriv eller rediger tekst.

### Grunnleggende kommandoer i `vi`

#### Åpne og navigere i en fil

- **`vi [filnavn]`**: Åpner en fil i `vi`.
- **`h`, `j`, `k`, `l`**: Flytt markøren venstre, ned, opp, høyre.
- **`G`**: Gå til slutten av filen.
- **`gg`**: Gå til starten av filen.
- **`/tekst`**: Søk etter "tekst" i filen.
- **`n`**: Gå til neste treff etter søk.

#### Redigere tekst

- **`i`**: Gå til innskrivingsmodus for å sette inn tekst før markøren.
- **`a`**: Gå til innskrivingsmodus for å sette inn tekst etter markøren.
- **`o`**: Sett inn en ny linje under den nåværende og gå til innskrivingsmodus.
- **`Esc`**: Gå tilbake til kommandomodus.

#### Lagre og avslutte

- **`:w`**: Lagre filen.
- **`:q`**: Avslutt `vi`.
- **`:wq`**: Lagre og avslutt.
- **`:q!`**: Avslutt uten å lagre.

#### Slette tekst

- **`x`**: Slett tegnet under markøren.
- **`dd`**: Slett hele linjen.
- **`d$`**: Slett fra markøren til slutten av linjen.

---
