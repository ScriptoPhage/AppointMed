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
    "userName": "testUser2",
    "email": "testuser2@example.com",
    "token": "JWT_Token_String_Here"
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
Response:
```
{
    "userName": "testUser",
    "email": "testuser@example.com",
    "token": "JWT_Token_String_Here"
}
```
## 2. Using the Authentication Token to Access Protected Endpoints
Once you have the JWT token from the login response, include it in the Authorization header for all requests to protected endpoints.
**Example Request with Authorization Header:**
```
GET /api/appointments
Authorization: Bearer JWT_Token_String_Here
```
You can use this token to access endpoints like retrieving a list of appointments, viewing specific appointments, etc.
## 3. Testing the API Endpoints Using Postman
**1) Register a User**
- Open Postman and create a POST request.
- Set the URL to: http://localhost:7159/api/auth/register
- In the Body tab, select raw and choose JSON as the type.
- Paste the registration request body and hit Send.

**2) Login and Get JWT Token**
- Create a new POST request.
- Set the URL to: http://localhost:7159/api/auth/login
- In the Body tab, paste the login request body and hit Send.
- Save the JWT token from the response.
  
**3) Access Protected Endpoints**
- Create a GET request to access protected endpoints like GET /api/appointments.
- In the Headers tab, add a new header:
-- Key: Authorization
-- Value: Bearer JWT_Token_String_Here
- Hit Send to access the appointments data.


## Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/ScriptoPhage/AppointMed.git
   
