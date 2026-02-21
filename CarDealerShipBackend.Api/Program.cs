using CarDealerShipBackend.Domain.Constants;
using CarDealerShipBackend.Infrastructure; // Import your new class
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// --- CLEAN ARCHITECTURE INJECTION ---
// This single line sets up DB, Identity, JWT, and Auth Services
builder.Services.AddInfrastructure(builder.Configuration);
// ------------------------------------

// Add Authorization Policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Permissions.CanManageUsers, policy => policy.RequireClaim("Permission", Permissions.CanManageUsers));
    options.AddPolicy(Permissions.CanViewDashboard, policy => policy.RequireClaim("Permission", Permissions.CanViewDashboard));
    options.AddPolicy(Permissions.CanEditProfile, policy => policy.RequireClaim("Permission", Permissions.CanEditProfile));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Swagger Config
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable Auth Middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();