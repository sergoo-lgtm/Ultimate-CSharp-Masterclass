# 📂 Text Data Analyzer

A powerful, extensible file analysis tool built with **C#**. This application scans directories for specific file types (`.txt`, `.csv`) and performs content analysis using a polymorphic architecture.

## 🚀 Overview

**TextDataAnalyzer** automates the process of extracting metadata from text-based files. Instead of manually opening files to check their size or structure, this tool iterates through a folder and applies specific analysis logic based on the file extension.

It serves as a practical implementation of **OOP Principles**:
* **Inheritance:** Sharing common state logic via `FileAnalyzer`.
* **Interfaces:** Enforcing a contract via `IFileAnalysis`.
* **Polymorphism:** Treating different file analyzers uniformly at runtime.

## ✨ Key Features

* **Folder Scanning:** Recursively reads files from a user-provided directory path.
* **TXT Analysis:**
    * 📝 Word Count
    * 🔡 Character Count
    * 📄 Line Count
* **CSV Analysis:**
    * 📊 Field (Column) Count detection.
* **Extensible Design:** Easily add support for new formats (e.g., JSON, XML) without breaking existing code.

## 🏗️ Architecture & Class Diagram

The project uses a hybrid approach combining a Base Class for state management and an Interface for behavior execution.

```mermaid
classDiagram
    class IFileAnalysis {
        <<interface>>
        +AnalyzeFile(FileInfo file)
    }

    class FileAnalyzer {
        -AnalysisResult _results
        +GetAnalysisResult()
        +SetAnalysisResult()
    }

    class TxtFileAnalyzer {
        +AnalyzeFile(FileInfo)
    }

    class CsvFileAnalyzer {
        +AnalyzeFile(FileInfo)
    }

    class AnalysisResult {
        <<struct>>
        +int WordCount
        +int CharCount
        +int LineCount
        +int FieldCount
    }

    FileAnalyzer <|-- TxtFileAnalyzer : Inherits
    FileAnalyzer <|-- CsvFileAnalyzer : Inherits
    IFileAnalysis <|.. TxtFileAnalyzer : Implements
    IFileAnalysis <|.. CsvFileAnalyzer : Implements
    FileAnalyzer *-- AnalysisResult : Contains
