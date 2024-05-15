using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using PlataformaCursos.Application.Interfaces;
using PlataformaCursos.Application.Mappings;
using PlataformaCursos.Application.Services;
using PlataformaCursos.Domain.Interfaces;
using PlataformaCursos.Infrastructure.Data.Context;
using PlataformaCursos.Infrastructure.Data.Repositories;
using System.Text;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlataformaCursos.Domain.Authetication;
using PlataformaCursos.Infrastructure.Data.Identity;
using ElmahCore.Mvc;
using ElmahCore.Sql;

namespace PlataformaCursos.Infrastructure.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            services.AddElmah<SqlErrorLog>(options =>
            {
                options.ConnectionString = configuration.GetConnectionString("DefaultConnection");
                options.Path = "/elmah";
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = configuration["jwt:issuer"],
                    ValidAudience = configuration["jwt:audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:secretKey"] ?? "")),
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.Configure<RazorPagesOptions>(options => options.RootDirectory = "/API/Controllers");

            services.AddAutoMapper(typeof(DomainDTOMappingProfile));
            services.AddScoped<IAuthenticate, Authenticate>();

            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IAnexoRepository, AnexoRepository>();
            services.AddScoped<ICapituloRepository, CapituloRepository>();
            services.AddScoped<IMatriculaRepository, MatriculaRepository>();

            services.AddScoped<IMatriculaService, MatriculaService>();
            services.AddScoped<ICapituloService, CapituloService>();
            services.AddScoped<IAnexoService, AnexoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ICursoService, CursoService>();

            services.AddCors(options => options.AddPolicy("PolicyCors", policy =>
            {
                /*policy.AllowAnyMethod().AllowAnyHeader().AllowCredentials().WithOrigins("https://www.google.com.br"));*/
                policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            }));

            return services;
        }
    }
}
