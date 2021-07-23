using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using url_shortener.Services;
using url_shortener.Interfaces;
using url_shortener.Repositories;
using Dapper;
using System.Data.SqlClient;

namespace url_shortener
{
    public static class DatabaseConfig{
    }

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
            services.AddTransient<IShorteningService, ShorteningService>();
            services.AddTransient<IShorteningRepository, ShorteningRepository>();
        }

        private void checkEnvironmentVariables(){
            var keys = new List<string>(){ "connectionString" };

            foreach(var key in keys){
                var value = Environment.GetEnvironmentVariable(key);
                if(String.IsNullOrEmpty(value)){
                    throw new Exception($"Expected Environment variable {key} to be set");
                }
            }
        }

        //If this errors, let it. The application depends upon it
        public static void InitDatabase(string connectionString){
            using var connection = new SqlConnection(connectionString);

            //Move this chunky SQL to it's own file. Inlining SQL can get messy
            var sql = @"
                IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'URLS')
                BEGIN
                    CREATE TABLE URLS ( 
                        ID_column INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
                        url VARCHAR(MAX) not null
                    );
                END
            ";

            var result = connection.Execute(sql);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            checkEnvironmentVariables();

            var connectionString = Environment.GetEnvironmentVariable("connectionString");

            InitDatabase( connectionString );

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
