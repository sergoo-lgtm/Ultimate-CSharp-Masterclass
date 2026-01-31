# 🎬 CimaStream Analytics

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![LINQ](https://img.shields.io/badge/LINQ-Query_Master-0078D4?style=for-the-badge)

**CimaStream Analytics** is a high-performance console application simulating a backend data processing engine for a movie streaming service. 

This project demonstrates advanced mastery of **LINQ (Language Integrated Query)** in C#, showcasing complex data manipulation, relational joining, and statistical aggregation without relying on external databases.

---

## 🚀 Key Features

This project moves beyond basic filtering, implementing complex functional programming concepts:

* **🧬 Complex Relations (GroupJoin):** Implementing "Left Outer Joins" to correlate Users with their Watching History, calculating stats even for inactive users.
* **📦 Data Flattening (SelectMany):** Extracting and de-duplicating nested collections (Genres) into a single linear stream.
* **📊 Aggregation & Analytics:** Using custom accumulators to generate reports and string concatenations.
* **⚡ Quantifiers & Partitioning:** Efficient data validation (`All`, `Any`) and pagination logic (`Skip`, `Take`).
* **🔍 High-Speed Lookups:** converting lists to `Dictionary` for O(1) access performance.

---

## 🛠️ Technology Stack

* **Language:** C# 12 (Modern Syntax)
* **Framework:** .NET 8.0
* **Paradigm:** Functional Programming (LINQ) & OOP
* **Style:** Top-Level Statements

---

## 🧠 Code Highlights

### The "Binge Watcher" Logic (GroupJoin)
One of the most powerful parts of the system is joining `Users` with `WatchLogs` to generate a dynamic report:

```csharp
var userStats = users.GroupJoin(
    history,
    u => u.Id,          // Outer Key
    h => h.UserId,      // Inner Key
    (user, logs) => new // Result Selector
    {
        UserName = user.Name,
        TotalMinutes = logs.Sum(l => l.MinutesWatched),
        Status = logs.Sum(l => l.MinutesWatched) > 150 ? "🔥 Binge Watcher" : "😐 Casual"
    }
).OrderByDescending(s => s.TotalMinutes);
