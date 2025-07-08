# 🏢 Asset Management System – Backend

This is the backend API for the **Asset Management System**, built with **ASP.NET Core 8**, **Entity Framework Core**, and follows **Clean Architecture** principles.

It provides secure, scalable, and modular endpoints to manage and track assets, categories, locations, and users within an organization.

---

## 📂 Project Structure
```
Asset_Management_System_backend/
│
├── API/ # Entry point – Controllers, Middleware, Program.cs
├── Domain/ # Core business models and interfaces
├── Service/ # Business logic, services, and DTOs
├── Infrastructure/ # EF Core, data access, repositories
└── README.md # Project documentation

```
## 🚀 Technologies Used

- **.NET 8 Web API**
- **Entity Framework Core**
- **SQL Server**
- **Repository Pattern**
- **JWT Authentication**
- **AutoMapper**
- **NLog** (optional for logging)



## 🧱 Features

- ✅ Asset CRUD operations
- ✅ Category management
- ✅ Location management
- ✅ User registration and login
- ✅ JWT-based secure authentication
- ✅ Dashboard API returning analytics summary
- ✅ Clean and testable architecture (SOLID principles)
- ✅ Global error handling middleware


## 📊 Dashboard Endpoint

Provides summary data for:

- Total Users
- Total Assets
- Active Assets
- Retired Assets
- New Assets Added This Month
- Total Categories
- Total Locations

> **Route:** `GET /api/dashboard`

```json
{
  "totalUsers": 25,
  "totalAssets": 150,
  "activeAssets": 120,
  "retiredAssets": 25,
  "newAssetsThisMonth": 5,
  "totalCategories": 6,
  "totalLocations": 3
}
```
## 🔐 Authentication

Uses JWT Token-based Authentication

Token is generated on successful login and must be sent in the Authorization header as a Bearer token


## 📌 Prerequisites
- .NET 8 SDK

- SQL Server

- Visual Studio 2022 or Visual Studio Code

## 👨‍💻 Author
Omar Alsaleh

Email: [omaralsaleh1129@gmail.com]


