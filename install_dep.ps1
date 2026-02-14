# Configuration
$SolutionName = "CarDealerShipBackend"

Write-Host "Starting NuGet Package Installation..." -ForegroundColor Cyan

# --- 1. DOMAIN LAYER ---
# Needs this to inherit 'IdentityUser' in the Entity class without referencing the whole ASP.NET Core stack
Write-Host "Installing packages for Domain..." -ForegroundColor Yellow
dotnet add "$SolutionName.Domain" package Microsoft.Extensions.Identity.Stores

# --- 2. INFRASTRUCTURE LAYER ---
# Needs EF Core, MySQL Provider, and Identity EF integration
Write-Host "Installing packages for Infrastructure..." -ForegroundColor Yellow
dotnet add "$SolutionName.Infrastructure" package Microsoft.EntityFrameworkCore
dotnet add "$SolutionName.Infrastructure" package Pomelo.EntityFrameworkCore.MySql
dotnet add "$SolutionName.Infrastructure" package Microsoft.AspNetCore.Identity.EntityFrameworkCore

# --- 3. API LAYER ---
# Needs EF Tools for migrations and JWT Bearer for token validation
Write-Host "Installing packages for API..." -ForegroundColor Yellow
dotnet add "$SolutionName.Api" package Microsoft.EntityFrameworkCore.Design
dotnet add "$SolutionName.Api" package Microsoft.AspNetCore.Authentication.JwtBearer

Write-Host "All packages installed successfully!" -ForegroundColor Green