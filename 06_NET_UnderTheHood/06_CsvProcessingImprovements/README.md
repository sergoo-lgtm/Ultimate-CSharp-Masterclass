# 🚀 High-Performance CSV Data Processor

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Performance](https://img.shields.io/badge/Focus-Performance%20Optimization-orange?style=for-the-badge)
![Status](https://img.shields.io/badge/Status-Completed-success?style=for-the-badge)

> **"Make it work, make it right, make it fast."** – Kent Beck

## 📖 Overview

This project is a refactoring assignment from the **"Ultimate C# Masterclass"**. The main objective is to optimize a CSV processing library that handles large datasets (e.g., 400+ columns, 4000+ rows).

The goal was to rewrite the core data structure to significantly reduce **Memory Consumption** and improve **Execution Speed** without altering the external API or existing tests.

---

## 🧐 The Challenge (Before Optimization)

The legacy implementation (`TableDataBuilder`) relied heavily on generic collections that introduced significant overhead:

* **Data Structure:** `List<Row>` where each `Row` contained a `Dictionary<string, object>`.
* **The Issue:**
    * **Memory Overhead:** Creating a `Dictionary` for every single row is expensive. The overhead of hashing and storage for 4000 rows x 430 columns resulted in massive memory bloat.
    * **Performance:** Lookup times and object allocations slowed down the reading process.

---

## 💡 The Solution (After Optimization)

I introduced a new implementation, `FastTableDataBuilder`, which shifts from dynamic collections to fixed-size arrays.

### Key Improvements:
1.  **2D Arrays (`object[,]`):**
    * Instead of a `List` of `Dictionaries`, I used a single **2-Dimensional Array**.
    * Since the CSV dimensions (Rows x Columns) are known after reading, arrays provide the most memory-efficient storage with **O(1)** access time.
    
2.  **Mapping Optimization:**
    * Column names are stored separately in an indexed collection. Values are accessed directly via index, eliminating the need for repeated hash lookups found in Dictionaries.

3.  **Type Parsing:**
    * Efficiently handles and converts `bool`, `int`, `decimal`, and `string` types, handling `null` values gracefully.

---

## 📊 Performance Benchmarks

The solution includes a `TableDataPerformanceMeasurer` to verify the improvements.

| Metric | Old Solution (Dictionary) | New Solution (2D Array) | Improvement |
| :--- | :--- | :--- | :--- |
| **Memory Consumption** | High (Heavy Allocations) | **Low (Contiguous Memory)** | ⬇️ **~60-70% Less Memory** |
| **Load Time** | Slower | **Faster** | ⚡ **Significant Speedup** |

*(Note: Actual numbers depend on the machine and dataset size, but the improvement order of magnitude is consistent.)*

---

## 💻 Tech Stack & Concepts

* **Language:** `C#` (.NET)
* **Concepts:**
    * Memory Management & Optimization.
    * Data Structures (Arrays vs. Dictionaries).
    * Interfaces & Polymorphism (`ITableDataBuilder`).
    * Benchmarking.

---

## 🛠️ How to Run

1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/YourUsername/Csv-Optimization-Project.git](https://github.com/YourUsername/Csv-Optimization-Project.git)
    ```
2.  **Open the solution:**
    Open the `.sln` file in **Visual Studio** or **Rider**.
3.  **Run the application:**
    Set the project as the startup project and run. The `Program.cs` will execute a comparison test:
    ```csharp
    // It will run the old code first, then the new code, and compare results.
    var testResult = TableDataPerformanceMeasurer.Test(tableDataBuiler, csvData);
    var testResultForNewCode = TableDataPerformanceMeasurer.Test(fastTableDataBuiler, csvData);
    ```

---

## 👨‍💻 Author

**Youssef** - *Physical Therapist & Software Engineer* Transitioning into tech with a passion for building efficient, high-quality software.

---
