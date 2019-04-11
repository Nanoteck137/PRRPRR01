# Hängagubbe

C# for life

## Program Beskrivning

- Hängagubbe vanliga regler
- Användaren ska kunna lägga till egna ord
- Ladda ord från en fil JSON (Json.NET C# Library for life) 

## Program Flow

![Program Flow Diagram](Diagram.png) 

Variabler
  - Rätt gissade ord (List string) (Game Class)
  - Fel gissade ord (List string) (Game Class)
  - Random Object för random nummer (Random) (Game Class)

## Klasser

- Program (Main) Ge användaren val om att lägga till ord om dem vill eller starta ett nytt spel varje gång
- Game (Spelets start, all logik här) Spelets logik ska finns i denna klassen man ska kunna skapa en ny Game Object för att starta ett nytt spel

Program:
 - Main Method (Public)
 - DrawMenu Method (Private, Ritar upp menyn som användaren får före ett nytt spel) (New Game, Add word, Exit Game) 

Game: 
 - Run Method (Public, Startar spelet)
 - Draw Method (Private, Ritar upp gubben, ordet och hur många rätt och fel)