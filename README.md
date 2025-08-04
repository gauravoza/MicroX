# 🚀 MicroX Microservices Skeleton

MicroX is a lightweight, production-ready microservices starter kit built with **ASP.NET Core**. It’s designed for developers building modular, scalable, and cloud-native backend APIs.

---

## 📦 Project Overview

MicroX provides a clean architecture setup to kickstart new microservices with:

- ✅ Minimal API surface with layered abstraction
- ✅ Environment-based configuration management
- ✅ Built-in health check endpoints
- ✅ Logging using `ILogger<T>` and Serilog
- ✅ Dependency injection for services and repositories
- ✅ Unit tests using `xUnit`
- ✅ Docker support for local containerized development

---

## 🛠️ Local Setup Guide

### Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/get-started) (optional, for container support)
- IDE like [Visual Studio 2022+](https://visualstudio.microsoft.com/) or [JetBrains Rider](https://www.jetbrains.com/rider/)

### Clone & Build

```bash
git clone https://github.com/your-org/MicroX.git
cd MicroX
dotnet restore
dotnet build

Run API
bash
Copy
Edit
cd src/MicroX.API
dotnet run
Run with Docker
bash
Copy
Edit
docker-compose up --build
Run Tests
bash
Copy
Edit
cd tests/MicroX.Tests
dotnet test
🔐 HTTPS Support
HTTPS is enabled by default in development via launchSettings.json.

To test over HTTPS:

bash
Copy
Edit
https://localhost:5001/swagger/index.html
If you get a certificate warning, trust the development certificate:

bash
Copy
Edit
dotnet dev-certs https --trust
📜 Swagger Access
Swagger UI is available to explore APIs:

🟢 HTTP: http://localhost:5000/swagger/index.html

🔒 HTTPS: https://localhost:5001/swagger/index.html

ℹ️ Swagger is enabled only in the Development environment.
You can modify this behavior in Program.cs.

✅ Health Check Endpoints
Endpoint	Description
/health	Basic liveness check (200 OK)
/ready	(Planned) Readiness check

🧭 Future Roadmap
 Add /ready health endpoint for readiness diagnostics

 Add ServiceInfo endpoint to expose version/build metadata

 Add distributed tracing support (OpenTelemetry)

 Centralized logging with Elastic Stack or Seq

 JWT-based authentication and authorization

 Redis caching integration

 Rate limiting and request throttling

 Kubernetes Helm charts for deployment

 CI/CD with GitHub Actions

 Secrets management with Azure Key Vault

🤝 Contributing
Coming soon — this repository will be open for contributions with guidelines.

📄 License
MIT License © 2025 Gaurav Oza