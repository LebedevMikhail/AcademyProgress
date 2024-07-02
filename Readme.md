# Progress Academy

Welcome to the repository of the "Progress Academy" project. This project is a web service for tracking learning progress, built using ASP.NET Core.

## Table of Contents

- [Description](#description)
- [Technologies](#technologies)
- [Project Structure](#project-structure)
- [Installation and Running](#installation-and-running)
- [License](#license)

## Description

Progress Academy is a web service designed to help mentors and mentees track their learning progress efficiently. Whether you're a mentor managing multiple plans or a mentee keeping tabs on your individual progress, our application empowers you to monitor and enhance the learning experience.

## Technologies

- ASP.NET Core
- C# / .NET Core
- MongoDB
- Docker
- MSTest (for testing)
- Swagger (for API documentation)

## Project Structure

1. **ProgressAcademy.WebApi:**
   - Code for the web service and API controllers.

2. **ProgressAcademy.Application:**
   - Business logic and application services.

3. **ProgressAcademy.Handlers:**
   - Handlers for commands and queries for write and read operations.

4. **ProgressAcademy.Infrastructure:**
   - Infrastructure layer for interacting with the database and other external resources.

5. **ProgressAcademy.Data:**
   - Data models and the database context.

6. **ProgressAcademy.Domain:**
   - Definition of business entities and logic.

7. **ProgressAcademy.UnitTests:**
   - Tests for unit testing business logic and functionality.
   - Technologies: MSTest, Moq

8. **ProgressAcademy.IntegrationTests:**

9. **ProgressAcademy.EndToEndTests:**

## Installation and Running

### Prerequisites

- Docker and Docker Compose installed on your system.
- .NET SDK installed on your system.

### Steps

1. **Clone the repository:**
   ```bash
   git clone https://github.com/LebedevMikhail/AcademyProgress.git
   cd ProgressAcademy
   ### Steps

2. **Navigate to the project directory:**

    ```bash
    cd ProgressAcademy
    ```

3. **Restore NuGet packages:**

    ```bash
    dotnet restore
    ```

4. **Build the solution:**

    ```bash
    dotnet build
    ```

5. **Run the application:** 

    ```bash
    dotnet run --project .\ProgressAcademy.WebApi\ProgressAcademy.WebApi.csproj
    ```

6. **Access the API documentation:** 

    Open a web browser and go to http://localhost:7104/swagger/index.html

7. **Perform API requests using the Swagger UI or your preferred API testing tool.** 

### License

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT).


