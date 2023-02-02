using System.Reflection;
using AppDbContext;
using EfCore6.AppDbContext;
using EfCore6.AppDbContext.SeedWork;
using Microsoft.EntityFrameworkCore;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddDbContext<TestContext>(options =>
            {
                options.UseSqlServer(builder.Configuration["ConnectionString"],
                    sqlServerOptionsAction: sqlOptions =>
                        {
                            sqlOptions.MigrationsAssembly(typeof(TestContext).GetTypeInfo().Assembly.GetName().Name);
                            sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                       });
                options.LogTo(Console.WriteLine);
                },
                ServiceLifetime.Scoped  //Showing explicitly that the DbContext is shared across the HTTP request scope (graph of objects started in the HTTP request)
            );

    builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console()
        .ReadFrom.Configuration(ctx.Configuration));
    
    var app = builder.Build();

    app.UseSerilogRequestLogging();
    app.UseHttpsRedirection();

    app.MapGet("/", () => "Hello World!");
    app.MapGet("/test", (TestContext dbContext) => 
    {
        var newParent = new Parent("Test");

        dbContext.Parents.Add(newParent);
        dbContext.SaveChanges();
    });

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}
