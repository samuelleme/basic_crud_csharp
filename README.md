# Account Management System (Basic CRUD in C#)

This is a simple console project, developed in C#, that implements basic CRUD operations to manage bank accounts. Data is read from and saved to a CSV file, ensuring information persistence between sessions.

This project was developed as a final assignment for the "Web Service Development and Testing with Java" course, taught by Prof. Pablo Rangel.

## Features

The system provides an interactive console menu with the following options:

* **Add Account:** Adds a new account (ID, Name, Initial Balance).
* **Delete Account:** Removes an existing account, with the rule that its balance must be zero.
* **List Accounts:** Lists all registered accounts.
* **Update Balance:** Allows crediting (depositing) or debiting (withdrawing) amounts from a specific account.
* **Data Persistence:** Saves all changes to an `accounts.csv` file upon exiting the program.

## Tech Stack

* **[C#](https://learn.microsoft.com/en-us/dotnet/csharp/)**: Main programming language.
* **[.NET](https://dotnet.microsoft.com/en-us/)**: Development platform.

## Code Structure

The code is organized following OOP principles to separate responsibilities:

* `Program.cs`: Application's entry point. Initializes the main objects and controls the startup/shutdown flow (reading from and writing to the CSV).
* `Account.cs`: Class that represents the account model, with its attributes (Id, Name, Balance) and validations.
* `AccountManager.cs`: Service class that centralizes the business logic (rules for adding, deleting, and modifying accounts).
* `ConsoleUI.cs`: Responsible for all user interaction, such as displaying menus, capturing input, and formatting output.
* `CsvHandler.cs`: Class dedicated to handling the CSV file (reading and writing data).
* `ErrorMessages.cs`: Static class that stores all error messages.