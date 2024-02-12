using FinancialGoalManager.Application.Commands.FinancialGoals.RegisterGoal;
using FinancialGoalManager.Core.Repositories;
using FinancialGoalManager.Infrastructure.Persistence.Repositories;
using Microsoft.OpenApi.Models;

namespace FinancialGoalManager.API.Extensions
{
    public static class ServiceConfiguration
    {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.ConfigureDependencyInjection()
                   .ConfigureOthersServices();

            builder.Services.AddControllers();

            // Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "FinancialGoalManager.API",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Erick Goldberg",
                        Email = "erick_goldberg@hotmail.com",
                        Url = new Uri("https://github.com/ErickGoldberg")
                    }
                });
            });

            return builder;
        }

        public static WebApplicationBuilder ConfigureDependencyInjection(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IFinancialGoalRepository, FinancialGoalRepository>();
            builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
            builder.Services.AddScoped<IReportsRepository, ReportsRepository>();

            return builder;
        }

        public static WebApplicationBuilder ConfigureOthersServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(RegisterGoalCommand).Assembly);
            });

            return builder;
        }
    }
}
