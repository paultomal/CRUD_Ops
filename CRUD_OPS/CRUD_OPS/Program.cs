using Microsoft.EntityFrameworkCore;
using CRUD_OPS.Models;
using CRUD_OPS;
using CRUD_OPS.BL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EmployeeServicesContext>(options =>
options.UseLazyLoadingProxies(false). UseSqlServer(builder.Configuration.GetConnectionString("constr")
));
builder.Services.AddScoped<IEmp,EmployeService>();

var app = builder.Build();

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
