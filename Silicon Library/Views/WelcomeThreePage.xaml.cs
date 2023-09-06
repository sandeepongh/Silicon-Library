using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

using Silicon_Library.ViewModels;

namespace Silicon_Library.Views;

public sealed partial class WelcomeThreePage : Page
{
    public WelcomeThreeViewModel ViewModel
    {
        get;
    }

    private void devicePage_Click(object sender, RoutedEventArgs e)
    {
        this.Frame.Navigate(typeof(DevicesPage));
    }

    public WelcomeThreePage()
    {
        ViewModel = App.GetService<WelcomeThreeViewModel>();
        InitializeComponent();
    }
}
