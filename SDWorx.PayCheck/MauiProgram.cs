using Blazorise;
using Blazorise.Bootstrap5;
using Microsoft.Extensions.Logging;
using Radzen;

namespace SDWorx.PayCheck;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Services.AddRadzenComponents();
        builder.Services
            .AddBlazorise( options =>
            {
                options.Immediate = true;
            } )
            .AddBootstrap5Providers();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}