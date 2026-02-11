<div align="center">

<img src="https://raw.githubusercontent.com/Tarikul-Islam-Anik/Animated-Fluent-Emojis/master/Emojis/Activities/Video%20Game.png" alt="Controller" width="120" />

# 🎮 Game Data Parser: Bulletproof JSON Processing

*A masterclass in Defensive Programming and SOLID principles. Because in the real world, data is messy, and applications shouldn't crash.*

[![C#](https://img.shields.io/badge/C%23-12.0-239120?style=for-the-badge&logo=c-sharp&logoColor=white)]()
[![SOLID](https://img.shields.io/badge/Architecture-SOLID-FF9900?style=for-the-badge)]()
[![Clean Code](https://img.shields.io/badge/Pattern-Dependency_Injection-0078D4?style=for-the-badge)]()

</div>

---

## 📖 The Story Behind The Code

Most console parsers just attempt to read a file and throw an ugly system exception if something goes wrong. **GameDataParser** takes a different approach. It acts as an architectural showcase of how to build resilient, decoupled backend systems. 

**The core philosophy?** To completely separate the concerns of file reading, data deserialization, background logging, and user interaction. If the JSON format changes tomorrow, or we decide to log errors to a cloud database instead of a local text file, the core orchestration logic remains completely untouched.

---

## ✨ Why This Architecture Works

* 🛡️ **Defensive Programming:** Anticipates malformed data. Instead of failing silently or crashing abruptly, it catches `JsonException` and points the user *directly* to the exact line of the syntax error with a visual indicator (`>>>>>>>>`).
* 🧩 **Manual Dependency Injection:** Demonstrates a fundamental understanding of **Inversion of Control (IoC)** by injecting dependencies via constructors, without relying on heavy external DI containers.
* 📝 **Resilient Background Logging:** Automatically intercepts exceptions and writes stack traces to a local `log.txt`, keeping the user console clean while maintaining strict audit trails for developers.
* 🔌 **Plug-and-Play Interfaces:** Achieves extremely low coupling through strict interface segregation. 

---

## 🏗️ System Architecture

*A visual representation of how the orchestrator communicates exclusively via abstractions, ensuring high testability and maintainability.*

```mermaid
%%{init: {'theme': 'dark', 'themeVariables': { 'primaryColor': '#0078D4', 'edgeLabelBackground':'#111'}}}%%
classDiagram
    direction TB
    
    class GameDataParserApp {
        +Start()
    }
    
    namespace Abstractions {
        class IFileReader {
            <<interface>>
            +Read(filename) String
        }
        class IGameParser {
            <<interface>>
            +JsonParse(content) GameData
        }
        class ILogger {
            <<interface>>
            +Log(message)
        }
        class IUserInteractor {
            <<interface>>
            +GetGameName() String
            +DisplayGame(GameData)
        }
    }

    GameDataParserApp ..> IFileReader : Injects
    GameDataParserApp ..> IGameParser : Injects
    GameDataParserApp ..> ILogger : Injects
    GameDataParserApp ..> IUserInteractor : Injects
    
    note for GameDataParserApp "Acts as the Application Engine.\nDepends entirely on abstractions, not concretions."
