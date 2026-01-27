# 🧮 Console Calculator

A beginner-friendly, command-line calculator built with **C#**. This project demonstrates the basics of **Input/Output operations**, **Control Flow**, and **Methods** in .NET.

## 🚀 Overview

This application takes two integer inputs from the user and performs basic arithmetic operations based on the user's choice. It serves as a foundational exercise for understanding `switch` statements and basic error handling.

## ✨ Key Features

* **Arithmetic Operations:** Supports Addition, Subtraction, Multiplication, and Division.
* **Smart Division:** Includes a safety check to prevent crashing when dividing by zero.
* **Case Insensitive:** Accepts lowercase (`a`, `s`) and uppercase (`A`, `S`) inputs seamlessly.
* **Clean Code:** Uses a **Local Function** (`PrintOperation`) to avoid code repetition and keep the `switch` statement clean.

## 🔄 Logic Flow

The program follows a linear flow with a decision branch for the operation type.

```mermaid
graph TD
    A([Start]) --> B[/Input Number 1/]
    B --> C[/Input Number 2/]
    C --> D[/Select Operation/]
    D --> E{Switch Input}
    
    E -- "A" --> F[Add]
    E -- "S" --> G[Subtract]
    E -- "M" --> H[Multiply]
    E -- "D" --> I{Is Num2 == 0?}
    
    I -- No --> J[Divide]
    I -- Yes --> K[Show Error Message]
    E -- Invalid --> L[Show Invalid Choice]

    F --> M[Print Result]
    G --> M
    H --> M
    J --> M
    K --> N([End])
    L --> N
    M --> N
