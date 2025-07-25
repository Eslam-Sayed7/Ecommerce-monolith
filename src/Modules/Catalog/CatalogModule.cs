﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Data.Interceptors;

namespace Catalog;
public static class CatalogModule 
{
  public static IServiceCollection AddCatalogModule( this IServiceCollection services, 
      IConfiguration configuration)
  {
    // Add services to the DI container 
    
    // API endpoint services
    
    // application use case services
    services.AddMediatR(cfg =>
    {
      cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    });
    
    // Data - Infrastructure services
    var connectionString = configuration.GetConnectionString("Database");
    
    services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
    services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

    services.AddDbContext<CatalogDbContext>((sp, options) =>
    {
      options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
      options.UseNpgsql(connectionString);
    });
    services.AddScoped<IDataSeeder, CatalogDataSeeder>(); 
    
    return services;
  }
  public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app)
  {
    // automating the database migration
    
    // API endpoint services
    
    // application use case ser
    
    // Data - Infrastructure services
    app.UseMigration<CatalogDbContext>();
    return app;
  }

}
