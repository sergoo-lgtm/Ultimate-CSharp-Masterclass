# 🎫 Global Cinema Tickets Aggregator

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![PdfPig](https://img.shields.io/badge/PDF_Pig-Library-red?style=for-the-badge)

> **A robust ETL (Extract, Transform, Load) solution designed to automate the extraction of sales data from unstructured PDF tickets across multiple international locales.**

---

## 🚀 Project Overview

In the context of a global cinema chain, sales data was trapped inside thousands of generated PDF tickets without a centralized database. This application serves as a **Data Aggregation Engine**.

It scans directories, extracts unstructured text from PDFs, applies intelligent parsing logic to handle multi-cultural date formats (US, France, Japan), and normalizes the data into a structured, invariant format suitable for analytics.

---

## 🏗️ Architecture & Data Flow

The solution follows the **Separation of Concerns (SoC)** principle. Each class has a single, distinct responsibility, orchestrated by a central Aggregator.

```mermaid
graph TD
    User([👤 User]) -->|Input Folder Path| Program[🚀 Program.cs]
    Program -->|Initialize| Aggregator[⚙️ TicketsAggregator]
    
    subgraph Core Logic
        Aggregator -->|1. Read File| Reader[📖 PdfReader]
        Reader -->|Uses PdfPig| PDF[(📄 PDF File)]
        PDF -->|Raw Text| Reader
        Reader -->|Returns String| Aggregator
        
        Aggregator -->|2. Parse Text| Parser[🧠 TicketParser]
        Parser -->|Detect Culture & Extract| TicketObj[🎫 Ticket Object]
        TicketObj -->|Returns List| Aggregator
    end
    
    Aggregator -->|3. Save Data| Writer[💾 FileWriter]
    Writer -->|Format & Write| Output[(📄 aggregatedTickets.txt)]

    %% Styling Section - High Contrast Colors
    classDef mainNode fill:#ffffff,stroke:#333,stroke-width:2px,color:#000;
    classDef logicNode fill:#e1f5fe,stroke:#0277bd,stroke-width:2px,color:#000;
    classDef dataNode fill:#fff3e0,stroke:#ef6c00,stroke-width:2px,color:#000;
    classDef fileNode fill:#f3e5f5,stroke:#7b1fa2,stroke-width:2px,color:#000;

    class Aggregator,Program mainNode;
    class Reader,Parser,Writer logicNode;
    class TicketObj,User dataNode;
    class PDF,Output fileNode;
