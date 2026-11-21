# Slot Machine Game

A simple slot machine game made with Unity and C#. It has three reels.
Spin them and try to get the same symbol on all three reels to win.

## Game Overview

Each reel spins and stops on a randomly selected symbol. Once all three
reels have stopped, the game checks the results and displays a win or
lose screen.

### Features

-   Three independently controlled reels
-   Random symbol selection
-   Smooth reel movement and stopping
-   Looping symbols while the reels are spinning
-   Win and lose detection
-   Win and lose result animations
-   Sound effects for spinning, symbol ticks, winning, and losing
-   Animated slot machine lever

## How to Run the Windows Build

1.  Download or clone this repository.
2.  Open the `Build/Windows` folder.
3.  Run the game's `.exe` file.
4.  If Windows displays a security warning, verify that the executable
    came from this repository before choosing to run it.

**Note:** Keep the `.exe` file together with the other files and folders
generated in the Windows build. Do not move the executable on its own.

## Bonus Features

The project includes a few extra touches to make the game feel more
complete:

-   **Sound effects:** Audio feedback during reel spinning, symbol
    changes, winning, and losing.
-   **Lever animation:** The lever is animated to make the spin
    interaction feel more natural.
-   **Result animations:** Separate win and lose panels appear after the
    reels stop and fade away.
-   **Automatic return:** After the result animation finishes, the game
    returns to the main game panel.

## Current Limitations

This is a time-limited assignment project, so some features could not be
completed.

-   A proper game-over flow was not implemented.
-   A proper exit/quit option was not implemented.
-   Some additional gameplay and UI features still need improvement.
-   A WebGL build could not be completed within the available time. The
    submitted build is for Windows.

These are known limitations of the current version, rather than features
that are already available.

## My Approach

I built the game step by step, keeping the main parts of the logic in
separate scripts instead of putting everything into one large script.

Each reel is controlled by a `ReelController`, which handles its
movement, symbol looping, and stopping. The `ReelsManager` starts and
coordinates all three reels. When a reel stops, it sends an event with
its result. After all three reels have stopped, the manager passes the
results to `ResultEvaluator`.

`ResultEvaluator` checks whether all three symbols match. The
`AnimationManager` then displays the win or lose panel and plays the
corresponding sound.

I kept these responsibilities separate to make the code easier to
understand, maintain, and extend. Because of the time limit, I focused
first on getting the main slot machine flow working, then added
animations and sound effects. Some planned features had to be left out.

## Built With

-   Unity
-   C#
-   Unity UI
-   Unity Audio System

## Project Structure

``` text
Slot Game/
├── Assets/
│   ├── Animations/
│   ├── Materials/
│   ├── Prefabs/
│   ├── Scenes/
│   ├── Scripts/
│   ├── Sounds/
│   ├── Sprites/
│   └── UI/
├── Build/
│   └── Windows/
└── README.md
```

## Repository

[GitHub Repository](https://github.com/ArkajPatil/Slot-Game)
