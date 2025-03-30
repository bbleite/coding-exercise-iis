using BankApplicationIIS;
using BankApplicationIIS.Repositories;
using BankApplicationIIS.Repositories.Interfaces;
using BankApplicationIIS.Services;
using BankApplicationIIS.Services.Interfaces;
using BankApplicationIIS.Services.Mapings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Register Dependency Injection
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddSingleton<FakeData>();

builder.Services.AddAutoMapper(typeof(AccountProfile));

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
