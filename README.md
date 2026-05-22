# NFL Depth Chart Coding Assessment

## Overview

This project is a solution for the FanDuel Trading Solutions Coding Challenge – NFL Depth Charts.

The application manages NFL player depth charts by position. A depth chart is an ordered list of players within a position group, such as Quarterbacks (QB) or Wide Receivers (WR).

The system supports:

- Adding players to a depth chart
- Automatically shifting players when inserting into the middle of a chart
- Removing players and reordering the chart
- Retrieving backup players
- Viewing depth charts by position

The project includes:

- ASP.NET Core Web API backend
- Simple frontend demo using HTML, CSS, and JavaScript
- Swagger API testing
- xUnit automated unit tests

---

# Tech Stack

## Backend

- C#
- ASP.NET Core Web API
- Swagger
- xUnit

## Frontend

- HTML
- CSS
- Vanilla JavaScript
- Fetch API

---

# Project Structure

```text
NFLDepthChart/
├── NFLDepthChart.Api/
│   ├── Controllers/
│   ├── DTOs/
│   ├── Models/
│   ├── Services/
│   └── Program.cs
│
├── NFLDepthChart.Tests/
│   └── DepthChartServiceTests.cs
│
└── frontend/
    ├── index.html
    ├── style.css
    └── app.js
```

---

# Architecture

The backend follows a simple layered structure:

```text
Controller
↓
Service
↓
In-memory Storage
```

The application uses in-memory storage with:

```csharp
Dictionary<string, List<Player>>
```


---

# Features

- Add players to a depth chart
- Automatically shift players when inserting into the middle of a chart
- Remove players from a depth chart
- Automatically reorder players after removal
- Retrieve backup players
- View depth charts by position
- Prevent duplicate player numbers within the same position
- Validate request inputs

---

# Frontend Overview

The frontend is a lightweight demo UI used to interact with the backend API without requiring Swagger.

The frontend is intentionally simple and uses only:

- HTML
- CSS
- Vanilla JavaScript

---



# Requirements

- .NET 10 SDK
- VS Code (recommended)
- Live Server extension for frontend testing

This project was developed and tested using .NET 10 SDK.

# How to Run the Project

## Run the Backend

Navigate to the API project folder:

```bash
cd NFLDepthChart.Api
```

Run the API:

```bash
dotnet run
```

After starting the backend, Swagger will be available at:

```text
http://localhost:5237/swagger
```

---

## Run the Frontend

1. Open the `frontend` folder in VS Code
2. Install the **Live Server** extension
3. Right click `index.html`
4. Select:

```text
Open with Live Server
```

The frontend will usually open at:

```text
http://127.0.0.1:5500
```

---

# Running Tests

Run tests from the solution root:

```bash
dotnet test
```

---

# Important Notes

- The backend uses in-memory storage, so data resets when the API restarts
- The frontend requires the backend API to be running
- CORS is enabled to allow frontend-backend communication during local development
- The project intentionally keeps the architecture simple and focused on the coding challenge requirements