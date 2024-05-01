Sure, here's how you could structure your `README.md` file to provide clear instructions for running the project and utilizing its endpoints:

---

# Project Name

## Description

Brief description of the project.

## Prerequisites

- .NET Core SDK installed
- Database setup according to configurations in `appsettings.json`
  - At least one table named `users` should exist

## Getting Started

1. Clone the repository.
2. Navigate to the project directory: `cd project-directory`.
3. Install dependencies: `dotnet restore`.

## Running the Project

```bash
dotnet run
```

## Endpoints

### GET /users

Retrieves all active users.

### GET /users/{id}

Retrieves a user with a specific ID.

### POST /users

Inserts a new user into the database.

#### Request Body

```json
{
    "id": "id",
    "name": "name",
    "birthday": "date",
    "active": true
}
```

### PUT /users/{id}

Updates a user record with a specific ID.

#### Request Body

Same as the POST method.

### DELETE /users/{id}

Deletes a user record with a specific ID from the database.

## Example Usage

```bash
# Get all active users
curl -X GET HOST/users

# Get user with ID 123
curl -X GET HOST/users/123

# Insert a new user
curl -X POST -H "Content-Type: application/json" -d '{"id":"123","name":"John Doe","birthday":"1990-01-01","active":true}' HOST/users

# Update user with ID 123
curl -X PUT -H "Content-Type: application/json" -d '{"id":"123","name":"John Doe","birthday":"1990-01-01","active":true}' HOST/users/123

# Delete user with ID 123
curl -X DELETE HOST/users/123
```

