using Api.Extensions;
using Application;
using Infrastructure;

namespace Api;

public class Startup
{
    public void ConfigureServices(WebApplicationBuilder builder)
    {
        builder
            .AddApi()
            .AddApplication()
            .AddInfrastructure(builder.Configuration);
    }

    public void Configure(WebApplication app)
    {
        app.UseHttpLogging();
        app.UseSwaggerDoc();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
    }
}