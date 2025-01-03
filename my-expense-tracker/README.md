# ExpenseTracker

## Overview
ExpenseTracker is a backend application designed to help users manage their expenses efficiently. The application features user management and authentication, as well as expense tracking and categorization.

## Project Structure
The project is organized into several key components:

### Controllers
- [`AuthController.cs`](Controllers/AuthController.cs): Manages authentication-related API requests.
- [`ExpensesController.cs`](Controllers/ExpensesController.cs): Manages expense-related API requests.
- [`ProfilesController.cs`](Controllers/ProfilesController.cs): Manages profile-related API requests.
- [`CategoriesController.cs`](Controllers/CategoriesController.cs): Manages category-related API requests.

### Models
- [`Profile.cs`](Models/Profile.cs): Represents a user profile in the system.
- [`SignInModel.cs`](Models/SignInModel.cs): Represents the sign-in model.
- [`Expense.cs`](Models/Expense.cs): Represents an expense entry.
- [`Category.cs`](Models/Category.cs): Represents categories for expenses.

### Services
- [`AuthService.cs`](Services/AuthService.cs): Handles authentication-related business logic.
- [`IAuthService.cs`](Services/IAuthService.cs): Interface for authentication service.

### Data
- [`ExpenseTrackerContext.cs`](Data/ExpenseTrackerContext.cs): Database context for the application.

### Scripts
- [`InsertCategories.cs`](Scripts/InsertCategories.cs): Script to insert default categories.
- [`InsertProfiles.cs`](Scripts/InsertProfiles.cs): Script to insert default profiles.

### Database
- [`CreateTables.sql`](Database/CreateTables.sql): SQL script to create database tables.

## Getting Started
To get started with the project, follow these steps:

### Prerequisites
- .NET SDK
- SQL Server

### Backend Setup
1. Restore the dependencies:
   ```sh
   dotnet restore
