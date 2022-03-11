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

