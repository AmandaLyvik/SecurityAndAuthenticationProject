
# Activity 1:

## Step 1: Set up project

### 1. Create project

`dotnet new mvc -o FinalProject`

### 2. Set up the form view

2.1 Create `Models/UserInput.cs`
2.2 Create `Controllers/FormController.cs`
2.3 Create `Views/Form/Index.cshtml`

### 3. Set up the database

3.1 Add EF dependencies 
3.2 Create `Models/User.cs`
3.3 Create `Data/AppDbContext.cs`
3.4 Configure database in `Program.cs`
3.5 Add connection string to `appsettings.json``
3.6 Apply migrations

Now we have the `FinalProject.db` file

### 4 Add tests

4.1 Create the project `dotnet new nunit -o FinalProject.Tests`
4.2 Create test file `FinalProject.Tests/Tests/TestInputValidation.cs`

To run the tests `dotnet test`


## Step 2: input validation

2.1 Create `Helpers/InputValidator.cs` to validate inputs
2.2. Create `Services/AuthService.cs` to store users
2.3 Call `AuthService` in `FormController.cs` submit route

## Step 3: Parametrize SQL queries

In `AuthService` we use query strings like "INSERT INTO Users (Username, Email, PasswordHash, Role) VALUES (@Username, @Email, @PasswordHash, @Role)" and `SqliteCommand` to set the parameters.


# Activity 2

## Step 2: Add login functionality

2.1 Add `password` to the `UserInput` model 
2.2 Create the `PasswordHelper` class to Hash and verify passwords
2.3 When registrating a user, hash the password. When loging in, verify the password

## Step 3: Implement RBAC

3.1 Add `Role` to the `User` model
3.2 Store the username in the session when logging in and check the users role when accessing the restricted route. NOTE that this should be done with jwt but I could not get it working 

------

# Security Summary

## Vulnerabilities Identified and Fixes Applied

### SQL Injection Risk 
❌ Initial Issue: Raw SQL queries with user input posed a risk of SQL injection. 
✅ Fix: Replaced raw queries with parameterized SQL using SqliteCommand and `@parameter` syntax to safely bind user input.

### Weak Input Validation 
❌ Initial Issue: Malformed or malicious data entries through user inputs. 
✅ Fix: Introduced `InputValidator.cs` to enforce validation rules (e.g., email format, password strength).

### Plaintext Password Storage 
❌ Initial Issue: Storing passwords in plaintext, exposing user credentials. 
✅ Fix: Implemented `Password.cs` to hash passwords using a secure algorithm (e.g., SHA256 or bcrypt) before storing them.

### Role-Based Access Control (RBAC) 
❌ Initial Issue: All users had equal access, including to restricted routes. 
✅ Fix: Added a Role field to the User model and enforced role checks in controllers. Session-based role validation was used as a temporary measure.

### Session Management Without JWT 
⚠️ Limitation: JWT-based authentication was intended but not fully implemented. Session-based auth was used instead, which is less secure and scalable.


# 🤖 How Copilot Helped

    - Code Suggestions: Copilot accelerated development by suggesting boilerplate code for controllers, models, and validation logic.

    - Security Guidance: It flagged insecure patterns (like raw SQL) and recommended safer alternatives such as parameterized queries.

    - Debugging Assistance: During login and hashing implementation, Copilot helped troubleshoot issues like incorrect password verification and null reference errors.

    - Learning Support: Provided inline documentation and examples for .NET security best practices, including hashing, validation, and session handling.

