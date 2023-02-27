using Microsoft.Extensions.Logging;
using Plugin.LocalNotification;

namespace MauiLocalNotification;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseLocalNotification(config =>
			{
				config.AddCategory(new NotificationCategory(NotificationCategoryType.Status)
				{
					ActionList = new HashSet<NotificationAction>(new List<NotificationAction>()
					{
						new NotificationAction(100)
						{
							Title = "Changer l'arrière-plan",
							Android =
							{
								LaunchAppWhenTapped = true,
							}
						}
					})
				}).AddCategory(new NotificationCategory(NotificationCategoryType.Service)
				{
					ActionList = new HashSet<NotificationAction>(new List<NotificationAction>()
					{
						new NotificationAction(900)
						{
							Title = "Désactiver"
						}
					})
				});

            })
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
