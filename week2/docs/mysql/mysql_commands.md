# MySQL-kommandoer

Her er en oversikt over vanlige kommandoer i MySQL-kommandolinjeverktøyet, inkludert beskrivelse av hva de gjør.

| **Kommando**                         | **Beskrivelse**                                                                 |
|--------------------------------------|---------------------------------------------------------------------------------|
| `mysql -u brukernavn -p`             | Koble til MySQL-serveren som en bestemt bruker.                                 |
| `mysql -u brukernavn -p -h vert -P <portNr>` | Koble til MySQL-serveren som en bestemt bruker på en annen port.                |
| `SHOW DATABASES;`                    | Liste alle databaser på MySQL-serveren.                                        |
| `USE databasenavn;`                  | Velg en bestemt database å jobbe med.                                          |
| `SHOW TABLES;`                       | Vis alle tabeller i den gjeldende databasen.                                   |
| `DESCRIBE tabellnavn;`               | Vis strukturen til en spesifikk tabell.                                        |
| `SELECT * FROM tabellnavn;`          | Hente data fra en tabell.                                                      |
| `INSERT INTO tabellnavn`             | Sett inn en ny rad i en tabell.                                                |
| `UPDATE tabellnavn`                  | Oppdater data i en tabell.                                                     |
| `DELETE FROM tabellnavn`             | Slett data fra en tabell.                                                      |
| `CREATE DATABASE navn;`              | Opprette en ny database.                                                       |
| `DROP DATABASE navn;`                | Slette en eksisterende database.                                               |
| `CREATE TABLE navn`                  | Opprette en ny tabell i den gjeldende databasen.                               |
| `DROP TABLE navn;`                   | Slette en tabell fra den gjeldende databasen.                                  |
| `EXIT;`                              | Avslutt MySQL-kommandolinjevinduet.                                            |

## Eksempel

For å koble til en MySQL-server og vise alle tilgjengelige databaser:
```bash
mysql -u root -p
SHOW DATABASES;
```

For å velge en database og vise tabellene i den:
```bash
USE my_database;
SHOW TABLES;
```

For å hente alle rader fra en tabell:
```bash
SELECT * FROM my_table;
```

Denne tabellen gir deg en rask oversikt over hva du kan gjøre i MySQL-kommandolinjeverktøyet.
