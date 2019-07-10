//using MatBlazor.Demo.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

using MatBlazor;

//using Blazored.LocalStorage;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using Bamboo.AbpClient;
using BlazorBoilerplate.Shared.Services.Contracts;
using BlazorBoilerplate.Shared.Services.Implementations;
using BlazorBoilerplate.Shared.States;

namespace AbpClient.App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorizationCore();
            services.AddScoped<IdentityAuthenticationStateProvider>();
            services.AddScoped<IdentityAuthenticationStateProvider>();
            services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<IdentityAuthenticationStateProvider>());
            services.AddScoped<IAuthorizeApi, AuthorizeApi>();


            //services.AddBlazoredLocalStorage();
            services.AddLoadingBar();

            services.AddMatToaster(config =>
            {
                config.Position = MatToastPosition.BottomRight;
                config.PreventDuplicates = true;
                config.NewestOnTop = true;
                config.ShowCloseButton = true;
                config.MaximumOpacity = 95;
                config.VisibleStateDuration = 3000;
            });
            services.AddSingleton<IAbpClient, AbpClientCore>();
            services.AddSingleton<AbpCoreService>();

            //services.AddSingleton<AppModel>();
            //services.AddScoped<UserAppModel>();
            //services.AddMatToaster(config =>
            //{
            //    //example MatToaster customizations
            //    config.PreventDuplicates = false;
            //    config.NewestOnTop = true;
            //    config.ShowCloseButton = true;
            //});
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.UseLoadingBar();

            app.AddComponent<App>("app");
        }
    }
}
