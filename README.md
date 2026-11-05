# Simple Task Tracker

A small **ASP.NET Core MVC** project demonstrating the Model-View-Controller pattern and basic CRUD operations.

## Features
- View a list of tasks
- Create, edit and delete tasks
- Mark tasks as completed or reopen them
- Server-side validation with Data Annotations
- Responsive, lightweight CSS styling

## Tech stack
- C# / .NET 8
- ASP.NET Core MVC
- Razor Views
- HTML and CSS

## Run locally

Install the [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0), then run:

```bash
dotnet restore
dotnet run
```

Open the local URL shown in the terminal.

## Project structure

```text
SimpleTaskTracker/
├── Controllers/
│   └── TasksController.cs
├── Models/
│   └── TaskItem.cs
├── Views/
│   ├── Shared/
│   └── Tasks/
├── wwwroot/
│   └── css/site.css
├── Program.cs
└── SimpleTaskTracker.csproj
```

## Note
This is a learning/demo project. Tasks are stored in a static in-memory list, so changes are lost when the application restarts. A natural next step would be adding Entity Framework Core with SQL Server or SQLite.
