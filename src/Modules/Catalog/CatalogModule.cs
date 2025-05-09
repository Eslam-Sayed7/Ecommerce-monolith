﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog;
public static class CatalogModule 
{
  public static IServiceCollection AddCatalogModule( this IServiceCollection services, 
      IConfiguration configuration)
  {
    // Add services to the DI container 
    // services
        // .AddApplicationServices()
        // .AddInfrastructureSercies(configuration)
        // .AddApiServices(configuration);
    return services;
  }
  public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app)
  {
    // Configure the HTTP request pipeline.
    // app.UseEndpoints(endpoints => 
    //   {
    //     endpoints.MapControllers();
    //   });
    return app;
  }

}
