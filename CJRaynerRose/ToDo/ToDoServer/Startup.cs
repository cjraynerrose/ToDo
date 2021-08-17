using System.Reflection;
using CJRaynerRose.ToDo.Common.Context;
using CJRaynerRose.ToDo.Common.Main;
using CJRaynerRose.ToDo.Server.Persistence.InMemory.Main;
using CJRaynerRose.ToDo.Server.UseCases.Main;
using CJRaynerRose.ToDo.Server.UseCases.Store;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CJRaynerRose.ToDo.ToDoServer
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

            services.AddMvcCore()
                .AddApplicationPart(Assembly.Load(new AssemblyName("CJRaynerRose.ToDo.Server.Api.Main")));

            services.AddScoped<IInteractionContext, InteractionContext>();
            services.AddScoped<CreateItemCommandHandler>();
            services.AddSingleton<IStore<Item>, ItemInMemStore>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ToDoServer", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDoServer v1"));
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
