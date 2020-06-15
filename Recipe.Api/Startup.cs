using EventBus;
using EventBusRabbitMq;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Recipe.Application.Repositories;
using Recipe.Application.UseCases.RecipeUseCases.AddRecipe;
using Recipe.DataAccess;
using Recipe.DataAccess.Repositories;
using System;
using System.IO;
using System.Reflection;

namespace Recipe.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Recipe API",
                    Version = "v1",
                    Description = "ASP.NET Core Web API",
                    Contact = new OpenApiContact
                    {
                        Name = "Aleksandar Milicevic",
                        Email = "aleksandarmilicevic18@gmail.com",
                        Url = new Uri("https://github.com/whatsaaaa")
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddTransient<IEventBus, RabbitMQEventBus>(
                eb =>
                {
                    var config = Configuration.GetSection("RabbitMQ");
                    return new RabbitMQEventBus(config["host"], config["username"], config["password"]);
                });

            services.AddMediatR(typeof(AddRecipeUseCase));

            services.AddDbContext<FoodDbContext>(cfg =>
            {
                var connectionString = Configuration.GetSection("SqlConnection").Value;
                cfg.UseSqlServer(connectionString);
            });

            services.AddTransient<IRecipeRepository, EfRecipeRepository>();
            services.AddTransient<IIngredientRepository, EfIngredientRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Recipe API v1");
            });
        }
    }
}
