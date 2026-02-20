# Bank System (C# Console Application)

## Overview

The Bank System is a console-based application developed using C# and Object-Oriented Programming (OOP) principles.
It simulates basic banking operations such as creating accounts, depositing money, withdrawing money, and transferring funds between accounts.

The project is designed using clean architecture concepts including the Repository Pattern, Service Layer, and proper separation of concerns. It also includes unit tests to ensure the correctness of business logic.

This project demonstrates strong fundamentals in:

* Object-Oriented Programming (OOP)
* Software Architecture
* Repository Pattern
* Layered Architecture
* Unit Testing using xUnit

---

## Features

The system supports the following operations:

* Create a new bank account
* Deposit money into an account
* Withdraw money from an account
* Transfer money between accounts
* View account details
* View all accounts

The system ensures:

* Withdrawal limits are enforced
* Balance validation is performed
* Data consistency is maintained
* Proper error handling is implemented

---

## Technologies Used

* C#
* .NET
* Object-Oriented Programming (OOP)
* Repository Pattern
* xUnit (Unit Testing)
* File-based data storage
* Console Application UI

---

## Architecture

The project follows a layered architecture:

### Models Layer

Contains core business entities.

Examples:

* Account
* CurrentAccount
* SavingAccount

Responsibilities:

* Represent business data
* Contain core business rules

---

### Services Layer

Contains business logic.

Example:

* BankService

Responsibilities:

* Handle banking operations
* Validate business rules
* Communicate with repositories

---

### Repository Layer

Handles data persistence.

Interface:

* IAccountRepository

Implementation:

* FileRepository

Responsibilities:

* Save accounts
* Load accounts
* Abstract data storage

---

### UI Layer

Console-based user interface.

Example:

* Menu class

Responsibilities:

* Handle user input
* Display results
* Call service methods

---

### Tests Layer

Contains unit tests using xUnit.

Responsibilities:

* Verify business logic
* Ensure system correctness
* Prevent regressions

---

## Project Structure

```
BankSystem
│
├── BankSystem.Models
│   ├── Account.cs
│   ├── CurrentAccount.cs
│   └── SavingAccount.cs
│
├── BankSystem.Services
│   └── BankService.cs
│
├── BankSystem.Repositories
│   ├── IAccountRepository.cs
│   └── FileRepository.cs
│
├── BankSystem.UI
│   └── Menu.cs
│
├── BankSystem.Tests
│   └── BankServiceTests.cs
│
└── BankSystem.sln
```

---

## Class Diagram

This diagram shows the system architecture and relationships between classes:

* Account is the base class
* CurrentAccount and SavingAccount inherit from Account
* BankService handles business logic
* FileRepository implements IAccountRepository
* Menu interacts with BankService

---

## How to Run the Project

1. Clone the repository:

```
git clone https://github.com/youssefabojbarah-cpu/Bank-system.git
```

2. Open the solution file:

```
BankSystem.sln
```

3. Run the project using Visual Studio or:

```
dotnet run
```

---

## Example Usage

Create Account:

```
Enter name: Youssef
Account created successfully.
```

Deposit:

```
Enter account ID: 1
Enter amount: 500
Deposit successful.
```

Withdraw:

```
Enter account ID: 1
Enter amount: 200
Withdraw successful.
```

Transfer:

```
Enter source account ID: 1
Enter destination account ID: 2
Enter amount: 100
Transfer successful.
```

---

## Unit Testing

This project uses xUnit for testing.

Tests include:

* Account creation
* Deposit validation
* Withdraw validation
* Transfer validation

To run tests:

```
dotnet test
```

---

## Design Patterns Used

* Repository Pattern
* Service Layer Pattern
* Separation of Concerns
* Dependency Injection (conceptually)

---

## Future Improvements

* Add database support (SQL Server)
* Add authentication system
* Add graphical user interface (GUI)
* Add transaction history
* Convert to Web API

---

## Author

Youssef
Junior Backend Developer (C# / .NET)

---

## License

This project is for educational purposes.
