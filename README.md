# Slot Machine Game

A simple slot machine game made with Unity and C#. The game has three
reels. Spin them and try to get the same symbol on all three to win.

## Game Overview

Each reel spins and stops on a randomly selected symbol. Once all three
reels have stopped, the game checks the results and shows a win or lose
screen.

### Features

-   Three independently controlled reels
-   Random symbol selection
-   Smooth reel movement and stopping
-   Looping symbols while the reels are spinning
-   Win and lose detection
-   Win and lose result animations
-   Sound effects for spinning, symbol ticks, winning, and losing
-   Animated slot machine lever

## How to Run the WebGL Build

1.  Download or clone this repository.
2.  Open the `Build/WebGL` folder.
3.  Run the build using a local web server, or host the folder on a web
    server.
4.  Open the hosted `index.html` page in your browser.

**Note:** Opening `index.html` directly from your file explorer may not
work because browsers restrict some features when a WebGL build is
opened as a local file.

## Bonus Features

Along with the basic slot machine functionality, the project includes:

-   **Sound effects:** Audio feedback during reel spinning, symbol
    changes, winning, and losing.
-   **Lever animation:** The lever has an animation to make the spin
    interaction feel more natural.
-   **Result animations:** Separate win and lose panels appear after the
    reels stop, then fade away.
-   **Automatic return:** The game returns to the main screen after the
    result animation finishes.

## My Approach

I built the game in small parts instead of putting all the logic into
one large script.

Each reel is controlled separately by a `ReelController`. This keeps the
movement and stopping logic for each reel independent.

The `ReelsManager` takes care of starting all the reels and waiting for
them to finish. When a reel stops, it sends an event with its result.
After all three reels have stopped, the manager passes the results to
`ResultEvaluator`.

`ResultEvaluator` checks whether all three symbols match. The
`AnimationManager` then shows the appropriate win or lose panel and
plays the matching sound effect.

I kept these responsibilities separate so the code is easier to
understand, maintain, and extend later.

## Built With

-   Unity
-   C#
-   Unity UI
-   Unity Audio System
-   Unity WebGL

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
│   └── WebGL/
└── README.md
```

## Repository

[GitHub Repository](https://github.com/ArkajPatil/Slot-Game)
