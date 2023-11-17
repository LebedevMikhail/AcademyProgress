# Progress Academy

Welcome to the repository of the "Progress Academy" project. This project is a web service for tracking learning progress, built using ASP.NET Core.

## Table of Contents

- [Description](#description)
- [Technologies](#technologies)
- [Project Structure](#project-structure)
- [Installation and Running](#installation-and-running)
- [Testing](#testing)
    - [Unit Tests](#unit-tests)
    - [Integration Tests](#integration-tests)
    - [End-to-End Tests](#end-to-end-tests)
- [API Usage Examples](#api-usage-examples)
- [License](#license)

## Description

Progress Academy is a web service designed to help mentors and mentees track their learning progress efficiently. 
Whether you're a mentor managing multiple plans or a mentee keeping tabs on your individual progress, 
our application empowers you to monitor and enhance the learning experience.

## Technologies

- ASP.NET Core
- C# / .NET Core
- Entity Framework Core
- ...

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
    - Technologies: ....

8. **ProgressAcademy.IntegrationTests:**
    - Tests checking the interaction of different components in integration.
    - Technologies: ....

9. **ProgressAcademy.EndToEndTests:**
    - Tests checking the end-to-end interaction with the application.
    - Technologies: ....

## Installation and Running

1. ...

2. ...

## Testing

### Unit Tests

To run unit tests, use the following command:

```bash
dotnet test .\UnitTests\UnitTests.csproj