using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProyectoIntegrado.BL.Contracts;
using ProyectoIntegrado.BL.Implementations;
using ProyectoIntegrado.CORE.Email;
using ProyectoIntegrado.CORE.Security;
using ProyectoIntegrado.DAL.Contracts;
using ProyectoIntegrado.DAL.Entities;
using ProyectoIntegrado.DAL.Repositories.Contracts;
using ProyectoIntegrado.DAL.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProyectoIntegrado.CORE.AutomapperProfile.AutomapperProfile;

namespace ProyectoIntegrado.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public  Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //Habilitar cors en la API
            string[] exposedHeaders = { "Authorization" };
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders(exposedHeaders));
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"]))
                };
            });
            services.AddAuthorization(config =>
            {
                var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                defaultAuthorizationPolicyBuilder = defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
                config.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
               // config.AddPolicy(Policies.EMPRESA, policy => { policy.RequireClaim("Role", Policies.EMPRESA); });
            });


            AddSwagger(services);

            services.AddAutoMapper(cfg=>cfg.AddProfile(new AutoMapperProfile()));
            //aniade el contexto de la base de datos y la configuracion a traves del fichero appsettings.json
            services.AddDbContext<proyectointegradodbContext>(opts => opts.UseMySql(Configuration["ConnectionString:proyectointegradodb"], ServerVersion.AutoDetect(Configuration["ConnectionString:proyectointegradodb"])));
            // inyecciones : interfaz-clase
            services.AddScoped<IAlumnoBL, AlumnoBL>();
            services.AddScoped<IAlumnoRepository, AlumnoRepository>();

            services.AddScoped<IEmpresaBL, EmpresaBL>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();

            services.AddScoped<IPasswordGenerator, PasswordGenerator>();

            services.AddScoped<IPosicionDeTrabajoBL, PosicionDeTrabajoBL>();
            services.AddScoped<IPosicionDeTrabajoRepository, PosicionDeTrabajoRepository>();

            services.AddScoped<IProvinciaBL, ProvinciaBL>();
            services.AddScoped<IProvinciaRepository, ProvinciaRepository>();

            services.AddScoped<IFamiliaProfesionalBL, FamiliaProfesionalBL>();
            services.AddScoped<IFamiliaProfesionalRepository, FamiliaProfesionalRepository>();

            services.AddScoped<ITipoDeCicloBL, TipoDeCicloBL>();
            services.AddScoped<ITipoDeCicloRepository, TipoDeCicloRepository>();

            services.AddScoped<ICicloBL, CicloBL>();
            services.AddScoped<ICicloRepository, CicloRepository>();

            services.AddScoped<IInscripcionBL, InscripcionBL>();
            services.AddScoped<IInscripcionRepository, InscripcionRepository>();

            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IJwtBearer, JwtBearer>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Proyecto_Integrado API V1");
            });

            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {

                var groupName = "v1";


                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            Array.Empty<string>()
                        }
                    });


                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Neuro {groupName}",
                    Version = groupName,
                    Description = "Proyecto_Integrado",
                    Contact = new OpenApiContact
                    {
                        Name = "Proyecto_Integrado",
                        Email = string.Empty,
                        Url = new Uri("https://foo.com/"),
                    }
                });
            });
        }
    }
}
