using FinancialGoalManager.API.Filters;
using FinancialGoalManager.API.Jobs;
using FinancialGoalManager.API.Middleware;
using FinancialGoalManager.Application.Commands.FinancialGoals.RegisterGoal;
using FinancialGoalManager.Application.Validators.FinancialGoal;
using FinancialGoalManager.Core.Repositories;
using FinancialGoalManager.Core.Services;
using FinancialGoalManager.Infrastructure.MessageBus;
using FinancialGoalManager.Infrastructure.Persistence;
using FinancialGoalManager.Infrastructure.Persistence.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace FinancialGoalManager.API.Extensions
{
    public static class ServiceConfiguration
    {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.ConfigureDependencyInjection();
            builder.ConfigureOthersServices();

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

        public static IServiceCollection ConfigureDependencyInjection(this WebApplicationBuilder builder)
        {
            var services = builder.Services;

            services.AddScoped<IFinancialGoalRepository, FinancialGoalRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IReportsRepository, ReportsRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMessageBusService, MessageBusService>();
            services.AddTransient<GlobalExceptionHandler>();

            return services;
        }

        public static IServiceCollection ConfigureOthersServices(this WebApplicationBuilder builder)
        {
            var services = builder.Services;

            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(RegisterGoalCommand).Assembly);
            });

            services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)))
                    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RegisterGoalValidator>());

            builder.Services.AddDbContext<FinancialGoalManagerDbContext>(options
                => options.UseSqlServer(builder.Configuration.GetConnectionString("FinancialGoalManagerDb")));

            services.AddHostedService<RememberDaysLeftJob>();

            return services;
        }
    }
}