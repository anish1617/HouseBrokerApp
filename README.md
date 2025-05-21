# Rebate Calculator Application

A .NET application for calculating supplier rebates across multiple business units based on purchase volumes, pricing conditions, and contract types.

## Business Overview

This application manages supplier rebate calculations for a multinational agricultural products company. It handles several rebate contract types with different calculation methods, volume thresholds, and business unit mappings.

## Key Features

- **Multi-contract Rebate Calculation**: Calculate rebates across different contract types
- **Business Unit Filtering**: Apply rebates based on eligible business units
- **Volume Thresholds**: Apply rebates only when minimum purchase thresholds are met
- **Tiered Rebate Calculation**: Calculate incremental rebates for volume tiers
- **Product Conversion**: Handle concentration conversions between related products
- **Volume Adjustments**: Apply manual adjustments to purchased volumes
- **Market Share Analysis**: Calculate rebates based on market share conditions
- **Currency Handling**: Support for multi-currency rebates
- **Reporting**: Generate detailed rebate reports by supplier, contract, and product

## Technical Requirements

- .NET 8.0+
- Entity Framework Core for data access
- SQL Server or alternative database

## Project Setup Instructions

### 1. Create a New .NET Solution

```bash
# Create a new solution
dotnet new sln -n RebateCalculator

# Create API project
dotnet new webapi -n RebateCalculator.Api

# Create class library projects
dotnet new classlib -n RebateCalculator.Core
dotnet new classlib -n RebateCalculator.Infrastructure
dotnet new classlib -n RebateCalculator.Services

# Create test project
dotnet new xunit -n RebateCalculator.Tests

# Add projects to solution
dotnet sln RebateCalculator.sln add RebateCalculator.Api/RebateCalculator.Api.csproj
dotnet sln RebateCalculator.sln add RebateCalculator.Core/RebateCalculator.Core.csproj
dotnet sln RebateCalculator.sln add RebateCalculator.Infrastructure/RebateCalculator.Infrastructure.csproj
dotnet sln RebateCalculator.sln add RebateCalculator.Services/RebateCalculator.Services.csproj
dotnet sln RebateCalculator.sln add RebateCalculator.Tests/RebateCalculator.Tests.csproj
```

### 2. Setup Project References

```bash
# Core references (no project dependencies)
cd RebateCalculator.Core
dotnet add package Microsoft.Extensions.DependencyInjection.Abstractions

# Infrastructure references
cd ../RebateCalculator.Infrastructure
dotnet add reference ../RebateCalculator.Core/RebateCalculator.Core.csproj
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.Extensions.Configuration.Abstractions

# Services references
cd ../RebateCalculator.Services
dotnet add reference ../RebateCalculator.Core/RebateCalculator.Core.csproj
dotnet add reference ../RebateCalculator.Infrastructure/RebateCalculator.Infrastructure.csproj

# API references
cd ../RebateCalculator.Api
dotnet add reference ../RebateCalculator.Core/RebateCalculator.Core.csproj
dotnet add reference ../RebateCalculator.Infrastructure/RebateCalculator.Infrastructure.csproj
dotnet add reference ../RebateCalculator.Services/RebateCalculator.Services.csproj
dotnet add package Swashbuckle.AspNetCore

# Test references
cd ../RebateCalculator.Tests
dotnet add reference ../RebateCalculator.Core/RebateCalculator.Core.csproj
dotnet add reference ../RebateCalculator.Infrastructure/RebateCalculator.Infrastructure.csproj
dotnet add reference ../RebateCalculator.Services/RebateCalculator.Services.csproj
dotnet add package Moq
dotnet add package FluentAssertions
```

## Project Structure Overview

### Core Layer

The Core layer defines domain entities, interfaces, and business logic.

#### Key Domain Entities
```csharp
// RebateContract.cs
// SupplierRebate.cs
// Product.cs
// BusinessUnit.cs
// etc.
```

#### Key Interfaces
```csharp
// IRebateCalculationService.cs
// IVolumeAdjustmentService.cs
// IConcentrationConversionService.cs
// etc.
```

### Infrastructure Layer

The Infrastructure layer implements data access and external service integrations.

```csharp
// RebateCalculatorDbContext.cs
// EntityConfigurations/
// Repositories/
// CsvImporters/
```

### Services Layer

The Services layer implements the business logic for rebate calculations.

```csharp
// RebateCalculationService.cs
// PercentageRebateCalculator.cs
// PerMTRebateCalculator.cs
// TieredRebateCalculator.cs
// VolumeAdjustmentService.cs
// ConcentrationConversionService.cs
```

### API Layer

The API layer exposes endpoints for calculating rebates and managing the system.

```csharp
// Controllers/RebateContractsController.cs
// Controllers/RebateCalculationController.cs
// Controllers/SuppliersController.cs
// etc.
```

## Data Model

### Main Entities and Relationships

1. **RebateContract**
   - Unique identifier and contract terms
   - Links to eligible business units
   - Contract type (percentage, per MT, tiered)

2. **Product**
   - Global product code
   - Product name
   - Category
   - Annual global demand

3. **BusinessUnit**
   - Name
   - Country
   - Region

4. **Supplier**
   - Name
   - Contact information

5. **RebateRule**
   - Contract
   - Product
   - Volume threshold
   - Rebate rate/amount
   - Additional conditions

6. **Purchase**
   - Business unit
   - Product
   - Volume
   - Purchase date
   - Price

7. **ConcentrationConversion**
   - Original product
   - Target product
   - Conversion multiplier

## Business Logic Implementation

### Rebate Calculation Strategies

#### 1. Percentage Rebate
```csharp
// If total volume > threshold AND conditions are met:
// Rebate = Total Volume × Price × Rebate Percentage
```

#### 2. Per MT Rebate
```csharp
// If total volume > threshold:
// Rebate = Total Volume × Fixed Rebate Per MT
```

#### 3. Tiered Rate Rebate
```csharp
// For each tier:
// Tier Rebate = (min(Total Volume, Tier End) - Tier Start) × Price × Tier Rate
// Total Rebate = Sum of all tier rebates
```

### Integration Points

1. **Data Import** - Import product, contract and sales data from CSV files
2. **Calculation Engine** - Calculate rebates based on business rules
3. **Reporting** - Generate rebate payment reports by supplier and business unit

## Sample Usage

```csharp
// Example API call to calculate rebates
POST /api/rebate/calculate
{
  "supplierId": "B",
  "contractId": "B-Asia-2024",
  "businessUnit": "Vietnam",
  "year": 2024,
  "quarter": 2
}
```

## Deployment

Set up CI/CD pipeline using GitHub Actions:

1. **Build** - Build the solution
2. **Test** - Run unit tests
3. **Deploy** - Deploy to Azure App Service or your preferred hosting

## Future Enhancements

1. **Web UI** - Add a web interface for managing rebate contracts
2. **Forecasting** - Predict future rebates based on current sales trends
3. **Supplier Portal** - Allow suppliers to view their rebate status
4. **Approval Workflow** - Add approval process for rebate payments

## Getting Started

1. Clone this repository
2. Set up your database connection in `appsettings.json`
3. Run database migrations: `dotnet ef database update`
4. Import sample data from CSV files
5. Start the application: `dotnet run`