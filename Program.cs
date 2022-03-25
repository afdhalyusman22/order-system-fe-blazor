using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using order_system_fe_blazor;
using order_system_fe_blazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
var STRAPI_API_URL = builder.Configuration.GetValue<string>("STRAPI_API_URL");

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<CustomStateProvider>();
builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomStateProvider>());
builder.Services.AddHttpClient<IAuthService, AuthService>(x => x.BaseAddress = new Uri(STRAPI_API_URL));
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddHttpClient<ICustomerServices, CustomerServices>(x => x.BaseAddress = new Uri(STRAPI_API_URL));
builder.Services.AddHttpClient<IOrderServices, OrderServices>(x => x.BaseAddress = new Uri(STRAPI_API_URL));
builder.Services.AddHttpClient<ITravelPackageServices, TravelPackageServices>(x => x.BaseAddress = new Uri(STRAPI_API_URL));
builder.Services.AddHttpClient<IStatusServices, StatusServices>(x => x.BaseAddress = new Uri(STRAPI_API_URL));

await builder.Build().RunAsync();
