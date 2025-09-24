# Multi-Tenant SaaS API

This project is a C# ASP.NET Core Web API designed for multi-tenant SaaS (Software as a Service) applications. It provides a scalable and secure foundation for managing multiple tenants, users, and projects within a single application instance.

## Features
- Multi-tenant architecture with tenant isolation
- User and project management per tenant
- RESTful API endpoints for CRUD operations
- Entity Framework Core for data access
- Configurable via `appsettings.json`

## Project Structure
- `Controllers/` – API controllers for tenants, users, and projects
- `Models/` – Entity models for Tenant, User, and Project
- `Data/` – Application database context
- `Services/` – Business logic and tenant provider
- `ViewModels/` – Data transfer objects for API responses

## Getting Started
1. **Clone the repository:**
   ```sh
   git clone https://github.com/mahammadbbyv/Multi-Tenant-SaaS-API.git
   ```
2. **Open the solution** in Visual Studio or VS Code.
3. **Configure the database** connection string in `appsettings.json`.
4. **Run database migrations** (if using EF Core):
   ```sh
   dotnet ef database update
   ```
5. **Build and run the API:**
   ```sh
   dotnet run
   ```

## API Endpoints
- `/api/tenants` – Manage tenants
- `/api/users` – Manage users
- `/api/projects` – Manage projects

## Contributing
Contributions are welcome! Please open issues or submit pull requests for improvements.

## License
This project is licensed under the MIT License.
