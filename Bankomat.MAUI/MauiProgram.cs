using Bankomat.MAUI.Services;
using Bankomat.MAUI.ViewModels;
using Bankomat.MAUI.Views;
using Microsoft.Extensions.Logging;

namespace Bankomat.MAUI;

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
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        // MainView
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<MainView>(s => new MainView()
        {
            BindingContext = s.GetRequiredService<MainViewModel>(),
        });
        // AdminPanelView
        builder.Services.AddSingleton<AdminPanelViewModel>();
        builder.Services.AddSingleton<AdminPanelView>(s => new AdminPanelView()
        {
            BindingContext = s.GetRequiredService<AdminPanelViewModel>(),
        });

        builder.Services.AddSingleton<AuthService>();

        return builder.Build();
    }
}