# 🎲 Dice Roll Game

A simple yet interactive console-based game written in **C#**, demonstrating fundamental **Object-Oriented Programming (OOP)** concepts. The player challenges the computer by guessing the number rolled on a six-sided die.

## 🚀 Overview

This project is not just a game; it's a practical implementation of:
* **Separation of Concerns:** Distinct classes for Game logic, Player interaction, and Dice behavior.
* **Input Validation:** Robust handling of user inputs (strings, out-of-range numbers).
* **Console UI:** Enhanced user experience using colored console output.

## ✨ Key Features

* **OOP Design:** Clean structure using `Game`, `Dice`, and `Player` classes.
* **Smart Validation:** The game doesn't crash on wrong inputs; it guides the user.
* **Visual Feedback:**
    * 🟢 **Green** for winning.
    * 🔴 **Red** for errors/losing.
    * 🟡 **Yellow** for warnings.
* **Retry System:** You get **3 chances** to guess the correct number.

## 🏗️ Architecture (Class Diagram)

The project follows a modular structure where the `Game` class orchestrates the interaction between the `Player` and the `Dice`.

```mermaid
classDiagram
    class Game {
        -Dice dice
        -Player player
        -int maxTries
        +Start()
    }
    class Dice {
        -Random random
        +Roll() int
    }
    class Player {
        +IsNumber(userInput, out int) bool
    }

    Game --> Dice : Uses
    Game --> Player : Uses
