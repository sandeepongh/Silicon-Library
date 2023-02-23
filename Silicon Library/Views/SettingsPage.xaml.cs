using Microsoft.UI.Xaml.Controls;
using System.Management.Automation;
using System.Reflection;
using Silicon_Library.ViewModels;
using Windows.Media.Core;
using System.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silicon_Library.Views;

// TODO: Set the URL for your privacy policy by updating SettingsPage_PrivacyTermsLink.NavigateUri in Resources.resw.
public sealed partial class SettingsPage : Page
{
    public SettingsViewModel ViewModel
    {
        get;
    }

    public SettingsPage()
    {
        ViewModel = App.GetService<SettingsViewModel>();
        InitializeComponent();
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

    private void btnAddDevices_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {

    }
}
