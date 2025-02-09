# School Project API

This repository contains a **School Management API** built using **ASP.NET Core 8**. The project follows **Clean Architecture** principles and implements the **CQRS (Command and Query Responsibility Segregation) design pattern** for efficient data handling.  

## 🏗️ Architecture  
The project is structured into **five layers**:  

1. **School.API** (Presentation Layer) – Handles HTTP requests and responses.  
2. **School.Core** (Application Layer) – Contains business logic, behaviors, and wrappers.  
3. **School.Data** (Domain Layer) – Defines entities and domain rules.  
4. **School.Infrastructure** (Persistence Layer) – Manages database interactions, repositories, and migrations.  
5. **School.Service** (Service Layer) – Implements business services and interfaces.  

## ⚡ Technologies Used  
- **ASP.NET Core 8**  
- **Entity Framework Core**  
- **CQRS Pattern**  
- **MediatR**  
- **SQL Server**  
- **Swagger** for API documentation  

## 📂 Project Structure  
📦 SchoolProjectAPI ├── 📁 School.API (Presentation Layer) ├── 📁 School.Core (Application Layer) ├── 📁 School.Data (Domain Layer) ├── 📁 School.Infrastructure (Persistence Layer) ├── 📁 School.Service (Service Layer)

## 🚀 Features  
✔️ Clean and scalable architecture  
✔️ CQRS implementation for better separation of concerns  
✔️ Dependency Injection for maintainability  
✔️ Centralized exception handling  
✔️ API versioning with Swagger  

## 📌 Setup & Run  
1. Clone the repository:  
   ```sh
   git clone https://github.com/yourusername/SchoolProjectAPI.git
Navigate to the project folder:
sh
Copy code
cd SchoolProjectAPI
Restore dependencies:
sh
Copy code
dotnet restore
Update database (if using EF Core Migrations):
sh
Copy code
dotnet ef database update
Run the API:
sh
Copy code
dotnet run --project School.API
Open Swagger UI at:
bash
Copy code
http://localhost:5000/swagger
🤝 Contributing
Feel free to fork this repository and submit pull requests.
📌 Author: Ahmed Elazazy
📌 GitHub: https://github.com/elazazy424
📌 LinkedIn: https://www.linkedin.com/in/ahmed-elazazy11/

🚀 Happy coding!
