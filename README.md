# Bank Application API

This project is a Web API simulating a banking application built using ASP.NET Core. It provides basic banking functionalities, including making deposits, withdrawals, creating accounts, and closing accounts. The application uses in-memory data to simulate account and customer records.

## Technologies Used

- .NET Core Web API
- ASP.NET Core
- AutoMapper
- Dependency Injection
- Asynchronous Programming (async/await)
- In-Memory Data Storage

## Project Structure

The application follows a structured architecture consisting of the following layers:

- **Controllers**: Handle incoming HTTP requests and send responses.
- **Services**: Contain the business logic and interact with repositories.
- **Repositories**: Manage data access and perform CRUD operations.
- **Models**: Define data transfer objects (DTOs) and domain models.
- **Mapping Profiles**: Configure AutoMapper for model-to-DTO mappings.

## Installation

1. Clone the repository.
2. Open the solution in Visual Studio.
3. Restore NuGet packages.
4. Run the application using https.
5. Access the Swagger UI at https://localhost:7013/swagger/index.html to test the endpoints.

## Instructions
- To test close-account endpoint with an account with 0 balance, use customerId =  7, accountId = 19
- To test open-account endpoint for customer's first account (savings), use customerId = 8
