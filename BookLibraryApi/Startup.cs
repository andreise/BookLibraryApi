using BookLibraryApi.Models.Contexts;
using BookLibraryApi.Repositories.EntityLinkRepositories;
using BookLibraryApi.Repositories.EntityRepositories;
using BookLibraryApi.Repositories.SpecificRepositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookLibraryApi
{
    internal sealed class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            this.ConfigureDbContext(services);
            this.ConfigureRepositories(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            BookLibraryContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            context.Database.Migrate();
        }

        private void ConfigureDbContext(IServiceCollection services)
        {
            var connectionString = this.Configuration.GetConnectionString("BookLibraryContext");
            services.AddDbContext<BookLibraryContext>(
                options => options.UseSqlServer(
                    connectionString,
                    optionsBuilder => optionsBuilder.MigrationsAssembly("BookLibraryApi")),
                ServiceLifetime.Singleton);
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

            // Specific Repositories

            services.AddSingleton<SearchRepository>();
        }
    }
}
