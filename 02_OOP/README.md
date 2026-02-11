<div align="center">

# 🏗️ The OOP Laboratory: Building Robust Systems

<img src="https://raw.githubusercontent.com/Tarikul-Islam-Anik/Animated-Fluent-Emojis/master/Emojis/Objects/Laptop.png" alt="Laptop" width="120" />

*Transitioning from basic scripting to professional Software Engineering. This directory is a collection of projects crafted to master the core pillars of Object-Oriented Programming.*

[![C#](https://img.shields.io/badge/Language-C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)]()
[![OOP](https://img.shields.io/badge/Architecture-OOP_Design-FFB900?style=for-the-badge&logo=microsoft&logoColor=white)]()
[![Projects](https://img.shields.io/badge/Projects-5_Completed-success?style=for-the-badge)]()

</div>

---

## 🎯 The Engineering Goals

The primary objective of this module is to write code that isn't just "working", but is:
* 🛠️ **Maintainable:** Easy to debug, fix, and update without breaking existing logic.
* 🚀 **Extensible:** Adding new features requires minimal changes to the core engine.
* ♻️ **Reusable:** Components are modular and can be plugged into different parts of the system.

---

## 📂 Project Catalog

Each project targets a specific set of skills, increasing in complexity.

| Project | Difficulty | Focus Area | Core OOP Concepts Explored |
| :--- | :--- | :--- | :--- |
| **[🎲 01. Dice Roll Game](./02_DiceRollGame)** | 🟢 Beginner | State Management | Encapsulation, Classes & Objects |
| **[📚 02. Library System](./02_LibrarySystem)** | 🟡 Intermediate | Domain Modeling | Inheritance, Abstraction, Role Logic |
| **[📊 03. Text Analyzer](./02_TextDataAnalyzer)** | 🟠 Intermediate | Data Parsing | Polymorphism, Strategy Pattern, File I/O |
| **[🧩 04. Maze Game](./02_MAZEGAME)** | 🔴 Advanced | Grid Logistics | Interfaces, Polymorphism, 2D Arrays |
| **[🐍 05. Snake Game](./02_SnakeGame)** | 🔴 Advanced | Game Loop Engine | Memory Management (Structs), Data Structures (`LinkedList`), Strict Encapsulation |

---

## 🧠 The Architecture Mindmap

How these projects map to the 4 Core Pillars of Object-Oriented Programming:

```mermaid
%%{init: {'theme': 'dark', 'themeVariables': { 'primaryColor': '#ff9900', 'edgeLabelBackground':'#111'}}}%%
graph TD
    A{⚙️ Core OOP Pillars} --> B(🔒 Encapsulation)
    A --> C(🧬 Inheritance)
    A --> D(🎭 Polymorphism)
    A --> E(🛡️ Abstraction)

    B -->|Hides Internal State| P1[🎲 Dice Game]
    B -->|Protects Game Loop Logic| P5[🐍 Snake Game]
    
    C -->|Reuses Base Entity Logic| P2[📚 Library System]
    
    D -->|Executes Flexible Strategies| P3[📊 Text Analyzer]
    D -->|Manages Dynamic Entities| P4[🧩 Maze Game]
    
    E -->|Defines Strict Contracts| P4
    E -->|Enforces Business Rules| P2
