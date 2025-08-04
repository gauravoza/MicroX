
# MicroX - Microservices Skeleton

![Version](https://img.shields.io/badge/version-1.0.0-blue.svg)
![.NET](https://img.shields.io/badge/.NET-8.0-purple.svg)
![License](https://img.shields.io/badge/license-MIT-green.svg)
![Docker](https://img.shields.io/badge/docker-supported-blue.svg)

A lightweight, production-ready microservices starter kit built with **ASP.NET Core 8.0**. Designed for developers who need a clean, scalable foundation for building cloud-native backend APIs.

## Features

- **Clean Architecture** - Layered abstraction with minimal API surface
- **Configuration Management** - Environment-based settings
- **Health Monitoring** - Built-in health check endpoints
- **Logging** - Structured logging with Serilog and `ILogger<T>`
- **Dependency Injection** - Pre-configured DI container
- **Testing** - Unit test framework with xUnit
- **Containerization** - Docker support for development and deployment
- **API Documentation** - Swagger/OpenAPI integration

## Quick Start

### Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/download) or later
- [Docker](https://www.docker.com/get-started) (optional)
- IDE: [Visual Studio 2022+](https://visualstudio.microsoft.com/) or [JetBrains Rider](https://www.jetbrains.com/rider/)

### Installation

1. **Clone the repository**
```bash
git clone https://github.com/gauravoza/MicroX.git
cd MicroX
```

2. **Restore dependencies**
```bash
dotnet restore
```

3. **Build the project**
```bash
dotnet build
```

### Running the Application

#### Local Development
```bash
cd src/MicroX.API
dotnet run
```

#### Using Docker
```bash
docker-compose up --build
```

#### Running Tests
```bash
cd tests/MicroX.Tests
dotnet test
```

## API Documentation

Once the application is running, access the Swagger UI at:

- **HTTP**: http://localhost:5000/swagger/index.html
- **HTTPS**: https://localhost:5001/swagger/index.html

> **Note**: Swagger is only available in the Development environment. Modify `Program.cs` to change this behavior.

## HTTPS Configuration

HTTPS is enabled by default in development via `launchSettings.json`. If you encounter certificate warnings, trust the development certificate:

```bash
dotnet dev-certs https --trust
```

## Health Checks

| Endpoint   | Description                            |
|------------|----------------------------------------|
| `/health`  | Basic liveness check (returns 200 OK)  |
| `/ready`   | Readiness check *(planned)*            |

## Project Structure

```
MicroX/
├── src/
│   ├── MicroX.API                  # Entry point - Web API
│   ├── MicroX.Application          # Interfaces, DTOs, Validators
│   ├── MicroX.Domain               # Entities and core models
│   ├── MicroX.Infrastructure       # Repositories and Services
│   └── MicroX.Tests                # xUnit test projects
├── docker-compose.yml
└── README.md
```

## Configuration

The application uses standard ASP.NET Core configuration with support for:

- `appsettings.json` - Base configuration
- `appsettings.Development.json` - Development overrides
- Environment variables
- Command line arguments

## Roadmap

- [ ] **Enhanced Health Checks** - Add `/ready` endpoint for readiness diagnostics
- [ ] **Service Information** - Expose version/build metadata endpoint
- [ ] **Observability** - OpenTelemetry distributed tracing
- [ ] **Centralized Logging** - Elastic Stack or Seq integration
- [ ] **Authentication** - JWT-based auth and authorization
- [ ] **Caching** - Redis integration
- [ ] **Rate Limiting** - Request throttling middleware
- [ ] **Deployment** - Kubernetes Helm charts
- [ ] **CI/CD** - GitHub Actions workflows
- [ ] **Security** - Azure Key Vault secrets management

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request. For major changes, please open an issue first to discuss what you would like to change.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Author

**Gaurav Oza** - [GitHub Profile](https://github.com/gauravoza)

---

⭐ **Star this repository** if you found it helpful!
