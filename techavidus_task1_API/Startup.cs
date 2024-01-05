using techavidus_task1_API.Repositories;
using techavidus_task1_API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;



namespace techavidus_task1_API
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
            // Add controllers and enable CORS if needed
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            // Configure DbContext for Entity Framework
            IServiceCollection serviceCollection = services.AddDbContext<YourDbContext>(options =>
     options.UseSqlServer(Configuration.GetConnectionString("Server=LAPTOP-4N34TBLJ\\SQLEXPRESS;Database=TechUser;Trusted_Connection=True")));


            // Add repositories and services with their interfaces
            services.AddScoped<IUserRepository, UserRepository>();
            
            services.AddScoped<IUserService, UserService>();


            // Other configurations...
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Configure error handling middleware for production
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            // Enable CORS
            app.UseCors("CorsPolicy");

            // Configure routing and endpoint handling
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
