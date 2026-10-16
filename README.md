# PersonalRegister
Detta är ett konsolbaserat personregister utvecklat i C# som en examinerande inlämningsuppgift.

Programmet skriver ut persondata som ID, namn, e-post, adress och företagsinformation om 12, respektive 10, personer från två olika datakällor. Det gör det även möjligt att sortera dessa på ID eller namn och söka efter specifika personer baserat på deras namn.

## 1. Hur bygger och kör man programmet?
Programmet kan öppnas och köras i Visual Studio eller via PowerShell.
För att bygga och köra programmet via PowerShell navigerar man till mappen som innehåller projektets .csproj-fil och använder följande kommandon:
```powershell
dotnet build
dotnet run
```
När programmet startas utan argument visas en meny där användaren kan välja mellan 6 olika funktioner. 5 av dessa kan även nås direkt via kommandoraden:
| Kommando | Resultat |
|---|---|
| dotnet run -- list | Visar alla personer sorterade på ID
| dotnet run -- list --top5	| Visar de 5 första personerna sorterade på ID
| dotnet run -- list --sort	| Visar alla personer sorterade på namn
| dotnet run -- list --sort --top5 | Visar de 5 första personerna sorterade på namn
| dotnet run -- list --search anna | Visar personer vars namn innehåller "anna"

När ett kommando körs visas resultatet och därefter avslutas programmet utan att öppna menyn.

## 2. Hur har programmet delats upp mellan olika klasser och varför?
Jag har delat upp programmet i flera olika klasser baserat på ansvarsområden (enligt SRP) för att göra koden mer lättläst, organiserad och enklare att underhålla samt modifiera. Klasserna är dessutom indelade i följande 5 mappar för tydligare översikt: 

- **Models**: `Person`, `Address` och `Company` representerar informationen som lagras om varje person.
- **Data**: `DataStorage` och `JsonDataStorage` ansvarar för att hämta personuppgifter från olika datakällor. IDataSource definierar vilka metoder datakällorna måste ha.
- **Operations**: `PeopleOperator` innehåller metoderna för att sortera och söka efter personer.
- **UI**: `InputHandler` hanterar användarens inmatning och `OutputHandler` ansvarar för utskrifter i konsolen.
- **Controllers**: `MenuController` hanterar den interaktiva menyn och `CommandLineController` tolkar kommandoradsargument och utför motsvarande operationer.

I Program.cs väljs datakälla och programmet startas i antingen menyläge eller kommandoradsläge beroende på om argument har angetts eller ej.
På detta vis har jag även lyckats undvika att behöva skriva samma kod på flera ställen (enligt DRY), t.ex. använder både `MenuController` och `CommandLineController` samma sorterings- och sökmetoder i `PeopleOperator`.

## 3. Vad är C# respektive .NET?  
**C#** är ett objektorienterat programmeringsspråk som används för att skriva programkod.

**.NET** är en utvecklarplattform som bl.a. innehåller bibliotek och en exekveringsmiljö för att bygga och köra applikationer skrivna på flera olika språk, däribland är C# det allra vanligaste.

Vad är en skillnad mellan C# och ett annat programmeringsspråk?

C# och JavaScript har liknande syntax men en skillnad mellan dem är hur variabler hanteras. Medan C# är ett statiskt typat språk, vilket innebär att variablers datatyper inte kan ändras, så är JavaScript istället dynamiskt typat och variabler kan därmed innehålla värden av olika typer.

Ge exempel på vad man kan utveckla med C#/.NET.

Med C# och .NET kan man bl.a. utveckla konsolprogram, webbapplikationer, API, skrivbordsprogram och mobilapplikationer.

## 4. Vad används Visual Studio, Git och PowerShell till vid utveckling med C#/.NET?
- **Visual Studio** är en utvecklingsmiljö (IDE) som kan användas till att skriva, organisera, köra och felsöka C#-kod.
- **Git** är ett versionshanteringsprogram som används för att spara och följa förändringar i ens kod samt förenklar arbetet med olika versioner av ett projekt.
- **PowerShell** är ett kommandogränssnitt som bl.a. kan användas för att navigera mellan mappar, köra .NET-kommandon och arbeta med Git.
  
## 5. Vad är commit och branch?
En **commit** är en sparad version av ens kod i ett Git-repository. Varje commit innehåller information om vilka ändringar som har gjorts och ett meddelande som beskriver dem. Detta gör det möjligt att följa projektets utveckling och återgå till tidigare versioner t.ex. med hjälp att ett commits hashvärde.

En **branch** är, precis som namnet indikerar, en separat gren av ens projekt (en parallell version) där man kan arbeta med ändringar utan att påverka huvudprojektet (vanligtvis main). Branches används bl.a. för att utveckla nya funktioner eller testa förändringar innan de sammanfogas med main genom en merge.

## 6. Hur byter man datakälla och varför behöver inte registerfunktionerna ändras?
Programmet använder dessa två datakällor:
- `DataStorage` (som innehåller hårdkodade personuppgifter)
- `JsonDataStorage` (som läser personuppgifter från filen people.json)
  
Vilken av dessa som ska användas väljs i Program.cs, genom att kommentera ut antingen rad 14 eller 15:

```csharp
14	IDataSource dataSource = new DataStorage();
15	//IDataSource dataSource = new JsonDataStorage();
```
Här ovan används DataStorage och för att byta till JsonDataStorage kommenterar man ut den övre raden och tar bort kommentaren från den nedre:
```csharp
14	//IDataSource dataSource = new DataStorage();
15	IDataSource dataSource = new JsonDataStorage();
```
Programmet hämtar sedan personerna genom:
```csharp
List<Person> people = dataSource.GetPeople();
```
Eftersom båda datakällorna implementerar samma interface (`IDataSource`) kan programmet anropa `GetPeople()` oavsett vilken datakälla som används och returnera en `List<Person>`. Alltså kan samma registerfunktioner för sortering och sökning användas, utan ändringar, då allt de behöver ta emot är en lista av personer.
