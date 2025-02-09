# 🎓 School Management API  

This repository contains a **School Management API** built using **ASP.NET Core 8**. The project follows **Clean Architecture** principles and implements the **CQRS (Command and Query Responsibility Segregation) design pattern** for efficient data handling.  

---

## 🏗️ Architecture  

The project is structured into **five layers**:  

1️⃣ **School.API** (Presentation Layer) – Handles HTTP requests and responses.  
2️⃣ **School.Core** (Application Layer) – Contains business logic, behaviors, and wrappers.  
3️⃣ **School.Data** (Domain Layer) – Defines entities and domain rules.  
4️⃣ **School.Infrastructure** (Persistence Layer) – Manages database interactions, repositories, and migrations.  
5️⃣ **School.Service** (Service Layer) – Implements business services and interfaces.  

---

## ⚡ Technologies Used  

🔹 **ASP.NET Core 8**  
🔹 **Entity Framework Core**  
🔹 **CQRS Pattern with MediatR**  
🔹 **SQL Server**  
🔹 **Swagger** for API documentation  

---

## 📂 Project Structure  
📦 SchoolProjectAPI
├── 📁 School.API (Presentation Layer)
├── 📁 School.Core (Application Layer)
├── 📁 School.Data (Domain Layer)
├── 📁 School.Infrastructure (Persistence Layer)
├── 📁 School.Service (Service Layer)

---

## 🚀 Features  

✔️ Clean and scalable architecture  
✔️ CQRS implementation for better separation of concerns  
✔️ Dependency Injection for maintainability  
✔️ Centralized exception handling  
✔️ API versioning with Swagger  

---

## 📌 Setup & Run  

1️⃣ Clone the repository:  
   git clone https://github.com/yourusername/SchoolProjectAPI.git
   
2️⃣ Navigate to the project folder:
cd SchoolProjectAPI
3️⃣ Restore dependencies:
dotnet restore
4️⃣ Update database (if using EF Core Migrations):
dotnet ef database update
5️⃣ Run the API:
dotnet run --project School.API

6️⃣ Open Swagger UI at:
http://localhost:5000/swagger
🤝 Contributing
Feel free to fork this repository and submit pull requests.

📌 Author: Ahmed Elazazy
📌 GitHub: Ahmed Elazazy
📌 LinkedIn: Ahmed Elazazy

🚀 Happy coding! 🎉
