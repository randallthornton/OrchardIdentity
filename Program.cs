using OrchardCore.Logging;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog();

    builder.Services.AddOrchardCms();

    // Add services to the container.

    var app = builder.Build();

    app.UseStaticFiles();

    app.UseOrchardCore(c =>
    {
        c.UseSerilogTenantNameLogging();
    });

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}


