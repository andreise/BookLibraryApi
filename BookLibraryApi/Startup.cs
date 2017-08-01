using BookLibraryApi.Models.Contexts;
using BookLibraryApi.Repositories.EntityRepositories;
using BookLibraryApi.Repositories.EntityLinkRepositories;
using BookLibraryApi.Repositories.SpecificRepositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BookLibraryApi
{
    sealed class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            this.Configuration = builder.Build();
        }

        private void ConfigureDbContext(IServiceCollection services)
        {
            var connectionString = this.Configuration.GetConnectionString("BookLibraryContext");
            services.AddDbContext<BookLibraryContext>(
                options => options.UseSqlServer(
                    connectionString,
                    optionsBuilder => optionsBuilder.MigrationsAssembly("BookLibraryApi")));
        }

        private void ConfigureRepositories(IServiceCollection services)
        {
            // Entity Repositories

            services.AddSingleton<AuthorsRepository>();
            services.AddSingleton<EditionsRepository>();
            services.AddSingleton<GenresRepository>();
            services.AddSingleton<VolumesRepository>();
            services.AddSingleton<VolumeExemplarsRepository>();
            services.AddSingleton<WorksRepository>();
            services.AddSingleton<WorkKindsRepository>();

            // Entity Link Repositories

            services.AddSingleton<EditionVolumeLinksRepository>();
            services.AddSingleton<VolumeWorkLinksRepository>();
            services.AddSingleton<WorkAuthorLinksRepository>();

            // Specific Reposotories

            services.AddSingleton<SearchRepository>();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            this.ConfigureDbContext(services);

            this.ConfigureRepositories(services);

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, BookLibraryContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //context.Database.EnsureCreated();
            context.Database.Migrate(); // is mutually exclusive with EnsureCreated

            app.UseMvc();
        }
    }
}
