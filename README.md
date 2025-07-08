# 🏢 Asset Management System – Frontend

A full-featured frontend application built with **Angular**, **PrimeNG**, and **JWT Authentication** to manage assets, categories, locations, and users. This application supports role-based routing, interactive UI, and integration with a secure backend API.

---

## 🚀 Features

- 🔐 JWT Authentication with role-based access
- 📊 Dashboard with user and asset statistics
- 📦 CRUD for Assets, Categories, Locations
- 👥 User Management (Admin-only)
- 🌙 Dark Mode with responsive PrimeNG UI
- 📬 Toast notifications for interactions


---

## 📁 Project Structure


```text
src/
├── app/
│   ├── auth/          # Auth guards, login
│   ├── components/    # Shared layout: header, footer
│   ├── pages/         # Dashboard, Assets, Users, etc.
│   ├── services/      # API and Auth services
│   └── models/        # TypeScript interfaces
├── assets/            # Static files, styles
└── environments/      # Environment configs

## 🔐 Authentication
On successful login, JWT access and refresh tokens are saved in localStorage.

Tokens are decoded to extract roles.

Access to components is protected using route guards:

AuthGuard: blocks unauthenticated access

AdminGuard: allows Admin-only access

🧪 Test Users
Username	Password	Role
admin	123456	Admin
user	123456	User
## 🌐 API Reference
These are the backend API endpoints consumed by this frontend.

## 🔐 Auth
Endpoint	Method	Description
/api/Auth/Login	POST	Authenticates user and returns access + refresh token

## 📊 Dashboard
Endpoint	Method	Description
/api/Dashboard	GET	Returns stats including total users, assets, etc.

## 🧑 Users (Admin-only)
Endpoint	Method	Description
/api/User/GetAllUsers	GET	Get all users
/api/User/CreateUser	POST	Create a new user
/api/User/DeleteUser/{id}	DELETE	Delete user by ID
/api/User/ActivateUser/{id}	POST	Toggle active status

User DTO:

json
Copy
Edit
{
  "username": "string",
  "password": "string",
  "role": "string"
}
## 📦 Assets
Endpoint	Method	Description
/api/Asset/GetAllAssets	GET	Get all assets
/api/Asset/GetAssetById/{id}	GET	Get asset by ID
/api/Asset/CreateAsset	POST	Create new asset
/api/Asset/UpdateAsset	PUT	Update existing asset
/api/Asset/DeleteAsset/{id}	DELETE	Delete asset

Asset Schema:

sql
Copy
Edit
CREATE TABLE Assets (
  Id INT PRIMARY KEY IDENTITY,
  Name NVARCHAR(100) NOT NULL,
  Code NVARCHAR(50) UNIQUE NOT NULL,
  Description NVARCHAR(255),
  PurchaseDate DATE NOT NULL,
  Value DECIMAL(18, 2) NOT NULL,
  CategoryId INT NOT NULL,
  LocationId INT NOT NULL,
  FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
  FOREIGN KEY (LocationId) REFERENCES Locations(Id)
);
## 🗂️ Categories
Endpoint	Method	Description
/api/Category/GetAllCategories	GET	Get all categories
/api/Category/GetCategoryById/{id}	GET	Get category by ID
/api/Category/CreateCategory	POST	Create category
/api/Category/UpdateCategory	PUT	Update category
/api/Category/DeleteCategory/{id}	DELETE	Delete category

## 📍 Locations
Endpoint	Method	Description
/api/Location/GetAllLocations	GET	Get all locations
/api/Location/GetLocationById/{id}	GET	Get location by ID
/api/Location/CreateLocation	POST	Create location
/api/Location/UpdateLocation	PUT	Update location
/api/Location/DeleteLocation/{id}	DELETE	Delete location

## 🧠 Role-Based Routing Example
All routes use Angular Standalone Components

Route protection via:

AuthGuard → Checks for valid token

AdminGuard → Checks if role is Admin (from JWT)

Example usage in routes:

ts
Copy
Edit
{
  path: 'users',
  component: UserComponent,
  canActivate: [AuthGuard, AdminGuard]
}
