# ERP_Task

---

## 🔧 Prerequisites

- .NET 8 SDK  
- SQL Server or SQL Server Express  
- Visual Studio 2022+ or VS Code  

---

## 🚀 Running the Project

- Clone the repo  
- Update the connection string in `appsettings.json` with your SQL Server name  

---

## 📁 Folder Structure & Layers

ERP_Task/
│
├── Core/
│ ├── ERP_Task.Application
│ └── ERP_Task.Domain
│
├── Infrastructure/
│ └── ERP_Task.Persistence
│
└── Presentation/
└── ERP_Task.API



---

## ✅ Features & Business Logic

### 👥 Employee Management
- Add, Edit, Delete, Retrieve Employee  
- Fields: `Id`, `Name`, `Email`, `DepartmentId`, `HireDate`, `Status`

### 🏢 Department Management
- Add & retrieve departments  
- Every employee is assigned to a department

### 📜 Log History Tracking
- Every action on Employee (Create/Update/Delete) is recorded in `LogHistory` table with:  
  `EntityId`, `EntityName`, `ActionType`, `Timestamp`, `Description`  
- Logs are handled using a custom **MediatR Behavior** for command tracking

---

## 🛡 Validation & Error Handling

- All commands validated using **FluentValidation**  
- Returns structured error messages (`400 Bad Request`)

---

## 🔎 Filtering, Sorting, and Pagination

### Filters
- **Endpoint**: `GET /api/employees/filter`  
- Supports filtering by:  
  - `name`  
  - `departmentId`  
  - `status`  
  - `hireDateFrom` / `hireDateTo`

### Sorting
- Sort by:  
  - `Name` or `HireDate`  
- Set via: `sortBy` and `ascending` query params

### Pagination
- Params:  
  - `pageNumber`, `pageSize`

---

## 🧰 Tech Stack & Tools

- ASP.NET Core Web API  
- Entity Framework Core (Code First)  
- MediatR (CQRS)  
- FluentValidation  
- AutoMapper  
- Swagger (Swashbuckle)  
- SQL Server  

---

## 📦 Deliverables

- ✅ Complete API with all endpoints  
- ✅ Database schema (via EF Core migrations)  
- ✅ Swagger UI for testing  
- ✅ README with setup, structure, and features  
- ✅ Filters, sorting, pagination, validation, log history  

