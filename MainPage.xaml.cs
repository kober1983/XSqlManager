using XSqlManager.Classes.Services;

namespace XSqlManager;

public partial class MainPage : ContentPage
{
    private NotifierService _notifierService;
    public MainPage(NotifierService notifierService)
	{
		InitializeComponent();
        _notifierService = notifierService;
    }
    protected override bool OnBackButtonPressed()
    {
        var isGoBack = _notifierService.OnPlatformGoBackClicked();
        return isGoBack;
    }
}
