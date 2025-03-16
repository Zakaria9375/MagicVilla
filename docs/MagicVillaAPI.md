# MagicVillaAPI

What do you need to make an API

## Folder Structure

- src
  - Controllers
  - Data (AppDbContext) for DB
  - DTOs
  - Models (Entities) for DB
  - Repository (Operations collected on db)

- pipelines
- docs

## Controller

Let us keep it as our standard to make

1. `BaseController` and other controller will extend this controller to inherit functionality.
2. `APIResponse` to keep our structured API.

To work with Patch, you need 2 packages:

1. Microsoft.AspNetCore.JsonPatch
2. Microsoft.AspNetCore.Mvc.NewtonsoftJson

## EF

Let say that we need to save our date to database

We need 2 packages

1. Microsoft.EntityFrameworkCore.Tools
2. Microsoft.EntityFrameworkCore.SqlServer

We need to make `AppDbContext` and register it with data sets adn register the service in program.cs.

### Migration

```pwsh
add-migration AddVillaTable
update-database

```

## Logging

Using default logger or custom one like `Serilog`

We need the following packages:

1. Serilog.AspNetCore
2. Serilog.Sinks.File

## Repository

Let us keep it as Standard to have `IRepository` and `Repository` to make the repos inherit it.

## AutoMapper 

For mapping between objects and you need 2 packages for that AutoMapper and AutoMapper.DI

