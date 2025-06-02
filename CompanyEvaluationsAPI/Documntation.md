# Company Evaluations API Guide

## 1. Overview
This document explains the architecture, design patterns, workflows, and key practices used in this ASP.NET Core Web API project. The structure is built to be clear, maintainable, and reusable across other projects.

## 2. Architecture Layers
* **API Layer (Controllers)** - Handles HTTP requests/responses, does model binding, validation, and calls the service layer.
* **Service(core) Layer** - Business logic lives here. Coordinates operations and calls Unit of work.
* **Infrastructure Layer** - Deals with Everything related to database operations and data access.

## 3. Design Patterns Used
* **Repository Pattern**: abstracts data access.
* **Unit of Work**: coordinates repository operations as a transaction.
* **Service Pattern**: contains business logic.

## 4. Typical Workflow
1. Request hits Controller.
2. Model binding converts JSON to DTO.
3. Controller calls Service.
5. Service calls Repository for DB operations.
6. Unit of Work commits changes.
7. Service returns result to Controller.
8. Controller returns HTTP response.

## 5. Async Programming
* All DB calls and I/O operations use async/await.
* Service and repository methods return Task or Task<T>.

Example:
```
public async Task<bool> HasAlreadyRated(int raterId)
        {
            return await context.Ratings.AnyAsync(r => r.RaterId == raterId);
        }
```

## 6. DTO Usage
* Separate DTOs for input and output.
* Keeps internal models safe from external changes.

Example DTO:
```csharp
public class RatedEmployeeDto
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [Range(1,5)]
        public int rate{ get; set; }
    }
```

## 7. EF Core & Code First
* Code First approach with migrations.
* Models decorated with annotations or fluent API.
* MySQL supported through Pomelo or MySQL EF Core provider.

## 8. Dependency Injection
* Built-in DI container in ASP.NET Core.
* Services, repositories, and unit of work registered with scoped lifetime.
* Controllers receive dependencies via constructor injection.

Example:
```csharp
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
```


## 10. Error Handling & Validation
* Use data annotations for basic validation.
* Return proper HTTP codes (`400`, `404`, etc).
* Global error handling in service layer  for consistency.


## 13. WorkFlow Summary Diagram
```
[Request] → [Controller] → [Service] → [Repository] → [Database]
    ↑                                     ↓             ↓
[DTOs]                                [Domain Models]
                                        [Context]
``` 

##14. OutPut

* Get Specific Employee evaluations
** YOU CAN FIND OUTPUT IN IMAGES DIRECTORY
