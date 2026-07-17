using day5studentapihandling.Interfaces;
using day5studentapihandling.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IStudentService, StudentService>();
// CORS(cross origin research service) ADD HERE (Services part)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        p => p.AllowAnyOrigin()
             .AllowAnyHeader()
             .AllowAnyMethod());
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//IMPORTANT: UseCors must be BEFORE MapControllers
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
