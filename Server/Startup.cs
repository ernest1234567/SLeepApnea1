using System.Linq;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Radzen;
using SLeepApnea.Server.Data;
using SLeepApnea.Server.Models;
using System.IdentityModel.Tokens.Jwt;
using IdentityServer4.Services;
using System;

namespace SLeepApnea.Server
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			var connectionString = "server=192.168.71.153;password=1234;user=root;database=sleepapnea;port=3307";

			// Replace with your server version and type.
			// Use 'MariaDbServerVersion' for MariaDB.
			// Alternatively, use 'ServerVersion.AutoDetect(connectionString)'.
			// For common usages, see pull request #1233.
			var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));

			// Replace 'YourDbContext' with the name of your own DbContext derived class.
			services.AddDbContext<ApplicationDbContext>(
				dbContextOptions => dbContextOptions
					.UseMySql(connectionString, serverVersion)
					// The following three options help with debugging, but should
					// be changed or removed for production.

					.EnableSensitiveDataLogging()
					.EnableDetailedErrors()
			);

			services.AddDatabaseDeveloperPageExceptionFilter();

			services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
				.AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>();
			services.AddIdentityServer()
			   .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options => {
				   options.IdentityResources["openid"].UserClaims.Add("name");
				   options.ApiResources.Single().UserClaims.Add("name");
				   options.IdentityResources["openid"].UserClaims.Add("role");
				   options.ApiResources.Single().UserClaims.Add("role");
			   });

			services.AddTransient<IProfileService, ProfileService>();

			JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("role");


			services.AddScoped<DialogService>();
			services.AddScoped<NotificationService>();
			services.AddScoped<TooltipService>();
			services.AddScoped<ContextMenuService>();
			services.AddAuthentication()

				.AddIdentityServerJwt();
			services.AddControllersWithViews().
				AddNewtonsoftJson(op => op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
			services.AddRazorPages();
			
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseMigrationsEndPoint();
				app.UseWebAssemblyDebugging();

			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseBlazorFrameworkFiles();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseIdentityServer();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();
				endpoints.MapControllers();
				endpoints.MapFallbackToFile("index.html");
			});
		}
	}
}
