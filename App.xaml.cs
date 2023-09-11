using XSqlManager.Classes.Services;

namespace XSqlManager;

public partial class App : Application, IDisposable
{
    private readonly NotifierService _notifierService;
    public App(NotifierService notifierService, MainPage mainPage)
	{
		InitializeComponent();

		MainPage = mainPage;
        _notifierService = notifierService;
    }
    protected override void OnSleep()
    {
        _notifierService.OnPlatformSleeped();
    }

    protected override void OnResume()
    {
        _notifierService.OnPlatformResumed();
    }
    public void Dispose()
    {
        _notifierService.OnPlatformDisposed();
    }
}
