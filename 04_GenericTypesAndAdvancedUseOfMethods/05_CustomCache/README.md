<div align="center">

<img src="https://api.iconify.design/vscode-icons:folder-type-controller.svg?width=120" alt="Proxy Pattern" />

# 🚀 Smart Caching Proxy: Enterprise Performance

*Intercepting latency and optimizing I/O. A deep dive into the Proxy Design Pattern combined with highly efficient Generic Caching.*

[![C#](https://img.shields.io/badge/C%23-12.0-239120?style=for-the-badge&logo=c-sharp&logoColor=white)]()
[![.NET](https://img.shields.io/badge/.NET-Core-5C2D91?style=for-the-badge&logo=.net&logoColor=white)]()
[![Design Pattern](https://img.shields.io/badge/Architecture-Proxy_Pattern-FF9900?style=for-the-badge)]()
[![Performance](https://img.shields.io/badge/Performance-O(1)_Caching-0078D4?style=for-the-badge)]()

<br/>

> **"Fetch once, serve instantly. The cheapest request is the one you never make."**

</div>

---

## 🧐 The Architectural Problem

In real-world backend systems, calling external services, querying databases, or executing heavy algorithms (`SlowDownloader`) is expensive. It consumes bandwidth, blocks threads, and creates severe latency for the end-user. 

Directly coupling the client to these slow processes is a critical bottleneck.

---

## 💡 The Proxy Solution

This project introduces a **Smart Caching Proxy** that implements the exact same interface as the `SlowDownloader`, but acts as an invisible shield in front of it. 

By leveraging **C# Generics (`T`)** and an in-memory `Dictionary`, the Proxy intercepts every request:
1.  **Cache Hit:** If the data was requested before, it bypasses the slow source entirely and returns the result instantly from RAM in **O(1)** time complexity.
2.  **Cache Miss:** If it's a new request, it fetches the data, saves a copy in the cache, and then returns it. Subsequent calls for the same data are now instantaneous.

---

## 🔄 System Design: Data Flow

*A sequence diagram illustrating how the Proxy intercepts and handles client requests to prevent unnecessary network/disk I/O.*

```mermaid
%%{init: {'theme': 'dark', 'themeVariables': { 'primaryColor': '#20B2AA'}}}%%
sequenceDiagram
    actor Client
    participant Proxy as CachingProxy<T>
    participant Cache as In-Memory Dictionary
    participant API as SlowDownloader
    
    Client->>Proxy: Request Data (Key)
    Proxy->>Cache: Check Key Existence
    
    alt Is Cached (Cache Hit)
        Cache-->>Proxy: Return Cached Data
        Proxy-->>Client: ⚡ Return Instantly (0ms Latency)
        
    else Not Cached (Cache Miss)
        Cache-->>Proxy: Null / Not Found
        Proxy->>API: Execute Fetch(Key)
        Note right of API: 🐢 Expensive I/O Operation<br/>(Network/Database)
        API-->>Proxy: Return Fresh Data
        Proxy->>Cache: Store (Key, Fresh Data)
        Proxy-->>Client: Return Data
    end
