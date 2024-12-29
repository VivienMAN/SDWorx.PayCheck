namespace SDWorx.PayCheck;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var windows  = new Window(new MainPage()) { Title = "PayCheck" };
        windows.MinimumWidth = 1200;
        windows.MinimumHeight = 650;
        windows.Height = 650;
        windows.Width = 1200;
        windows.MaximumHeight = 650;
        windows.MaximumWidth = 1200;
        return windows;
    }
}