﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Entities;
using Contracts;
using Repository;
using Microsoft.AspNetCore.Builder;

namespace SFPrj.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                  builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options => {
            });

        public static void ConfigurePostgreSqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["postgresqlconnection:connectionString"];
            services.AddDbContext<RepositoryContext>(o => o.UseNpgsql(connectionString));
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services)
            => services.AddScoped<IRepositoryManager, RepositoryManager>();
    }
}
