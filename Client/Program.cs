using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SLeepApnea.Client.Services;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace SLeepApnea.Client
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");

			builder.Services.AddHttpClient("SLeepApnea.ServerAPI",(sp,client) => {
				client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
				client.EnableIntercept(sp); 
			})
				.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

			// Supply HttpClient instances that include access tokens when making requests to the server project
			builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("SLeepApnea.ServerAPI"));

			builder.Services.AddHttpClientInterceptor();
			builder.Services.AddScoped<HttpInterceptorService>();

			builder.Services.AddApiAuthorization()
				.AddAccountClaimsPrincipalFactory<CustomUserFactory>();

			await builder.Build().RunAsync();
		}
	}
}
