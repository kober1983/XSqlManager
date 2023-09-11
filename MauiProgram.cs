using Microsoft.Extensions.Logging;
using XSqlManager.Classes.Services;

namespace XSqlManager;

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
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<NotifierService>();
        builder.Services.AddSingleton<ConnectionState>();
		//builder.Services.AddSingleton<WeatherForecastService>();

		
		return builder.Build();
	}
}
