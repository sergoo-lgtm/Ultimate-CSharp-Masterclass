<div align="center">

<img src="https://api.iconify.design/vscode-icons:file-type-pdf2.svg?width=120" alt="PDF Aggregator" />

# 🎫 Global Cinema Tickets: ETL Aggregation Engine

*Transforming unstructured PDF tickets into normalized, analytics-ready datasets. A robust showcase of String Manipulation, Culture-Specific Parsing, and Separation of Concerns.*

[![C#](https://img.shields.io/badge/C%23-12.0-239120?style=for-the-badge&logo=c-sharp&logoColor=white)]()
[![.NET Core](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=.net&logoColor=white)]()
[![Architecture](https://img.shields.io/badge/Architecture-ETL_Pipeline-FF9900?style=for-the-badge)]()
[![Library](https://img.shields.io/badge/Library-PdfPig-red?style=for-the-badge)]()

<br/>

> **"Data is only as valuable as it is structured. This engine unlocks sales metrics trapped in thousands of isolated documents."**

</div>

---

## 🚀 The Business Problem

In large-scale multinational cinema chains, sales data is often generated as static PDF receipts rather than being pushed to a centralized database. This creates a massive data silo. 

The **TicketsDataAggregator** acts as a localized **Data Engineering Pipeline**. It automates the extraction of text from disparate PDF files, normalizes fragmented multi-cultural data, and loads it into a consolidated, machine-readable text format for business analytics.

---

## 🛠️ Technical Challenges Solved

This project moves beyond simple file reading by tackling complex string manipulation and data normalization challenges:

* 🌍 **Cross-Cultural Date Parsing:** Cinema tickets come from different locales (e.g., US, France, Japan). The `TicketParser` dynamically identifies and standardizes drastically different date formats (`MM/dd/yyyy`, `dd/MM/yyyy`, `yyyy/MM/dd`) into a unified `CultureInfo.InvariantCulture`.
* ✂️ **Advanced String Manipulation:** Implemented robust text-slicing logic and regex-like pattern matching to extract exact values (Prices, Times, Movie Titles) from messy, unstructured PDF text dumps.
* 🧱 **Strict Separation of Concerns (SoC):** The reading, parsing, and writing responsibilities are tightly encapsulated, allowing the engine to be easily extended (e.g., swapping local file storage for an AWS S3 bucket) without touching the core extraction logic.

---

## 🔄 The ETL Pipeline Architecture

*A visual representation of how unstructured documents are ingested, transformed, and exported.*

```mermaid
%%{init: {'theme': 'dark', 'themeVariables': { 'primaryColor': '#ef6c00', 'edgeLabelBackground':'#111'}}}%%
graph TD
    User([👤 Trigger]) -->|Provide Directory| Program[🚀 Program Orchestrator]
    Program -->|Initialize| Aggregator[⚙️ Core Aggregator]
    
    subgraph Phase 1: Extract
        Aggregator -->|Iterate Files| Reader[📖 Document Reader]
        Reader -->|PdfPig Engine| PDF[(📄 Raw PDF Files)]
        PDF -->|Unstructured Text| Reader
    end
    
    subgraph Phase 2: Transform
        Reader -->|Pass Text| Parser[🧠 Ticket Parser]
        Parser -->|String Manipulation| Logic{Detect Culture & Format}
        Logic -->|Normalize| TicketObj[🎫 Structured Ticket Record]
    end
    
    subgraph Phase 3: Load
        TicketObj -->|Pass Entity| Writer[💾 File Writer]
        Writer -->|Persist Data| Output[(📊 Aggregated_Data.txt)]
    end

    style Program fill:#239120,stroke:#fff
    style Aggregator fill:#512BD4,stroke:#fff
    style Logic fill:#FF9900,stroke:#fff
