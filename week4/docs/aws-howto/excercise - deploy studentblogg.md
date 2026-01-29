# Plan

## Mål

### Bygge og deploy komplett løsning på AWS for studentblogg 

1. Ta utgangspunkt i docker-compose.yml, bruk komplett løsning fra uke-3
2. Må bygges images localt
3. tagge images og pushe de til docker-hub
4. Lage ny docker-compose.yml som ikke bygger men bruker images fra docker-hub
5. Opprette en EC2 Maskin på AWS
6. Kopierer docker-compose.yml filen til EC2 maskinen
7. SSH til EC2 maskinen 
   1. oppdatere
   2. installere docker-compose
   3. Få opp og teste løsning for student-blogg 