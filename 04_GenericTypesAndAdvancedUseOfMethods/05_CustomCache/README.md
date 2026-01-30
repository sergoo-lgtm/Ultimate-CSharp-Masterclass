# 🚀 Smart Caching Proxy in C#

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Design Pattern](https://img.shields.io/badge/Pattern-Proxy-blue?style=for-the-badge)

## 🧐 Overview 

This project demonstrates how to optimize performance using the **Proxy Design Pattern** combined with a **Generic Caching Mechanism**.

Instead of fetching data from a slow source every time (simulating network latency), we use a "Smart Proxy" that checks a local cache first. If the data exists, it returns immediately. If not, it fetches, caches, and then returns.

> **Key Concept:** "Fetch once, use everywhere." ⚡

---

## 🎨 Architecture 

How the request flows through the `CachingDataDownloader`:

```mermaid
graph LR
    User([User / Client]) -->|Request Data| Proxy[Caching Proxy]
    Proxy -->|Check Cache| Cache{Is Cached?}
    
    Cache -- Yes --> Return[Return Data ⚡]
    Cache -- No --> Slow[Slow Downloader 🐢]
    
    Slow -->|Fetch Data| Proxy
    Proxy -->|Save to Memory| Proxy
    Proxy --> Return
    Return --> User
