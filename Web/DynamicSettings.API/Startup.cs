using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamicSettings.API.Model;
using DynamicSettings.CodeFirst.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DynamicSettings.API
{
	public class Startup
	{
		//public Startup(IConfiguration configuration)
		public Startup(IHostingEnvironment env,IConfiguration configuration)
		{
			//Configuration = configuration;

			//多环境配置
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true) //增加环境配置文件，新建项目默认有
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			//string conn = "server=(localdb)\\MSSQLSERVER;database=Ef.Core;Trusted_connection=true;";
			//string conn = "server=.;database=Ef.Core;Trusted_connection=true;";

			#region 

			//services.AddDbContext<MyDbContext>(options =>
			//	options.UseSqlServer(connection, b => b.MigrationsAssembly("NetCoreDemo")));

			//var connectiongString = Configuration["AppSettings:DefaultConnectionStr"];

			services.AddDbContext<SettingsManagementDbContext>(
			//services.AddDbContextPool<SettingsManagementDbContext>(
				options => options.UseSqlServer(Configuration.GetConnectionString("SqlServer")
					, builder => builder.MigrationsAssembly("DynamicSettings.CodeFirst.Context")));

			//services.AddDbContext<AuthenticationSettingsDbContext>();

			//services.AddEntityFrameworkInMemoryDatabase()
			//services.AddEntityFrameworkSqlServer()

			//Microsoft.Extensions.DependencyInjection.OptionsConfigurationServiceCollectionExtensions.Configure<SmtpConfig>(services, Configuration.GetSection("Smtp"));


			//services.AddSingleton<IConfiguration>(Configuration);


			#endregion

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		//public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			var defaultcon = Configuration.GetConnectionString("SqlServer");
			var devcon = Configuration["ConnectionStrings:SqlServer"];

			loggerFactory.AddConsole(Configuration.GetSection("Logging"));







			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}
