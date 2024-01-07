using Microsoft.Extensions.Logging;
using ParkoviskoCheckingAPP.Data;
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
			//builder.Services.AddHttpClient<AuthentificationService>();
			builder.Services.AddSingleton<AuthentificationService>();
			builder.Services.AddSingleton<CarService>();

            return builder.Build();
		}
	}
}
