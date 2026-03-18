# Product Management System (Repository Pattern Implementation)

A lightweight C# console application demonstrating the **Repository Design Pattern**. This project focuses on the separation of concerns by isolating data access logic from the core business logic.

## 📌 Project Overview
The goal of this project is to manage a product catalog (CRUD operations) while ensuring the main application remains agnostic of the data storage implementation (whether it's In-Memory, SQL, or NoSQL).

## 🛠 Tech Stack
* **Language:** C# 
* **Framework:** .NET 10
* **Pattern:** Repository Design Pattern
* **Storage:** In-Memory (List-based)

---

## 🏗 How the Repository Pattern Works

The Repository Pattern acts as a mediator between the domain and data mapping layers. Here’s how it is structured in this project:

### 1. The Interface (`IProductRepository`)
This is the **Contract**. It defines *what* operations are available (Add, Get, Update, Delete) without specifying *how* they are performed. 
- **Benefit:** It allows us to swap data sources (e.g., moving from a List to a Database) without changing the code in `Program.cs`.

### 2. The Implementation (`InMemoryProductRepository`)
This is where the actual **Logic** resides. In this specific project, we use a `List<Product>` to store data in the system's RAM.
- It implements the methods defined in the interface to manipulate the collection.

### 3. The Model (`Product`)
A simple Data Transfer Object (DTO) that represents the entity we are managing.

---

## 🚀 Usage Example

In `Program.cs`, we interact with the interface rather than the concrete implementation:

```csharp
// Instantiate the repository using the Interface
IProductRepository productRepo = new InMemoryProductRepository();

// Add a new product
productRepo.AddProduct(new Product(1, "Keyboard", 25.0f));

// Retrieve and display data
Product retrievedProduct = productRepo.GetProductById(1);
Console.WriteLine($"Product: {retrievedProduct.Name}");
---
