# Git-opprydding i praksis – dokumentasjon og forklaringer

Denne dokumentasjonen beskriver **reelle Git-problemer** vi har vært gjennom, hvorfor de oppstår, og **hvordan de løses riktig**.  
Eksemplene er spesielt relevante for **undervisningsrepoer**, **.NET / C# prosjekter**, og arbeid på **Windows**.

---

## Innholdsfortegnelse

1. Hvorfor GitHub blokkerer push
2. Forskjellen på `git rm`, `.gitignore` og historikk
3. GitHub Push Protection og secrets
4. Store filer (>100 MB) og GitHub-begrensninger
5. `git filter-repo` – hva det er og hvorfor vi bruker det
6. Installere `git filter-repo`
7. Fjerne filer og mapper fra hele Git-historikken
8. Hvorfor `origin` forsvinner – og hvordan fikse det
9. IDE-filer (`.idea`, `.vs`) og Windows path-length
10. Anbefalt `.gitignore` for .NET / undervisning
11. Oppsummering – mental modell for Git

---

## 1. Hvorfor GitHub blokkerer push

GitHub kan stoppe en `git push` av to hovedgrunner:

### A) Secrets (AWS keys, tokens, passord)
GitHub scanner **alle commits du prøver å pushe**, også gamle commits.

> Det hjelper ikke å slette filen i en ny commit hvis hemmeligheten finnes i en eldre commit.

### B) Store filer (>100 MB)
GitHub tillater **maks 100 MB per fil** i vanlig Git.

> Selv om du sletter filen lokalt, blokkeres push hvis filen finnes i historikken.

---

## 2. `.gitignore` – hva den gjør (og ikke gjør)

`.gitignore`:
- ✔ Hindrer **nye filer** i å bli lagt til
- ❌ Fjerner **ikke** filer som allerede er commitet

Derfor trenger vi ofte:
```bash
git rm --cached <fil/mappe>
```

---

## 3. `git rm` – forskjellen på variantene

### Fjerne fil fra Git, men beholde lokalt
```bash
git rm --cached fil.txt
```

### Fjerne fil helt (og slette lokalt)
```bash
git rm fil.txt
```

⚠️ Ingen av disse fjerner filen fra **tidligere commits**.

---

## 4. Når `git rm` ikke er nok → historikk må skrives om

Hvis GitHub sier:
- `Push cannot contain secrets`
- `Large files detected`

Da må filen bort fra **hele historikken**.

Dette er jobben til `git filter-repo`.

---

## 5. Hva er `git filter-repo`?

`git filter-repo` er et verktøy som:
- Skriver om **hele Git-historikken**
- Fjerner filer, mapper eller innhold fra **alle commits**
- Erstatter gamle commits med nye, rene commits

Det er den **moderne og anbefalte** erstatningen for `git filter-branch`.

---

## 6. Installere `git filter-repo`

### Windows / macOS / Linux (anbefalt)
```bash
pip install git-filter-repo
```

### macOS (Homebrew)
```bash
brew install git-filter-repo
```

Sjekk installasjon:
```bash
git filter-repo --help
```

---

## 7. Fjerne filer eller mapper fra hele historikken

### Eksempel: fjerne en hel mappe
```bash
git filter-repo --force --path 23-25_eksamen/ --invert-paths
```

**Forklaring:**
- `--path` → hva som skal matches
- `--invert-paths` → behold ALT unntatt dette
- `--force` → tillat historikkomskriving

### Eksempel: fjerne alle `.zip`-filer i historikken
```bash
git filter-repo --force --path-glob "*.zip" --invert-paths
```

---

## 8. Hvorfor forsvinner `origin` etter `filter-repo`?

Av sikkerhetsgrunner **fjerner `git filter-repo` remote-konfigurasjonen**.

Derfor får du:
```
fatal: 'origin' does not appear to be a git repository
```

### Løsning: legg til remote på nytt
```bash
git remote add origin https://github.com/BRUKERNAVN/REPO.git
```

Sjekk:
```bash
git remote -v
```

---

## 9. Force push etter historikkomskriving

Når historikken er endret **må** du bruke force push:

```bash
git push --force origin main
```

`--force-with-lease` er tryggere, men kan feile hvis remote har endret seg.

---

## 10. IDE-filer og Windows-problemer

### Typiske problemer
- `.idea/`, `.vs/` blir commitet
- Windows: `Filename too long`
- Unødvendige 1000+ filer i repo

### Løsning
Legg dette i `.gitignore`:
```gitignore
.idea/
.vs/
**/.idea/
**/.vs/
bin/
obj/
```

Fjern allerede trackede filer:
```bash
git rm -r --cached .idea .vs bin obj
git commit -m "Remove IDE and build artifacts"
```

---

## 11. Anbefalt `.gitignore` for .NET / undervisning

Minimum:
```gitignore
bin/
obj/
.vs/
.idea/
.env
*.zip
```

For eksamensinnleveringer:
```gitignore
23-25_eksamen/
```

---

## 12. Mental modell – når bruke hva?

| Problem | Løsning |
|------|--------|
| Fil lagt til ved uhell | `git rm --cached` |
| Fil skal ignoreres fremover | `.gitignore` |
| Secret i historikk | `git filter-repo` |
| Fil > 100 MB | `git filter-repo` |
| IDE-filer i repo | `.gitignore` + `git rm --cached` |
| Push blokkert av GitHub | Historikkomskriving |

---

## 13. Viktig advarsel

⚠️ **Historikkomskriving påvirker alle som har clonet repoet.**  
Studenter må da:
```bash
git fetch
git reset --hard origin/main
```
eller re-klone repoet.

---

## 14. Anbefalt praksis for undervisningsrepoer

- ❌ Ikke lagre studentinnleveringer i Git
- ❌ Ikke lagre secrets, nøkler eller `.env`
- ✅ Bruk `.gitignore` tidlig
- ✅ Bruk `filter-repo` når (ikke hvis) noe går galt

---

## Sluttord

Dette er ikke "avansert Git" – dette er **realistisk Git**.  
Hvis du underviser, er dette nøyaktig de problemene studentene vil møte.

Å kunne rydde opp korrekt er en **viktig profesjonell ferdighet**.

