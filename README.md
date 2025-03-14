# Onion Architecture .NET Backend - Basic Setup

This project follows the Onion Architecture pattern with the following structure:

OnionArchitecture/ │── OnionArchitecture.sln │── Core.Domain/ │ ├── Core.Domain.csproj │── Application/ │ ├── Application.csproj │── Infrastructure/ │ ├── Infrastructure.csproj │── API.REST/ │ ├── API.REST.csproj │── WebSockets/ │ ├── WebSockets.csproj │── Startup/ │ ├── Startup.csproj
---

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

dotnet new classlib -n Infrastructure
dotnet sln add Infrastructure/Infrastructure.csproj
dotnet add Infrastructure/Infrastructure.csproj reference Application/Application.csproj

dotnet new webapi -n API.REST
dotnet sln add API.REST/API.REST.csproj
dotnet add API.REST/API.REST.csproj reference Application/Application.csproj

dotnet new web -n WebSockets
dotnet sln add WebSockets/WebSockets.csproj
dotnet add WebSockets/WebSockets.csproj reference Application/Application.csproj

dotnet new console -n Startup
dotnet sln add Startup/Startup.csproj
dotnet add Startup/Startup.csproj reference Application/Application.csproj
dotnet add Startup/Startup.csproj reference Infrastructure/Infrastructure.csproj
dotnet add Startup/Startup.csproj reference API.REST/API.REST.csproj
dotnet add Startup/Startup.csproj reference WebSockets/WebSockets.csproj
```

### **3. Verify the Structure**
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

## 🚀 ** Running the Projects**
```sh
dotnet run --project API.REST/API.REST.csproj
dotnet run --project WebSockets/WebSockets.csproj
dotnet run --project Startup/Startup.csproj
```