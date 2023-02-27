using Plugin.LocalNotification;

namespace MauiLocalNotification;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

    protected override async void OnResume()
    {
        var deliveredNotificationList = await LocalNotificationCenter.Current.GetDeliveredNotificationList();
        var backgroundNotification = deliveredNotificationList.ToList().Find(x => x.NotificationId == 901);
        backgroundNotification?.Cancel();
    }

    protected override void OnSleep()
    {
        var request = new NotificationRequest
        {
            Android =
            {
                Ongoing = true,
            },
            CategoryType = NotificationCategoryType.Service,
            NotificationId = 901,
            Silent = true,
            Title = "L'application est en cours d'éxécution en arrière-plan"
        };

        LocalNotificationCenter.Current.Show(request);
    }
}
