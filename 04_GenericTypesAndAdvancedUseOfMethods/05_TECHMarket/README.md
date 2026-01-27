# 🛒 Smart Console Shopping Cart

![C#](https://img.shields.io/badge/Language-C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/Platform-.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Status](https://img.shields.io/badge/Status-Completed-success?style=for-the-badge)

A robust, console-based shopping cart application designed to demonstrate the practical power of **C# Generics** and **Collections** in managing data flow and state.

---

## 🚀 Overview

This project simulates a real-world shopping experience where users can add items, view their cart, checkout, and—most importantly—**undo their actions**. 

The core objective was to move away from primitive arrays and leverage the efficiency of **System.Collections.Generic** to build a clean, scalable, and type-safe architecture.

---

## 🛠️ Tech Stack & Key Concepts

This project is a deep dive into C# Data Structures. Here is how I applied them:

### 1. `Dictionary<TKey, TValue>` for Product Lookup
- **Usage:** Used to store the product catalog (`_catalog`).
- **Why?** Provides **O(1)** time complexity for lookups, making product retrieval instant compared to iterating through a list.

### 2. `Stack<T>` for State Management (Undo Logic)
- **Usage:** implemented in `_actionHistory` to track user actions.
- **Why?** The **LIFO (Last-In-First-Out)** nature of a Stack is the perfect algorithmic solution for an "Undo" feature. I stored a `Tuple` of `(ItemName, IsAdded)` to reverse the specific logic of the last action.

### 3. `List<T>` for Dynamic Storage
- **Usage:** Used for `_cartItems`.
- **Why?** Provides a flexible, resizable array to hold the user's selected products.

### 4. `Record` Types (C# 9.0+)
- **Usage:** `public record Product(string Name, decimal Price);`
- **Why?** Utilized for immutable data modeling, ensuring thread safety and cleaner syntax compared to traditional classes.

---

## 🧩 Code Snippet: The "Undo" Logic

One of the most interesting challenges was implementing the Undo feature using a Generic `Stack`:

```csharp
// Storing history as a Tuple in a Stack
static Stack<(string ItemName, bool IsAdded)> _actionHistory = new();

static void UndoAction()
{
    if (_actionHistory.Count > 0)
    {
        var lastAction = _actionHistory.Pop();
        // If it was added, we remove it. If removed, we add it back.
        if (lastAction.IsAdded)
        {
             // Logic to remove item...
        }
        else
        {
             // Logic to restore item...
        }
    }
}
