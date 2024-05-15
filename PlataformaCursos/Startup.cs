using PlataformaCursos.Infrastructure.IOC;
using PlataformaCursos.API.Middleware;
using Microsoft.AspNetCore.Http.Features;
using ElmahCore.Mvc;


namespace PlataformaCursos
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddInfrastructureSwagger();
            services.AddInfrastructure(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(options =>
                {
                    options.SerializeAsV2 = true;
                });
               
                app.UseSwaggerUI(c => {
                    c.RoutePrefix = "swagger";
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                });
            }
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseHttpsRedirection();
            app.UseCors("PolicyCors");
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseWhen(context => context.Request.Path.StartsWithSegments("/elmah", StringComparison.OrdinalIgnoreCase), appBuilder =>
            {
                appBuilder.Use(next =>
                {
                    return async ctx =>
                    {
                        ctx.Features.Get<IHttpBodyControlFeature>()!.AllowSynchronousIO = true;
                        await next(ctx);
                    };
                });
            });
            app.UseElmah();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToController("index", "Fallback");
               
            });
            
        }
    }
}
