﻿using System;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProjectReceitas.Api.Security;
using ProjectReceitas.Data.Context;
using ProjectReceitas.Data.Repository;
using ProjectReceitas.Domain.Interface;
using ProjectReceitas.Domain.Interfaces;
using ProjectReceitas.Service.Service;
using ProjectReceitas.Service.Service.Interface;
using Swashbuckle.AspNetCore.Swagger;


namespace ProjectReceitas.Api
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
            services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(Configuration["ConnectionString:ProjectReceitasBd"], b => b.MigrationsAssembly("ProjectReceitas.Api")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                              .AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            //ValidIssuer = Configuration["Jwt:Issuer"],
                            //ValidAudience = Configuration["Jwt:Issuer"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                        };
                    });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "API",
                    Description = "ProjectReceitas Api",
                    TermsOfService = "None",
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });

            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            services.AddTransient<IReceitaService, ReceitaService>();
            services.AddTransient<IReceitaRepository, ReceitaRepository>();

            services.AddTransient<IIngredienteService, IngredienteService>();
            services.AddTransient<IIngredienteRepository, IngredienteRepository>();

            services.AddTransient<IPreparoService, PreparoService>();
            services.AddTransient<IPreparoRepository, PreparoRepository>();

            services.AddSingleton<JwtService>();

            services.AddCors();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(options =>
            {
                options.WithOrigins("*").WithMethods("GET", "POST", "DELETE", "PUT", "PATCH")
                .AllowAnyHeader()
                .AllowCredentials();
            });

            app.UseAuthentication();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjectReceitas API V1");
            });

            app.UseCors(option => option.AllowAnyOrigin());
        }

    }
}
