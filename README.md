# 🐦 Flappy Bird – Unity 2D

A Flappy Bird clone for **desktop and Android**, built with **Unity 2020.3 (LTS)** and C#.
Tap, dodge the pipes, beat your highscore.

## Features

- Classic one-button gameplay (mouse click / tap)
- Randomly generated pipes with raycast-based score detection
- Persistent highscore (local storage)
- Main menu, loading screen, and game-over window with scoreboard
- Pause function with a countdown before resuming
- Sound effects and background music (flap, point, hit, death)
- Animated bird and scrolling ground
- Prebuilt Android APK included in the repository

## Tech Stack

| Area            | Technology                                      |
| --------------- | ----------------------------------------------- |
| Engine          | Unity 2020.3.25f1                               |
| Language        | C#                                              |
| Physics         | Unity Physics2D (`Rigidbody2D`)                 |
| UI              | Unity UI + TextMeshPro                          |
| Target platforms| Windows / macOS / Linux, Android (min. SDK 19)  |

## Project Structure

```
FlappyBird/
├── APK/                  # Prebuilt Android build
├── Assets/
│   ├── Animations/       # Bird and ground animations
│   ├── Backend/          # All game logic (C#)
│   ├── FlappyBirdAsserts/# Sprites and prefabs (Bird, Pipe, Ground)
│   ├── Fonts/
│   ├── Scenes/           # MainMenu, LoadingScene, MainScene
│   └── Sounds/
├── Packages/
└── ProjectSettings/
```

### Key Scripts (`Assets/Backend`)

| Script              | Responsibility                                        |
| ------------------- | ----------------------------------------------------- |
| `Bird.cs`           | Player logic, state machine, jump, collision, score   |
| `PipeHandler.cs`    | Pipe spawning and movement, pause/resume              |
| `SaveData.cs`       | Saving and loading the highscore                      |
| `ScoreBoard.cs`     | Score and highscore display                           |
| `GameOverWindow.cs` | Game-over UI                                          |
| `Loader.cs`         | Scene transitions via the loading screen              |
| `SoundManager.cs`   | Central sound effect playback                         |

## Getting Started

### Prerequisites

- [Unity Hub](https://unity.com/download)
- Unity Editor **2020.3.25f1** (other 2020.3 versions should generally work as well)

### Open the Project

```bash
git clone https://github.com/ElectricRoyale/FlappyBird.git
```

1. Open Unity Hub → **Add** → select the `FlappyBird/` folder
2. Open it with Unity 2020.3.25f1
3. Load the scene `Assets/Scenes/MainMenu.unity`
4. Press **Play**

### Android Build

The prebuilt APK is located at `FlappyBird/APK/Flappy_Bird2.apk` and can be installed directly on an Android device (allow installation from unknown sources).

To build it yourself: **File → Build Settings → Android → Build**.

## Controls

| Action               | Input                |
| -------------------- | -------------------- |
| Start game / Jump    | Left click or tap    |

## Known Limitations / Roadmap

- [ ] Replace `BinaryFormatter` with JSON for highscore persistence (safer and more maintainable)
- [ ] Difficulty levels (pipe gap, speed)
- [ ] Remove the empty `GameHandler.cs` or give it a purpose
- [ ] Settings menu (volume)

## Contributing

Pull requests are welcome. For major changes, please open an issue first.

## License

Not yet specified. Recommendation: add the [MIT License](https://choosealicense.com/licenses/mit/).

> This is a fan project and is not affiliated with the original Flappy Bird.
