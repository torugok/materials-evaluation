using System.Globalization;
using System.Text.Json.Serialization;
using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using FluentValidation;
using MaterialsEvaluation.Database;
using MaterialsEvaluation.Middlewares;
using MaterialsEvaluation.Modules.QualityEvaluation;
using MaterialsEvaluation.Modules.QualityEvaluation.Application.Commands;
using MediatR.Extensions.Autofac.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace MaterialsEvaluation
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IWebHostEnvironment env)
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json")
                .AddUserSecrets<Startup>()
                .AddEnvironmentVariables()
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";

            services.AddCors(options =>
            {
                options.AddPolicy(
                    myAllowSpecificOrigins,
                    policy =>
                    {
                        policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod(); // FIXME: configurar CORS apropriadamente para produção
                    }
                );
            });

            // Add services to the container.
            services
                .AddControllers()
                .AddJsonOptions(opts => // Para converter Enums de Int para Strings na serialização
                {
                    var enumConverter = new JsonStringEnumConverter();
                    opts.JsonSerializerOptions.Converters.Add(enumConverter);
                });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<DatabaseContext>(
                opt => opt.UseSqlite("Data Source=materials-evaluation.db") // HACK: utilizar SQL Server
            );

            services.AddValidatorsFromAssemblyContaining<CreateQualityVisionValidator>();
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterMediatR(typeof(Startup).Assembly);
            builder.RegisterAutoMapper(typeof(Startup).Assembly);

            // local modules
            builder.RegisterModule(new QualityEvaluationAutofacModule());
        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IServiceProvider serviceProvider
        )
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("_myAllowSpecificOrigins");

            app.UseRouting();

            app.UseAuthorization();

            // global error handler
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
