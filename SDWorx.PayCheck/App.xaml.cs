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
        windows.MinimumWidth = 1000;
        windows.MinimumHeight = 800;
        return windows;
    }
}