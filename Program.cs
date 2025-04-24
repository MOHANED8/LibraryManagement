using LibraryAPI.Data;                 // For LibraryContext
using Microsoft.EntityFrameworkCore;   // For UseInMemoryDatabase

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure In-Memory DB (you can switch to SQL Server later)
builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseInMemoryDatabase("LibraryDB"));

var app = builder.Build();

// Swagger for testing
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

// Map controller routes
app.MapControllers();

// Seed initial data (optional)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<LibraryContext>();
    DbSeeder.Seed(db);  // You must have DbSeeder.cs file with Seed method
}

// Run the app
app.Run();
