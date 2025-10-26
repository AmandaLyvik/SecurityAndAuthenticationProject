
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

## Step 3: 


