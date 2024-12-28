namespace SDWorx.PayCheck;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var windows  = new Window(new MainPage()) { Title = "SDWorx.PayCheck" };
        windows.MinimumWidth = 1200;
        windows.MinimumHeight = 700;
        windows.Height = 700;
        windows.Width = 1200;
        windows.MaximumHeight = 700;
        windows.MaximumWidth = 1200;
        return windows;
    }
}