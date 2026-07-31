![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-10.0-blue)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-Database-blue)
![Docker](https://img.shields.io/badge/Docker-Containerized-2496ED)
![JWT](https://img.shields.io/badge/JWT-Authentication-green)
![Railway](https://img.shields.io/badge/Deployed_on-Railway-purple)

# 🔐 AuthenticationAPI

A production-ready Authentication API built with **ASP.NET Core Web API** using **JWT Authentication**, **Refresh Tokens**, **BCrypt Password Hashing**, **PostgreSQL**, and **Docker**.

This project provides a secure authentication system that can be integrated into any frontend or backend application. It was designed as the authentication service for my **StreamX** project but can be used independently in other applications as well.

---

# 🚀 Features

- User Registration
- User Login
- JWT Access Token Authentication
- Refresh Token Authentication
- Refresh Token Rotation
- Logout from Current Device
- Logout from All Devices
- Get Current User Information
- Change Password
- Delete Account
- BCrypt Password Hashing
- Global Exception Handling
- Custom Authentication Middleware
- Docker Support
- PostgreSQL Database
- Railway Deployment Ready

---

# 🛠️ Tech Stack

- ASP.NET Core 10 Web API
- Entity Framework Core
- PostgreSQL
- JWT (JSON Web Token)
- BCrypt.Net
- Docker
- Railway

---

# 📁 Project Structure

```
AuthenticationAPI
│
├── Dockerfile
├── Registration-System.slnx
│
└── Registration-System
    ├── Controllers
    ├── DTO
    ├── Middleware
    ├── Models
    ├── Repository
    ├── Services
    ├── Data
    ├── Program.cs
    └── appsettings.json
```

---

# 🔑 Authentication Flow

```text
Register
     │
     ▼
Login
     │
     ▼
Access Token + Refresh Token
     │
     ▼
Protected Endpoints
     │
     ▼
Refresh Token
     │
     ▼
New Access Token
```

---

# 📌 API Endpoints

## Authentication

| Method | Endpoint | Description |
|---------|----------|-------------|
| POST | `/api/Auth/register` | Register a new user |
| POST | `/api/Auth/login` | Login user |
| POST | `/api/Auth/refresh` | Generate new access token |
| POST | `/api/Auth/logout` | Logout current device |
| POST | `/api/Auth/logout-all` | Logout from all devices |
| GET | `/api/Auth/me` | Get current authenticated user |
| PUT | `/api/Auth/change-password` | Change user password |
| DELETE | `/api/Auth/delete-account` | Permanently delete account |

---

# 🔒 Protected Endpoints

These endpoints require an Access Token.

```
Authorization: Bearer <your_access_token>
```

---

# 🌍 Live API

**Base URL**

```
https://authenticationapi-production-4ecb.up.railway.app
```

Example:

```
GET https://authenticationapi-production-4ecb.up.railway.app/api/Auth/me
```

---

# 🐳 Running with Docker

Build Image

```bash
docker build -t authentication-api .
```

Run Container

```bash
docker run -d \
-p 8080:8080 \
-e ConnectionStrings__DefaultConnection="<connection-string>" \
-e Jwt__Key="<jwt-secret-key>" \
-e Jwt__Issuer="AuthenticationAPI" \
-e Jwt__Audience="AuthenticationClient" \
-e Jwt__Expiry=7 \
--name authentication-api authentication-api
```

---

# ⚙️ Environment Variables

| Variable | Description |
|----------|-------------|
| ConnectionStrings__DefaultConnection | PostgreSQL Connection String |
| Jwt__Key | Secret key used to sign JWT tokens |
| Jwt__Issuer | Token issuer |
| Jwt__Audience | Token audience |
| Jwt__Expiry | Access token expiry in days |

---

# 🔐 Security

- JWT Bearer Authentication
- Refresh Token Rotation
- BCrypt Password Hashing
- Authorization Middleware
- Global Exception Handling
- Environment Variables for Secrets

---

# 📖 What I Learned

This project helped me gain hands-on experience with:

- JWT Authentication
- Refresh Token Flow
- ASP.NET Core Middleware
- Entity Framework Core
- Repository Pattern
- BCrypt Password Hashing
- Docker
- PostgreSQL
- Railway Deployment
- Environment Variables
- Production Debugging

---

# 🚀 Future Improvements

- Email Verification
- Forgot Password
- Password Reset via Email
- User Profile Update
- Profile Image Upload
- Account Verification
- Two-Factor Authentication (2FA)
- Role-Based Authorization
- API Rate Limiting
- Swagger Documentation

---

# 👨‍💻 Author

Amit Devbanshi

Backend Developer | ASP.NET Core | Docker | PostgreSQL
