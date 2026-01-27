# 📝 Console To-Do List

A minimalist, CLI-based task manager built with **C#**. This project serves as a perfect introduction to **Collections (`List<T>`)**, **Loops**, and **Control Flow** in .NET.

## 🚀 Overview

This application allows users to manage their daily tasks directly from the terminal. It features a persistent loop that keeps the application running until the user explicitly chooses to exit, offering a seamless user experience.

## ✨ Key Features

* **Dynamic Storage:** Uses `List<string>` to store an unlimited number of tasks.
* **Interactive Menu:** Simple command-based navigation (`[S]`, `[A]`, `[R]`, `[E]`).
* **Input Handling:** Case-insensitive commands (e.g., 'a' and 'A' both work).
* **Feedback System:** Provides immediate confirmation for adding or removing items.

## 🔄 Program Flow (Logic)

The application runs inside a `do-while` loop to ensure continuous interaction.

```mermaid
graph TD
    A([Start]) --> B{Show Menu}
    B --> C[/User Input/]
    C --> D{Check Choice}
    
    D -- "S" --> E[Display All Tasks]
    D -- "A" --> F[Add New Task]
    D -- "R" --> G[Remove Task by Name]
    D -- "E" --> H([Exit])
    D -- Invalid --> I[Show Error]

    E --> B
    F --> B
    G --> B
    I --> B
