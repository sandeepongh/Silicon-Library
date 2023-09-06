using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

using Silicon_Library.ViewModels;

namespace Silicon_Library.Views;

public sealed partial class IntroPage : Page
{
    public IntroViewModel ViewModel
    {
        get;
    }

    public IntroPage()
    {
        ViewModel = App.GetService<IntroViewModel>();
        InitializeComponent();
    }
    private void welcome_Click(object sender, RoutedEventArgs e)
    {
        this.Frame.Navigate(typeof(WelcomePage));
    }

    private void skip_Click(object sender, RoutedEventArgs e)
    {
        this.Frame.Navigate(typeof(DevicesPage));
    }
}
