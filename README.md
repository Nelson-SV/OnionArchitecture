# Onion Architecture .NET Backend - Basic Setup

This project follows the Onion Architecture pattern with the following structure:

```mathematica
YourDirectoryName/
│── YourSolutionName.sln
│── Core.Domain/
│   ├── Core.Domain.csproj
│── Application/
│   ├── Application.csproj
│── Infrastructure.Postgres/
│   ├── Infrastructure.Postgres.csproj
│── Api.Rest/
│   ├── Api.Rest.csproj
│── Api.Websocket/
│   ├── Api.Websocket.csproj
│── Infrastructure.Postgres.Scaffolding/
│   ├── Infrastructure.Postgres.Scaffolding.csproj
│── Infrastructure.Websocket/
│   ├── Infrastructure.Websocket.csproj
│── Startup/
│   ├── Startup.csproj
```

## 🛠️ **Setup Instructions**
Follow these steps to set up the project:

### **1. Create the Solution**
```sh
dotnet new sln -n YourSolutionName
```

### **2. Create the Projects**
```sh
dotnet new classlib -n Core.Domain
dotnet sln add Core.Domain/Core.Domain.csproj

dotnet new classlib -n Application
dotnet sln add Application/Application.csproj
dotnet add Application/Application.csproj reference Core.Domain/Core.Domain.csproj

dotnet new classlib -n Infrastructure.Postgres
dotnet sln add Infrastructure.Postgres/Infrastructure.Postgres.csproj
dotnet add Infrastructure.Postgres/Infrastructure.Postgres.csproj reference Application/Application.csproj
dotnet add Infrastructure.Postgres/Infrastructure.Postgres.csproj reference Infrastructure.Postgres.Scaffolding/Infrastructure.Postgres.Scaffolding.csproj

dotnet new classlib -n Infrastructure.Postgres.Scaffolding
dotnet sln add Infrastructure.Postgres.Scaffolding/Infrastructure.Postgres.Scaffolding.csproj
dotnet add Infrastructure.Postgres.Scaffolding/Infrastructure.Postgres.Scaffolding.csproj reference Core.Domain/Core.Domain.csproj

dotnet new classlib -n Infrastructure.Websocket
dotnet sln add Infrastructure.Websocket/Infrastructure.Websocket.csproj
dotnet add Infrastructure.Websocket/Infrastructure.Websocket.csproj reference Application/Application.csproj

dotnet new webapi -n API.REST
dotnet sln add API.REST/API.REST.csproj
dotnet add API.REST/API.REST.csproj reference Application/Application.csproj

dotnet new web -n WebSockets
dotnet sln add WebSockets/WebSockets.csproj
dotnet add WebSockets/WebSockets.csproj reference Application/Application.csproj

dotnet new console -n Startup
dotnet sln add Startup/Startup.csproj
dotnet add Startup/Startup.csproj reference Application/Application.csproj
dotnet add Startup/Startup.csproj reference Infrastructure.Postgres/Infrastructure.Postgres.csproj
dotnet add Startup/Startup.csproj reference Api.Rest/Api.Rest.csproj
dotnet add Startup/Startup.csproj reference Api.WebSocket/Api.WebSocket.csproj
dotnet add Startup/Startup.csproj reference Infrastructure.WebSocket/Infrastructure.WebSocket.csproj
```

### **3. Adding Nuget Packages**
## **Inside Infrastructure.PostGres directory, run:**
```sh
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.Extensions.DependencyInjection.Abstractions
dotnet add package PgCtxSetup
```

Inside Infrastructure.PostGres.Scaffolding directory, run:
```sh
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.Extensions.DependencyInjection.Abstractions
```

Inside Infrastructure.Websocket directory, run:
```sh
dotnet add package uldahlalex.websocket.boilerplate
```

Inside Api.Rest directory, run:
```sh
dotnet add package NSwag.AspNetCore
```

Inside Api.WebSocket directory, run:
```sh
dotnet add package uldahlalex.websocket.boilerplate
```

Inside Application directory, run:
```sh
dotnet add package JWT
dotnet add package Microsoft.Extensions.DependencyInjection.Abstractions
dotnet add package Microsoft.Extensions.Options
dotnet add package Microsoft.Extensions.Options.ConfigurationExtensions
dotnet add package Microsoft.Extensions.Configuration.Abstractions
```

Inside Startup directory, run:
```sh
dotnet add package Microsoft.Extensions.Logging.Abstractions
dotnet add package Microsoft.Extensions.Logging.Console
dotnet add package NSwag.CodeGeneration.TypeScript
dotnet add package patrikvalentiny-WebSocketProxy
dotnet add package NSwag.AspNetCore
```

### **4. Verify the Structure**
```sh
dotnet build
```

## 🛠️ **Steps for adding to Git / Github**
```sh
git init
dotnet new gitignore  # Generates a .gitignore file with all you need
git add .
git commit -m "Your message"
git remote add origin YOUR_GITHUB_REPO_URL
git branch -M main
git push -u origin main
```

## ** Small notes:**
In Infrastructure.PostGres.csproj, Api.Rest.csproj, Api.WebSocket.csproj add the following statement inside <PropertyGroup>:
<OutputType>library</OutputType>

## 🚀 ** Running the Projects**
```sh
dotnet run --project API.REST/API.REST.csproj
dotnet run --project WebSockets/WebSockets.csproj
dotnet run --project Startup/Startup.csproj
```


