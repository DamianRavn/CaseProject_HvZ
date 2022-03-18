## Fredag 18/03 ##
- Keycloack giver lidt udfordringer
  - Deployment til Azure virker ikke pt.
  - Authentication token gemmes i local storage efte login, men bliver ikke hentet i tide
    - Ie. når token er hentet, er API request allerede blevet afvist
- Vi har haft lidt uregelmæssigheder i naming conventions
  - I frontend skal mapper starte med lowercase.
    - Det er svært at rette, da git ikke er case sensitive for mapper
      - I stedet kan man rename til tmp og så tilbage igen til den ønskede case
    - Dette er rettet i main branch og keycloack-frontend branch
  - I backend bør vores API endpoint starte med lowercase
- Evt. nye endpoints, fx et til at få alle users i et game
- Vi mødes igen på kontoret på mandag - minus Jesper som flyver hjem i løbet af mandagen

## Onsdag 16/03 ##
- Frontend
  - pt har vi en branch kaldet new-frontend-old-backend, fordi vi ikke har koblet frontend op på den nye backend der kræver en token
    - Vi prøver at merge den nye frontend kode ind i main, så vi har et fælles udgangspunkt at arbejde ud fra.
    - Den gamle backend kan stadig bruges indtil vi får koblet op til den nye
- Backend
  - Backend er en del foran frontend
  - pt arbejdes der på input sanitation og https
- Frosti arbejder på landing page i frontend, hvor bl.a. games skal vises
  - Login og register funktioner laves først efter at vi har implementeret Keycloak
- Jesper kigger på design med Tailwind og koordinerer med Frosti for at undgå dobbelt arbejde
- Marius arbejder med Keycloak og integration af frontend med den nye backend
- Filip arbejder med evt. refactoring af API kald og Axios og koordinerer også med Frosti for at undgå dobbeltarbejde
- Der gives besked på Slack når vi har merget frontend fra 'new-frontend-old-backend' branch ind i main.
  - Herefter brancher vi ud fra main for at implementere features og merger ind i main igen.
- Vi mødes igen i morgen kl 13:00

## Morgen mandag 14/03 ##
- Damian har addet security og auth tokens og tilføjet username og password attributes 
- dDployment
  - pt virker det til at databasen giver nogle problemer
- Vi er stadig lidt i tvivl om hvordan database relationerne skal være
  - Fx, skal man kunne være admin til flere games in progress
  - Hvordan deleter vi, implementere vi vores egen funktion der minder om cascade delete?
  - Vi spørger Dewald til eftermiddagmødet
- Frontend
  - Vi har basic scaffolding nu, men vi ved ikke helt hvordan redux implementeres korrekt
    - Marius og Frosti hjælper Filip på frontend
    - Damian har et repo på github med en redux implementation, kig evt. på den
- Vi holder møde med Dewald kl 13

## Morgen fredag 11/03 ##
- Damian begynder at kigge på deployment
- Marius kigger på database
  - Nogle FKs skal være Nullable, fordi sql klagede over cascading deletes - Hvis user deletes, deleter den admin, som deleter game, og player bliver deleted af både user og game.
    - Starter med admin_id FK i Game
- Frosti læser op på Redux
- Filip læser op på Redux og laver et tomt projekt så Damian kan teste deployment
- Vi har fået nyt skema. Pt skal vi alle møde mandag, onsdag og fredag.
  - Vi vil gerne have dette lavet om til 2 dage
    - Vi foreslår mandag og onsdag, men dette skal koordineres med Kirstine og Jesper
- På mandag møder vi på kontoret.
  - Vi holder møde med Jesper kl 13:00
  - Vi har møde med Dewald, er det også kl 13?

## Morgen torsdag 10/03 ##
- Database diagram
  - Vi beholder det nuværende diagram for vores MVP
  - Admin forbliver et seperat table fordi
    - En admin skal kunne styre mange spil
    - Spare plads i users, ie. ikke alle users er admin
    - Tydeliggør vores database design ved at have det som separat table
  - Required fields blev diskuteret
    - is_human
    - is_patient_zero
    - bite_code
    - userid
    - gameid
- GiHub rules er nu implementeret
  - Man skal pull fra main til en branch og så merge derfra
- Dage på kontoret
  - Frosti skriver til Kirstine og spørger om vi kan have to dage sammen på kontoret
  - Kirstine laver så en ny plan og publiserer den, formegentligt i næste uge
- Mødet i morgen, fredag d. 11/03, starter kl 09:30

## Eftermiddag gruppe onsdag 09/03 ##
- HaknPlan
  - Task laves i Backlog og sendes derfra ind i sprints
- GitHub repo struktur forslag
  - Front-end
  - Back-end
  - Projects
- Marius undersøger mulighed for at oprette GitHub rules
- Jesper er remote frem til engang i næste uge
  - Fra mandag har vi derfor morgenmøde kl 13:00

## Eftermiddag Dewald onsdag 09/03 ##
- Dewald anbefaler følgende
  - Auth0
  - Plain javascript for React
  - Redux med toolkit for state management i frontend
  - Map-plugin
    - Leaflet med extras (links i Slack)
    - Hvis api-key kræves er det en betalt extra
    - Carto map er god
    - Google Maps er gratis, men kræver credit card details
- Book eventuelle møde med Dewald gennem Stian (DM ham i Slack)
- Mock presentation 29th
- Final presentation 30th


## Middag onsdag 09/03 ##
- Skriv løbende dokumentation for kode, push altid med comments
- Spørg Kirstine om alle kan være på kontoret tirsdag og onsdag
- Vi holder et dagligt møde omkring kl 9
- Marius har uploadet dokument med MVP highlights til Discord
- Send emails til Jesper for invit til HacknPlan


## Morgen onsdag 09/03 ##
- Vi mødes igen kl 11:30 efter at have læst case, case guidance og tænkt over opgaver/tasks
- Møde med Dewalt 13:00
- Vi vil have MVP klar senest d. 25.
- Vi prøver at kommunikere og planlægge her:
- Discord – Filip Laver en server, send Discord username i slack
- HacknPlan – Jesper laver et team?
- Vi planlægger at bruge følgende teknologier til projektet
  - .Net med EF til backend
  - React til Frontend
  - Tailwind eller det framework Smartpage bruger til CSS
- Vi kommer nok alle til at arbejde med både frontend og backend, men pt. er der følgende præferencer:
    - Damian, Frosti: Backend
    - Marius: Både Front og Backend
    - Jesper: UI/UX
    - Filip: Frontend 

