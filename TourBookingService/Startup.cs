namespace TourBooking.Api
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using TourBooking.Core.Domain;
    using TourBooking.Core.Models;
    using TourBooking.Core.Services;
    using TourBooking.Core.Services.Interfaces;

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
            services.AddControllers()
             .AddJsonOptions(options =>
             {
                 options.JsonSerializerOptions.PropertyNamingPolicy = null;
                 options.JsonSerializerOptions.Converters.Add(new JsonObjectIdConverterBySystemTextJson());
             });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.Configure<MongoSettings>(options =>
            {
                options.ConnectionString
                    = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.Database
                    = Configuration.GetSection("MongoConnection:Database").Value;
            });

            //Services
            services.AddTransient<IHomeService, HomeService>();
            services.AddTransient<ISlotService, SlotService>();

            //Repository
            services.AddSingleton<IRepository<Home>, HomeRepository>();
            services.AddSingleton<IRepository<SlotHome>, SlotRepository>();

            //context 
            services.AddTransient<Context<Home>>();
            services.AddTransient<Context<SlotHome>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
