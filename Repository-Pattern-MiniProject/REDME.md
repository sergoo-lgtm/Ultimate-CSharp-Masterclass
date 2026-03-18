<p align="center">
  <img src="https://capsule-render.vercel.app/api?type=waving&color=0:0F2027,50:203A43,100:2C5364&height=260&section=header&text=Product%20Repository&fontSize=45&fontAlignY=40&animation=fadeIn&fontColor=ffffff" />
</p>

<p align="center">
  <img src="https://readme-typing-svg.herokuapp.com?font=Fira+Code&weight=600&size=22&pause=1000&color=00C2FF&center=true&vCenter=true&width=650&lines=C%23+Repository+Pattern;In-Memory+CRUD+Demo;Clean+Architecture;Decoupled+Layers" />
</p>

<p align="center">
  <a href="https://github.com/your-username/Product-Repository/stargazers">
    <img src="https://img.shields.io/github/stars/your-username/Product-Repository?style=for-the-badge" />
  </a>
  <a href="https://github.com/your-username/Product-Repository/network/members">
    <img src="https://img.shields.io/github/forks/your-username/Product-Repository?style=for-the-badge" />
  </a>
  <img src="https://komarev.com/ghpvc/?username=your-username&style=for-the-badge" />
</p>

---

# 🛠 Product Repository Pattern Demo

A simple **Product Repository** example built using **C#** demonstrating the **Repository Pattern** with **in-memory storage** and clean separation of concerns.

---

## 🎯 Features

- 📦 CRUD Operations (Add, Get, Update, Delete)
- ⚡ Repository Pattern Implementation
- 🧱 Separation of Concerns (Entity, Interface, Concrete Repository, Client)
- 🧠 Fully decoupled architecture
- 🔁 Easy to replace storage (In-memory → Database)
- 🧼 Clean and maintainable code

---

## 🛠️ Tech Stack

- **C#**
- **.NET 8 (or compatible)**
- **Console Application**
- **LINQ for collection handling**

---

## 📂 Project Structure

```text
📦 Product-Repository
 ┣ 📂 Repository_Pattern
 ┃ ┣ 📜 Product.cs
 ┃ ┣ 📜 IProductRepository.cs
 ┃ ┣ 📜 InMemoryProductRepository.cs
 ┃ ┗ 📜 Program.cs
 
 ---
 
 ## 🧠 Architecture Overview
 Client (Program.cs)
     ↓
IProductRepository (Interface)
     ↓
InMemoryProductRepository (Concrete Implementation)
     ↓
Product (Entity)
