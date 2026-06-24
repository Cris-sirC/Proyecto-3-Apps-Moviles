using Microsoft.Extensions.Logging;
using RegistroGastos.Data;
using RegistroGastos.ViewModels;
using RegistroGastos.Views;

namespace RegistroGastos;

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

        // Inyección de Dependencias
        builder.Services.AddSingleton<ITransaccionRepository, TransaccionRepository>();
        
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<NuevaTransaccionViewModel>();
        
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<NuevaTransaccionPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}