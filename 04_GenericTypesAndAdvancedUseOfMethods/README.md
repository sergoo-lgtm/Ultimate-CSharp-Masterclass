<div align="center">

<img src="https://api.iconify.design/noto:rocket.svg?width=120" alt="Rocket" />

# ⚡ Performance & State Management Lab

*Where code goes from "just working" to "blazing fast". A deep dive into memory optimization, time complexity reduction, and advanced state tracking.*

[![C#](https://img.shields.io/badge/C%23-12.0-239120?style=for-the-badge&logo=c-sharp&logoColor=white)]()
[![.NET Core](https://img.shields.io/badge/.NET-Core-5C2D91?style=for-the-badge&logo=.net&logoColor=white)]()
[![Design Patterns](https://img.shields.io/badge/Architecture-Design_Patterns-FF9900?style=for-the-badge)]()
[![Data Structures](https://img.shields.io/badge/Data-Structures-0078D4?style=for-the-badge)]()

</div>

---

## 🎯 The Engineering Goal

In enterprise-level applications, primitive arrays and direct, repetitive network calls create massive bottlenecks. This module marks the transition to **Senior-Level thinking**, demonstrating how to write highly optimized backend systems by mastering two core pillars:

1. **Minimizing Latency:** Implementing caching layers to intercept and reduce expensive data-fetching operations.
2. **Managing Complex State:** Utilizing specific Generic Collections to handle data flows with optimal Big O time complexity.

---

## 📂 Inside the Lab

This repository contains two core projects, each engineered to solve a distinct architectural challenge:

### 1. 🚀 [Smart Caching Proxy](./SmartCachingProxy)
*A masterclass in reducing Network I/O and Time Complexity.*

* **The Bottleneck:** Repeatedly fetching unchanged data from a slow source (simulated API/Database) degrades system performance.
* **The Architecture:** Implemented the **Proxy Design Pattern** acting as a middleman. 
* **The Mechanism:** "Fetch once, serve from memory." The proxy intercepts requests, checks a local cache dictionary, and returns data instantly if available, drastically reducing load times.

### 2. 🛒 [Smart Console Shopping Cart](./SmartConsoleShoppingCart)
*A robust state-management engine built entirely on C# Generics.*

* **The Bottleneck:** Managing dynamic states (like a user's cart and undo actions) using basic lists leads to messy, O(N) operations.
* **The Architecture:** * ⚡ `Dictionary<TKey, TValue>` guarantees **O(1)** instant product catalog lookups.
  * ⏪ `Stack<T>` natively drives a highly efficient **LIFO (Last-In-First-Out)** algorithm for the "Undo" feature.
  * 🛡️ `Record` types ensure data immutability and thread safety.
