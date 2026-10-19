# Flappy Bird – Unity 2D

Ein Flappy-Bird-Klon für **Desktop und Android**, entwickelt mit **Unity 2020.3 (LTS)** und C#.
Tippen, Röhren ausweichen, Highscore knacken.

## Features

- Klassisches One-Button-Gameplay (Mausklick / Tap)
- Zufällig generierte Röhren mit Score-Erkennung per Raycast
- Persistenter Highscore (lokale Speicherung)
- Hauptmenü, Ladebildschirm, Game-Over-Fenster mit Scoreboard
- Pause-Funktion mit Countdown vor dem Weiterspielen
- Sound-Effekte und Hintergrundmusik (Flügelschlag, Punkt, Treffer, Tod)
- Animierter Vogel und scrollender Boden
- Vorkompilierter Android-Build (APK) im Repository

## Tech Stack

| Bereich       | Technologie                      |
| ------------- | -------------------------------- |
| Engine        | Unity 2020.3.25f1                |
| Sprache       | C#                               |
| Physik        | Unity Physics2D (`Rigidbody2D`)  |
| UI            | Unity UI + TextMeshPro           |
| Ziel-Plattform| Windows / macOS / Linux, Android (min. SDK 19) |

## Projektstruktur

```
FlappyBird/
├── APK/                  # Fertiger Android-Build
├── Assets/
│   ├── Animations/       # Vogel- und Boden-Animationen
│   ├── Backend/          # Gesamte Spiellogik (C#)
│   ├── FlappyBirdAsserts/# Sprites und Prefabs (Bird, Pipe, Ground)
│   ├── Fonts/
│   ├── Scenes/           # MainMenu, LoadingScene, MainScene
│   └── Sounds/
├── Packages/
└── ProjectSettings/
```

### Wichtige Skripte (`Assets/Backend`)

| Skript             | Aufgabe                                              |
| ------------------ | ---------------------------------------------------- |
| `Bird.cs`          | Spielerlogik, State-Machine, Sprung, Kollision, Score|
| `PipeHandler.cs`   | Spawnen und Bewegen der Röhren, Pause/Resume         |
| `SaveData.cs`      | Speichern und Laden des Highscores                   |
| `ScoreBoard.cs`    | Anzeige von Score und Highscore                      |
| `GameOverWindow.cs`| Game-Over-UI                                         |
| `Loader.cs`        | Szenenwechsel über den Ladebildschirm                |
| `SoundManager.cs`  | Zentrales Abspielen der Sound-Effekte                |

## Installation & Start

### Voraussetzungen

- [Unity Hub](https://unity.com/download)
- Unity Editor **2020.3.25f1** (andere 2020.3-Versionen funktionieren in der Regel ebenfalls)

### Projekt öffnen

```bash
git clone https://github.com/ElectricRoyale/FlappyBird.git
```

1. Unity Hub öffnen → **Add** → Ordner `FlappyBird/` auswählen
2. Mit Unity 2020.3.25f1 öffnen
3. Szene `Assets/Scenes/MainMenu.unity` laden
4. **Play** drücken

### Android-Build

Die fertige APK liegt unter `FlappyBird/APK/Flappy_Bird2.apk` und kann direkt auf ein Android-Gerät installiert werden (Installation aus unbekannten Quellen erlauben).

Eigener Build: **File → Build Settings → Android → Build**.

## Steuerung

| Aktion              | Eingabe                |
| ------------------- | ---------------------- |
| Spiel starten / Sprung | Linksklick bzw. Tap |

## Bekannte Einschränkungen / Roadmap

- [ ] Highscore-Speicherung von `BinaryFormatter` auf JSON umstellen (sicherer und wartbarer)
- [ ] Schwierigkeitsstufen (Röhrenabstand, Geschwindigkeit)
- [ ] Leeres `GameHandler.cs` entfernen oder sinnvoll nutzen
- [ ] Einstellungsmenü (Lautstärke)

## Mitwirken

Pull Requests sind willkommen. Für größere Änderungen bitte zuerst ein Issue erstellen.

## Lizenz

Noch nicht festgelegt. Empfehlung: [MIT License](https://choosealicense.com/licenses/mit/) hinzufügen.

> Dieses Projekt ist ein Fan-Projekt und steht in keiner Verbindung zum Original-Flappy-Bird.
