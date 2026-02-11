<div align="center">

<img src="https://raw.githubusercontent.com/Tarikul-Islam-Anik/Animated-Fluent-Emojis/master/Emojis/Animals/Snake.png" alt="Snake" width="120" />

# 🐍 Terminal Snake: A C# & OOP Masterclass

**Breathing new life into a retro classic using modern C#, robust Object-Oriented Design, and efficient Data Structures.**

[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)]()
[![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)]()
[![Clean Code](https://img.shields.io/badge/Clean_Code-FF9900?style=for-the-badge&logo=awsorganizations&logoColor=white)]()
[![Data Structures](https://img.shields.io/badge/LinkedList-0078D4?style=for-the-badge&logo=data-datacamp&logoColor=white)]()

---


> **"It's not just about moving a snake; it's about moving data efficiently."**


---

## ⚡ Technical Highlights

This isn't your average beginner tutorial snake game. It is carefully architected to demonstrate backend and software engineering fundamentals:

- 🧠 **Smart Memory Management:** Utilized `struct` for `Position` (Value Types) to reduce garbage collection overhead during rapid grid calculations.
- ⚡ **O(1) Complexity:** Employed `LinkedList<Position>` for the snake's body. Adding a new head and removing the tail happens in constant time $O(1)$, completely avoiding the performance hit of array shifting.
- 🛡️ **Encapsulation & State Control:** Strict access modifiers restrict state mutation. The `GameState` tightly controls the flow, ensuring the UI (Console) only renders what is calculated.

---

## 🏗️ System Architecture

### 1. The Object-Oriented Blueprint
*A look under the hood at how the classes interact to maintain a scalable codebase.*

```mermaid
%%{init: {'theme': 'dark', 'themeVariables': { 'primaryColor': '#239120', 'edgeLabelBackground':'#111'}}}%%
classDiagram
    direction TB
    class GameState {
        +int Rows
        +int Cols
        +int Score
        +bool GameOver
        +Update()
        +ChangeDirection(Direction)
    }
    class Snake {
        +Direction Direction
        +LinkedList~Position~ Body
        +Move()
        +Grow()
        +CalculateNextHeadPosition()
    }
    class Position {
        <<struct>>
        +int Row
        +int Col
        +Translate(Direction)
    }
    
    GameState "1" *-- "1" Snake : Controls
    GameState "1" *-- "1" Position : Manages Food
    Snake "1" *-- "*" Position : Composed of
