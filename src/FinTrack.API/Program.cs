using FinTrack.Application.Transactions;
using FinTrack.Application.Transactions.Commands.CreateTransaction;
using FinTrack.Infrastructure.Datas;
using FinTrack.Infrastructure.Repositorys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddOpenApi();

        //Add DbContext
        var connectionString = builder.Configuration.GetConnectionString("FinTrackConnection");
        builder.Services.AddDbContext<FinTrackDbContext>(options => options.UseNpgsql(connectionString));

        //Add Repositories
        builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

        //Add MediatR
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateTransactionCommandHandler).Assembly));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.Run();
    }
}