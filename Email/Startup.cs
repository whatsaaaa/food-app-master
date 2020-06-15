using Email.Extensions;
using Email.Interfaces;
using Email.Options;
using Email.Senders;
using EventBusRabbitMq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Email
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
            services.AddTransient<EventBus.IEventBus, RabbitMQEventBus>(
                eb =>
                {
                    var config = Configuration.GetSection("RabbitMQ");
                    return new RabbitMQEventBus(config["host"], config["username"], config["password"]);
                });
            services.Configure<EmailOptions>(options => Configuration.GetSection("Email").Bind(options));
            services.AddTransient<IEmailSender, TestSenders>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var eventBus = app.ApplicationServices.GetService<EventBus.IEventBus>();
            var emailService = app.ApplicationServices.GetService<IEmailSender>();

            eventBus.ManageSubscriptions(emailService);


            app.Run(async (context) => await context.Response.WriteAsync("Email Service Started..."));
        }
    }
}
