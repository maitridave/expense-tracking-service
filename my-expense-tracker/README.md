# My Expense Tracker

## Overview
My Expense Tracker is a full-stack application designed to help users manage their expenses efficiently. The application features user management and authentication, as well as expense tracking and categorization.

## Project Structure
The project is divided into two main parts: the backend and the frontend.

### Backend
The backend is built using C# and ASP.NET Core. It handles user management and expense tracking functionalities.

- **Controllers**: Contains API controllers for user and expense management.
  - `UserController.cs`: Manages user-related API requests.
  - `ExpenseController.cs`: Manages expense-related API requests.

- **Models**: Defines the data models used in the application.
  - `User.cs`: Represents a user in the system.
  - `Expense.cs`: Represents an expense entry.
  - `ExpenseCategory.cs`: Represents categories for expenses.

- **Services**: Contains business logic for user and expense management.
  - `UserService.cs`: Handles user-related business logic.
  - `ExpenseService.cs`: Handles expense-related business logic.

- **Repositories**: Manages data access for user and expense operations.
  - `UserRepository.cs`: Handles data access for user-related operations.
  - `ExpenseRepository.cs`: Handles data access for expense-related operations.

- **Tests**: Contains unit tests for services.
  - `UserServiceTests.cs`: Tests for user service functionalities.
  - `ExpenseServiceTests.cs`: Tests for expense service functionalities.

### Frontend
The frontend is built using React. It provides a user interface for managing users and tracking expenses.

- **Components**: Contains React components for the application.
  - `UserManagement.js`: Handles user registration and authentication UI.
  - `ExpenseTracking.js`: Manages the UI for tracking expenses.

- **Services**: Contains service classes for API calls.
  - `AuthService.js`: Handles authentication logic.
  - `ExpenseService.js`: Handles expense-related API calls.

- **Tests**: Contains unit tests for services.
  - `AuthService.test.js`: Tests for authentication methods.
  - `ExpenseService.test.js`: Tests for expense-related methods.

## Getting Started
To get started with the project, follow these steps:

### Prerequisites
- .NET SDK
- Node.js and npm

### Backend Setup
1. Navigate to the `backend` directory.
2. Restore the dependencies:
   ```
   dotnet restore
   ```
3. Run the application:
   ```
   dotnet run
   ```

### Frontend Setup
1. Navigate to the `frontend` directory.
2. Install the dependencies:
   ```
   npm install
   ```
3. Start the React application:
   ```
   npm start
   ```

## Running Tests
### Backend Tests
To run the backend tests, navigate to the `backend` directory and execute:
```
dotnet test
```

### Frontend Tests
To run the frontend tests, navigate to the `frontend` directory and execute:
```
npm test
```

## Contributing
Contributions are welcome! Please open an issue or submit a pull request for any improvements or bug fixes.

## License
This project is licensed under the MIT License. See the LICENSE file for details.