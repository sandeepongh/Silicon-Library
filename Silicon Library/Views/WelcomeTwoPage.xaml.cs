using Microsoft.UI.Xaml.Controls;

using Silicon_Library.ViewModels;
using System.Reflection;

using System.Management.Automation;


namespace Silicon_Library.Views;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
public sealed partial class WelcomeTwoPage : Page
{
    public WelcomeTwoViewModel ViewModel
    {
        get;
    }

    private void btnDrivers_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        string cliPath = "\\Assets\\CLIs\\InstallDrivers.ps1";
        string basePath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        string exe = "Powershell.exe -File '" + basePath + cliPath + "'";
        string path = AppDomain.CurrentDomain.BaseDirectory + cliPath;
        var powerShell = PowerShell.Create();
        var res = powerShell.AddScript(exe).Invoke();

    }

    private void welcomeTwoButton_Click(object sender, RoutedEventArgs e)
    {
        this.Frame.Navigate(typeof(WelcomeThreePage));
    }

    public WelcomeTwoPage()
    {
        ViewModel = App.GetService<WelcomeTwoViewModel>();
        InitializeComponent();
    }
}
