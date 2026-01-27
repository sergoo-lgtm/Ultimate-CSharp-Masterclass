# 🏃‍♂️ Maze Game: Console Edition

A retro-style, console-based Maze Game built with **C#**. This project demonstrates the use of **2D Arrays**, **Interfaces**, and **Collision Detection** logic to create an interactive gaming experience directly in the terminal.

## 🎮 Overview

The player controls a character (😋) navigating through a procedurally generated maze of brick walls (🧱). The objective is to navigate the open paths (⬜) without hitting obstacles.

The game features a custom rendering engine that redraws the maze state in real-time based on player input.

## ✨ Key Features

* **Grid-Based Movement:** Precise X/Y coordinate tracking.
* **Collision Detection:** The player cannot walk through walls (`IsSolid` check).
* **Procedural Map Generation:** The maze layout is generated using mathematical logic rather than a hardcoded map.
* **OOP Design:** Utilizes the `IMazeItem` interface to treat all grid elements (Walls, Empty ways) polymorphically.
* **Emoji Graphics:** Unicode support for a visually engaging console UI.

## 🏗️ Architecture & Class Diagram

The project uses a clean separation between the maze structure and the items within it.

```mermaid
classDiagram
    class IMazeItem {
        <<interface>>
        +string Symbol
        +bool IsSolid
    }

    class Walls {
        +Symbol : "🧱"
        +IsSolid : true
    }

    class Emptyway {
        +Symbol : "⬜"
        +IsSolid : false
    }

    class Player {
        +int X
        +int Y
        +Symbol : "😋"
    }

    class Maze {
        -int _width
        -int _height
        -IMazeItem[,] arrOfmazeShape
        +Draw()
        +MovePlayer()
        -UpdatePlayer(dx, dy)
    }

    IMazeItem <|.. Walls : Implements
    IMazeItem <|.. Emptyway : Implements
    IMazeItem <|.. Player : Implements
    Maze o-- IMazeItem : Aggregates
    Maze --> Player : Controls
