using Plugin.LocalNotification;

namespace MauiLocalNotification;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        LocalNotificationCenter.Current.NotificationActionTapped += Current_NotificationActionTapped;
	}

    private void Current_NotificationActionTapped(Plugin.LocalNotification.EventArgs.NotificationActionEventArgs e)
    {
		switch (e.ActionId)
		{
			case 100:
				LocalNotificationCenter.Current.Cancel(e.Request.NotificationId);
				BackgroundColor = Color.FromArgb(e.Request.ReturningData);
				break;
            case 900:
                LocalNotificationCenter.Current.Cancel(e.Request.NotificationId);
				Application.Current.Quit();
                break;
            default:
				break;
		}
	}

    private void OnSimpleLocalNotificationClicked(object sender, EventArgs e)
	{
		var random = new Random();

		var notificationId = random.Next(101, 200);
		var returningData = $"{random.Next(0x1000000):X6}";

		var request = new NotificationRequest
		{
			CategoryType = NotificationCategoryType.Status,
			NotificationId = notificationId,
			ReturningData = returningData,
            Subtitle = $"Numéro {notificationId}",
			Title = "Notification locale simple"
		};

		LocalNotificationCenter.Current.Show(request);
	}

    private void OnScheduledLocalNotificationClicked(object sender, EventArgs e)
    {
        var random = new Random();

        var notificationId = random.Next(201, 300);

        var request = new NotificationRequest
        {
            CategoryType = NotificationCategoryType.Alarm,
            NotificationId = notificationId,
			Schedule =
			{
				NotifyTime = DateTime.Now.AddSeconds(5),
				RepeatType = NotificationRepeat.TimeInterval,
				NotifyRepeatInterval = TimeSpan.FromSeconds(5)
			},
            Subtitle = $"Numéro {notificationId}",
            Title = "Notification locale programmée"
        };

        LocalNotificationCenter.Current.Show(request);
    }
}

