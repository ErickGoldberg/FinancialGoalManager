using FinancialGoalManager.Application.Commands.FinancialGoals.RegisterGoal;
using FinancialGoalManager.Core.Repositories;
using FinancialGoalManager.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(RegisterGoalCommand).Assembly);
});

builder.Services.AddScoped<IFinancialGoalRepository, FinancialGoalRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IReportsRepository, ReportsRepository>();




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
