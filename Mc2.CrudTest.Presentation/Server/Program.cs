using Mc2.CrudTest.Presentation.Server.ReadModel.ApplicationService.Queries;
using Mc2.CrudTest.Presentation.Server.ReadModel.ApplicationService.QueryHandler;
using Mc2.CrudTest.Presentation.Server.ReadModel.Facade.CustomerReadFacade;
using Mc2.CrudTest.Presentation.Server.ReadModel.Facade.CustomerReadFacade.Abstractions;
using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.ApplicationService.Commands;
using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.ApplicationService.Handlers;
using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Domain.CustomerAggregate;
using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Domain.CustomerAggregate.services;
using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Facade;
using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Facade.Abstractions;
using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Infrustructure.CustomerServices;
using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Infrustructure.DataPersistence;
using Mc2.CrudTest.Presentation.Server.WriteModel.CustomerContext.Infrustructure.DataPersistence.Repositories;
using Mc2.CrudTest.Presentation.Shared.Application.Abstractions;
using Mc2.CrudTest.Presentation.Shared.DataPersistance.Abstractions;
using Mc2.CrudTest.Presentation.Shared.DependencyInjection;
using Mc2.CrudTest.Presentation.Shared.DependencyInjection.Abstractions;
using Mc2.CrudTest.Presentation.Shared.Domain;
using Mc2.CrudTest.Presentation.Shared.Facade;
using Mc2.CrudTest.Presentation.Shared.Facade.Abstractions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Mc2.CrudTest.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string? connectionString = builder.Configuration.GetConnectionString("SqliteConnection");

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(connectionString));

            // Add services to the container.
            builder.Services.AddScoped<IDBContext, TransActionDbContext>();
            builder.Services.AddScoped<IDIContainer, DIContainer>();

            builder.Services.AddScoped<ICommandMediator, CommandMediator>();
            builder.Services.AddScoped<IQueryMediator, QueryMediator>();

            builder.Services.AddTransient<ICommandHandler<AddCustomerCommand>, AddCustomerCommandHandler>();
            builder.Services.AddTransient<ICommandHandler<RemoveCustomerCommand>, RemoveCustomerCommandHandler>();
            builder.Services.AddTransient<ICommandHandler<UpdateCustomerCommand>, UpdateCustomerCommandHandler>();

            builder.Services.AddScoped<IQueryHandler<CustomerByEmailQuery, Customer>, CustomerByEmailQueryHandler>();
            builder.Services.AddScoped<IQueryHandler<CustomerByIdQuery, Customer>, CustomerByIdQueryHandler>();

            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<ICustomerValidator, CustomerValidator>();

            builder.Services.AddScoped<ICustomerFacade, CustomerFacade>();
            builder.Services.AddScoped<ICustomerReadFacade, CustomerReadFacade>();

            builder.Services.AddSwaggerGen();

            builder.Services.AddControllersWithViews();


            var app = builder.Build();

            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature.Error;
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                string result;
                if (exception is Exception)
                {
                    result = JsonSerializer.Serialize(new { message = exception.Message });
                    Console.WriteLine(exception.Message);
                }
                else
                {
                    result = JsonSerializer.Serialize(new { message = $"Internal Server Error : {exception}" });
                }
                await context.Response.WriteAsync(result);
            }));
       

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.MapControllers();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V2");
                c.RoutePrefix = string.Empty;
            });
            app.MapFallbackToFile("index.html");
            app.Run();
        }
    }
}