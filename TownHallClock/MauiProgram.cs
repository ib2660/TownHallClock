using Microsoft.Extensions.Logging;
using Microsoft.FluentUI.AspNetCore.Components;
using TownHallClock.Services;
using TownHallClock.Shared.Model;
using TownHallClock.Shared.Services;

namespace TownHallClock
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            // Add device-specific services used by the TownHallClock.Shared project
            builder.Services.AddSingleton<IFormFactor, FormFactor>();
            builder.Services.AddSingleton<IWatch, WatchClass>();
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddFluentUIComponents();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
