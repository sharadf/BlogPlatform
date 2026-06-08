# BlogPlatform Backend API

A fully functional, secure, and highly scalable backend platform for a modern blogging web application. This project is built as a high-performance RESTful API, demonstrating robust software engineering practices, clean code principles, and containerized deployment.

## 🏗️ Architecture & Design Principles

* **Clean Architecture & SOLID:** Implemented to ensure high maintainability, strict separation of concerns, and easy testability by decoupling core business logic from external frameworks.
* **Layered Architecture:** Features a clear structure separated into distinct layers: Controllers (Presentation), Services (Application/Business Logic), and Repositories (Data Access/Infrastructure).
* **API-First (Contract-First) Development:** Endpoints, request/response DTOs, and system behaviors were fully designed prior to implementation to guarantee a reliable and robust system contract.

## 🚀 Key Features

* **Content & Post Management:** Complete CRUD operations for handling blog posts, categories, and tags, with dynamic relationships and filtering.
* **User Identity & Security:** Secure user registration and login flows utilizing JWT (JSON Web Tokens) with Role-Based Access Control (e.g., Admin, Author, Reader).
* **Global Exception Handling:** Centralized middleware for capturing and processing runtime errors uniformly across the entire API.
* **API Documentation:** Fully documented and interactive API endpoints using Swagger/OpenAPI for seamless integration.

## 🛠️ Tech Stack & Infrastructure

* **Framework:** .NET 8 Web API
* **ORM:** Entity Framework Core
* **Database:** PostgreSQL (with optimized database schemas and relational mapping)
