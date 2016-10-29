using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.Swagger.Model;
using Swashbuckle.SwaggerGen.Generator;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;

public class Handler {

    public IConfigurationRoot Configuration { get; }

    public Handler(IHostingEnvironment env)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
        Configuration = builder.Build();
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc(); //.AddXmlSerializerFormatters();
        services.AddSingleton<IBlogRepo, Blog>();
        services.AddSwaggerGen();
        services.ConfigureSwaggerGen(options =>
        {
            options.SingleApiVersion(new Info
            {
                Version = "v1",
                Title = "Simple DB Example",
                Description = "A sample boilerplate for .NET Core"
            });
            options.IgnoreObsoleteActions();
            options.IgnoreObsoleteProperties();
            options.DescribeAllEnumsAsStrings();
        });
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logger) {
        // logger.AddConsole(Configuration.GetSection("Logging"));
        logger.AddDebug();

        // if (env.IsDevelopment())
        // {
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();
        // }

        app.UseStaticFiles();
        app.UseMvc();
        app.UseSwagger();
        app.UseSwaggerUi();
    }

}