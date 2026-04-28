using FinTrack.Application.Transactions;
using FinTrack.Application.Categories;
using FinTrack.Application.Transactions.Commands.CreateTransaction;
using FinTrack.Infrastructure.Datas;
using FinTrack.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using FinTrack.Application.Categories.Commands.CreateCategoryCommand;

internal class Program
{
    private static void Main(string[] args)
    {
        // Carrega as variáveis do arquivo .env
        Env.Load();

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddOpenApi();

        //Add DbContext
        var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? builder.Configuration.GetConnectionString("FinTrackConnection");
        builder.Services.AddDbContext<FinTrackDbContext>(options => options.UseNpgsql(connectionString));

        //Add Repositories
        builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

        //Add MediatR
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateTransactionCommandHandler).Assembly));
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCategoryCommandHandler).Assembly));

        //ADD Controllers
        builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }
}