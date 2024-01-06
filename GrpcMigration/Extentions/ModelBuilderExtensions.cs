using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using GrpcMigration.Data;

namespace GrpcMigration.Extentions
{
    public static class ModelBuilderExtensions
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            var serviceProvider = services.AddDbContext<ProductManagingDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("ProductManaging"), opts => ConfigureSqlOptions(opts, schema: ProductManagingDbContext.DEFAULT_SCHEMA));
                //});
            }).BuildServiceProvider();

            // Get the DbContext from the service provider
            using (var dbContext = serviceProvider.GetRequiredService<ProductManagingDbContext>())
            {
                // Apply pending migrations and update the database
                bool isChange = dbContext.Database.GetPendingMigrations().Any();
                if (isChange)
                {
                    dbContext.Database.Migrate();
                }                
            }

            return services;
        }

        static void ConfigureSqlOptions(NpgsqlDbContextOptionsBuilder sqlOptions, string schema = "")
        {
            sqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, schema);

            // Configuring Connection Resiliency: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency 
            sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorCodesToAdd: null);
        }

    }
}
