var builder = WebApplication.CreateBuilder(args);//// Create app builder

// Add services to the container.

builder.Services.AddControllers();//// Add controllers

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); // Add API explorer for Swagger
builder.Services.AddSwaggerGen(); // Add Swagger generator
var app = builder.Build(); // Build the app

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
   app.UseSwagger();  // Enable Swagger
    app.UseSwaggerUI(); //
    // Enable Swagger UI
}

app.UseHttpsRedirection(); // it adds the middleware to redirect http request to https

app.UseAuthorization(); // it adds the middleware to handle authorization for the application

app.MapControllers(); //// Maps API controller routes

app.Run(); // Run the application
