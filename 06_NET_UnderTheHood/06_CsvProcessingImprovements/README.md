<div align="center">

<img src="https://api.iconify.design/vscode-icons:file-type-excel.svg?width=120" alt="CSV Optimization" />

# 🚀 High-Performance CSV Engine: The Memory Optimization Lab

*From heavy allocations to contiguous memory. A deep dive into .NET Garbage Collection, Data Locality, and algorithmic efficiency for large-scale datasets.*

[![C#](https://img.shields.io/badge/C%23-12.0-239120?style=for-the-badge&logo=c-sharp&logoColor=white)]()
[![.NET](https://img.shields.io/badge/.NET-Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)]()
[![Performance](https://img.shields.io/badge/Architecture-Memory_Optimization-FF9900?style=for-the-badge)]()
[![Status](https://img.shields.io/badge/Status-Benchmark_Passed-success?style=for-the-badge)]()

<br/>

> **"Make it work, make it right, make it fast."** – *Kent Beck*

</div>

---

## 🧠 The Engineering Philosophy

In modern backend architecture—especially when deploying microservices to memory-constrained environments like **Docker containers** or Cloud instances—every megabyte counts. 

This project is a rigorous refactoring exercise from the *"Ultimate C# Masterclass"*. The objective was clear: Take a working, but heavily bloated CSV processor handling massive datasets (4000+ rows, 430+ columns), and completely rewrite its underlying data structure to slash **Memory Consumption** and eliminate **Garbage Collection (GC) spikes**, all without breaking the existing API contracts.

---

## 🧐 The Bottleneck: The Cost of Abstraction

The legacy implementation (`TableDataBuilder`) relied on nested generic collections:
* **The Structure:** `List<Row>` where each `Row` contained a `Dictionary<string, object>`.
* **The Silent Killer:**
    * **Heap Fragmentation:** Creating a new `Dictionary` for *every single row* resulted in millions of small object allocations.
    * **Hashing Overhead:** Retrieving a value required calculating a string hash 430 times per row. 
    * **GC Pressure:** The Garbage Collector was forced into overdrive to clean up temporary state objects, severely degrading execution speed.

---

## 💡 The Solution: Data Locality & Arrays

The optimized engine, `FastTableDataBuilder`, strips away the expensive abstractions and returns to computational basics: **Contiguous Memory**.

### 🛠️ Key Architectural Shifts:
1.  **The 2D Array Matrix (`object[,]`):**
    * Replaced the `List<Dictionary>` completely with a single, flat, Two-Dimensional Array.
    * By calculating the exact dimensions of the CSV upfront, we allocate memory exactly **once**. This guarantees contiguous memory blocks and zero dynamic resizing.
2.  **O(1) Indexed Lookups:**
    * Column headers are parsed once and mapped to integer indices. 
    * Value retrieval shifts from an expensive string hash lookup to a raw, instantaneous integer index access.
3.  **Strict Type Parsing:**
    * Implemented aggressive, low-allocation type checking for `bool`, `int`, `decimal`, and `string`, bypassing heavy reflection and handling `null` references safely.

---

## 🏗️ Memory Layout Comparison

*Visualizing the shift from fragmented heap allocations to a single, contiguous memory block.*

```mermaid
%%{init: {'theme': 'dark', 'themeVariables': { 'primaryColor': '#239120', 'edgeLabelBackground':'#111'}}}%%
graph LR
    subgraph Legacy [Old: List of Dictionaries]
        A[List] --> B(Dict Row 1)
        A --> C(Dict Row 2)
        A --> D(Dict Row 3)
        B --> E[Hash/Pointers scattered in Heap]
    end

    subgraph Optimized [New: 2D Array Matrix]
        F[object, Array] --> G[Contiguous Memory Block]
        G --> H[Row 1 | Row 2 | Row 3]
    end
    
    style Legacy fill:#440000,stroke:#ff0000
    style Optimized fill:#004400,stroke:#00ff00
