# 🎮 Game Data Parser

A robust, console-based C# application designed to parse, validate, and display video game data from JSON files. This project serves as a practical demonstration of **SOLID principles**, **Dependency Injection**, and **Defensive Programming**.

## 🚀 Overview

**GameDataParser** isn't just a file reader; it's an architectural showcase. It decouples the processes of reading files, parsing data, and user interaction, making the application highly maintainable and testable.

It features a custom error-reporting system that highlights syntax errors in malformed JSON files, providing context to the user immediately.

## ✨ Key Features

* **Clean Architecture:** Built using Interfaces (`IFileReader`, `IGameParser`, `ILogger`, `IUserInteractor`) to ensure low coupling.
* **Smart Error Handling:**
    * Catches `JsonException` and identifies the exact line of failure.
    * Displays a snippet of the file with a visual pointer (`>>>>>>>>`) to the error.
* **Logging:** Automatically logs exceptions to a local `log.txt` file for debugging.
* **User-Friendly Interface:** Interactive console prompts with clear validation messages.

## 🏗️ Architecture & Design Pattern

The project implements a **Manual Dependency Injection** pattern.

```mermaid
classDiagram
    class GameDataParserApp {
        +Start()
    }
    class IFileReader {
        <<interface>>
        +Read(filename)
    }
    class IGameParser {
        <<interface>>
        +JsonParse(content)
    }
    class ILogger {
        <<interface>>
        +Log(message)
    }
    class IUserInteractor {
        <<interface>>
        +GameName()
        +Gamedisplay()
    }

    GameDataParserApp --> IFileReader
    GameDataParserApp --> IGameParser
    GameDataParserApp --> ILogger
    GameDataParserApp --> IUserInteractor