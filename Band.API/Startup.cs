using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using BandModel = Band.API.Models;
using Band.API.Models.DataManager;
using Band.API.Models.Repository;

namespace Band.API
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
            services.AddDbContext<BandModel.BandContext>(opts =>
      opts.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));
            services.AddScoped(typeof(IDataRepository<BandModel.Band, int>), typeof
                (BandManager));
            services.AddCors(opts => opts.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
            }));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseHsts();
                }
            DBSeeder.Seed(app);
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseMvc();
            }
        }


    }
