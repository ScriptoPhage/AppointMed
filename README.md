# Overview

![ASP.NET Core](https://img.shields.io/badge/ASP.NET-Core%208-blue) 


This API provides functionalities for managing medical appointments, including user registration, login, and appointment scheduling. The API is secured with JWT authentication, allowing users to interact with protected endpoints after logging in. This project demonstrates the implementation of a basic appointment system with the ability to create, retrieve, update, and delete appointments.
## Features
- **User Registration** and **Login** with JWT token-based authentication.
- **Appointment Management** for patients, with CRUD operations.
- Secure endpoints requiring authentication via JWT.
- Full integration with a Doctor model, allowing appointments to be assigned to specific doctors.

## Tech Stack
| Component      | Technology             |
|----------------|-------------------------|
| Backend        | ASP.NET Web API        |
| Database       | SQL Server             |
| Authentication | .NET Identity, JWT     |
## 1. User Registration and Login
To use the API, you need to first register and log in a user to obtain a JWT token for authentication.
**Register User**
Endpoint: POST /api/account/register
Request Body:
```
{
    "username": "testUser",
    "email": "testuser@example.com",
    "password": "securePassword@123"
}


```
Response:
```
{
  "message": "User registration successful"
}
```
**Login User**
Endpoint: POST /api/auth/login
Request Body:
```
{
    "username": "testUser",
    "password": "securePassword@123"
}

```
## Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/ScriptoPhage/AppointMed.git
   
