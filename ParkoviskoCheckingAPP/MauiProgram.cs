using Microsoft.Extensions.Logging;
using ParkoviskoCheckingAPP.services;

namespace ParkoviskoCheckingAPP
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

			builder.Services.AddMauiBlazorWebView();

#if DEBUG
			builder.Services.AddBlazorWebViewDeveloperTools();
			builder.Logging.AddDebug();
#endif
			builder.Services.AddSingleton<AuthenticationService>();
			builder.Services.AddSingleton<CarService>();
            builder.Services.AddSingleton<ValidationService>();

            return builder.Build();
		}
	}
}
