using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Template.Api.Extensions;

public static class DbContextExtension
{
    public static WebApplicationBuilder RegisterDbContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContextFactory<TemplateContext>(
            opt =>
            {
                var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
                var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
                var dbUser = Environment.GetEnvironmentVariable("DATABASE_USER");
                var dbPassword = Environment.GetEnvironmentVariable("DATABASE_PASSWORD");
                var dbName = Environment.GetEnvironmentVariable("DB_NAME");

                var connectionString =
                    $"Server={dbHost};port={dbPort};user id={dbUser};password={dbPassword};database={dbName};pooling=true";

                opt.UseNpgsql(connectionString);
            },
            ServiceLifetime.Scoped
        );

        builder.Services.AddScoped<TemplateContext>(sp =>
            sp.GetRequiredService<IDbContextFactory<TemplateContext>>().CreateDbContext()
        );

        return builder;
    }

    public static void ExecuteMigrations(this WebApplication app)
    {
        using var serviceScope = app.Services.CreateScope();
        serviceScope
            .ServiceProvider.GetRequiredService<IDbContextFactory<TemplateContext>>()
            .CreateDbContext()
            .Database.Migrate();
    }
}
