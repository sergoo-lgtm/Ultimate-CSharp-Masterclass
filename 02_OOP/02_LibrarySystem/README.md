# 📚 Library Management System

A console-based application designed to manage library operations. This project demonstrates core **Object-Oriented Programming (OOP)** concepts, specifically **Inheritance**, **Abstraction**, and **Encapsulation**.

## 🚀 Overview

The system simulates a real-world library environment where users are divided into two roles:
1.  **Librarian:** Has administrative privileges to manage the book collection (Add/Remove).
2.  **Regular User:** Can browse the collection and borrow books.

The application acts as a sandbox for understanding how objects interact within a C# environment using arrays for data storage.

## ✨ Key Features

* **Role-Based Access Control (RBAC):** Distinct workflows for Librarians and Regular Users.
* **Book Management:**
    * **Add:** Insert new books with details (Title, Author, Year).
    * **Remove:** Delete books from the catalog.
    * **Display:** List all available books.
* **Borrowing System:** Users can borrow books (managed via a separate tracking array).
* **Polymorphism in Action:** Both `Librarian` and `LibraryUser` inherit from a base `User` class but extend functionality differently.

## 🏗️ Architecture & Class Diagram

The project uses an **Abstract Base Class** (`User`) to define common behaviors, while specialized classes handle specific roles.

```mermaid
classDiagram
    class User {
        <<Abstract>>
        +string Name
        +displaybooks(Library library)
    }

    class Librarian {
        +int EmployeeID
        +addbook(Book, Library)
        +removebook(Book, Library)
    }

    class LibraryUser {
        +borrowbook(Book, Library)
    }

    class Library {
        -Book[] Books
        -Book[] BorrowedBooks
        +add(Book)
        +remove(Book)
        +borrow(Book)
        +display()
    }

    class Book {
        +string Title
        +string Author
        +int Year
    }

    User <|-- Librarian : Inherits
    User <|-- LibraryUser : Inherits
    Librarian ..> Library : Manages
    LibraryUser ..> Library : Uses
    Library o-- Book : Aggregates
