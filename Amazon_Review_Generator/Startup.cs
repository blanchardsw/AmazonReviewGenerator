using Amazon_Review_Generator.Contracts;
using Amazon_Review_Generator.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Amazon_Review_Generator
{
    public class Startup
    {
        public IMarkovHelper _markovHelper;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<IMarkovHelper, MarkovHelper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMarkovHelper markovHelper)
        {
            this._markovHelper = markovHelper;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            if (app.Properties != null)
            {
                app.UseHttpsRedirection();

                app.UseDefaultFiles();
                app.UseStaticFiles();

                app.UseMvc();
            }

            this._markovHelper.Ingest();
            this._markovHelper.Chain = this._markovHelper.Train();
        }
    }
}
