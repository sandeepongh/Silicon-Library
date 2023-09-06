using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Namotion.Reflection;
using Silicon_Library.ViewModels;
using Windows.Storage.Streams;
using Windows.System;
using Windows.UI.Popups;

namespace Silicon_Library.Views;

public sealed partial class WelcomePage : Page
{
    public WelcomeViewModel ViewModel
    {
        get;
    }

    public WelcomePage()
    {
        ViewModel = App.GetService<WelcomeViewModel>();
        InitializeComponent();
    }

    private async void powershellButton_Click(object sender, RoutedEventArgs e)
    {
        // Navigate to developer options in Windows.
        await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings:developers"));

        {
            //Left empty until utility is required
        }
    }

    private void welcomeTwoButton_Click(object sender, RoutedEventArgs e)
    {
        this.Frame.Navigate(typeof(WelcomeTwoPage));
    }
}
