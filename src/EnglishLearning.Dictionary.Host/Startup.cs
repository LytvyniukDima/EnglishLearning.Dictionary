using System.Text.Json.Serialization;
using EnglishLearning.Dictionary.Application.Configuration;
using EnglishLearning.Dictionary.Host.Configuration;
using EnglishLearning.Dictionary.Host.Infrastructure;
using EnglishLearning.Dictionary.Infrastructure.Configuration;
using EnglishLearning.Dictionary.Infrastructure.Infrastructure;
using EnglishLearning.Dictionary.Web.Infrastructure;
using EnglishLearning.Utilities.General.Extensions;
using EnglishLearning.Utilities.Identity.Configuration;
using EnglishLearning.Utilities.Persistence.Redis.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishLearning.Dictionary.Host
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers(options => options.AddEnglishLearningIdentityFilters())
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            services
                .AddRedis(Configuration)
                .AddEnglishLearningIdentity();
            
            services.AddSwaggerDocumentation();
            
            services.AddCors(options =>
            {
                options.AddPolicy(
                    "CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithExposedHeaders("Authorization", "Content-Disposition"));
            });

            services
                .AddEnglishLearningHttp(Configuration)
                .AddApplication()
                .AddInfrastructure();

            services.AddAutoMapper(
                typeof(WebMapperProfile).Assembly,
                typeof(InfrastructureMapperProfile).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseEnglishLearningExceptionMiddleware();
            
            app.UseCors("CorsPolicy");

            app.UseSwaggerDocumentation();
            
            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}