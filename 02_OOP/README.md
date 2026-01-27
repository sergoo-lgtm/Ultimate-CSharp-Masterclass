# 🏰 Object-Oriented Programming (OOP) Workshop

![C# OOP](https://img.shields.io/badge/Concept-Object_Oriented_Design-purple?style=for-the-badge&logo=c-sharp&logoColor=white)
![Status](https://img.shields.io/badge/Projects-4_Completed-success?style=for-the-badge)

Welcome to the **OOP Laboratory**. This directory marks the transition from basic scripting to **Software Engineering**. Here, every project is crafted to demonstrate specific pillars of OOP: **Encapsulation**, **Inheritance**, **Polymorphism**, and **Abstraction**.

## 🎯 Learning Goals

The goal of this module is to move away from "Spaghetti Code" and start building systems that are:
* **Maintainable:** Easy to fix and update.
* **Extensible:** Easy to add new features without breaking old ones.
* **Reusable:** Components can be used in different parts of the app.

---

## 📂 Project Catalog

Each project in this folder targets a specific set of OOP skills.

| Project Folder | Difficulty | Key Concepts Covered |
| :--- | :--- | :--- |
| **[🎲 Dice Roll Game](./02_DiceRollGame)** | 🟢 Beginner | **Classes & Objects**, Separation of Concerns, Input Validation. |
| **[📚 Library System](./02_LibrarySystem)** | 🟡 Intermediate | **Inheritance**, **Abstraction**, Role-Based Logic (Admin vs User). |
| **[🧩 Maze Game](./02_MAZEGAME)** | 🔴 Advanced | **Interfaces**, **Polymorphism**, 2D Arrays, Game Logic. |
| **[📊 Text Analyzer](./02_TextDataAnalyzer)** | 🟠 Intermediate | **Polymorphism**, Strategy Pattern, File I/O, Structs. |

---

## 🧠 OOP Pillars in Action

Here is how these projects map to the core principles of OOP:

```mermaid
graph TD
    OOP[OOP Pillars]
    
    subgraph P1 [Encapsulation]
    D[Dice Game] -->|Private Fields| ProtectData[Protect State]
    end
    
    subgraph P2 [Inheritance]
    L[Library System] -->|User -> Librarian| Reuse[Reuse Logic]
    end
    
    subgraph P3 [Polymorphism]
    T[Text Analyzer] -->|IFileAnalysis| Flex[Flexible Behavior]
    M[Maze Game] -->|IMazeItem| Unified[Unified Interface]
    end

    OOP --> P1
    OOP --> P2
    OOP --> P3
