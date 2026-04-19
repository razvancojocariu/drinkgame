using Microsoft.Extensions.Logging;
using drinkgame.Views;
using drinkgame.ViewModels;
using CommunityToolkit.Maui;
using Plugin.Maui.Audio;

namespace drinkgame
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Bangers-Regular.ttf", "Bangers");
                });

            builder.Services.AddSingleton(AudioManager.Current);
            builder.Services.AddTransient<PlayerNamesViewModel>();
            builder.Services.AddTransient<PlayerNamesPage>();
            builder.Services.AddTransient<GameViewModel>();
            builder.Services.AddTransient<GamePage>();
            builder.Services.AddTransient<StatisticsViewModel>();
            builder.Services.AddTransient<StatisticsPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
