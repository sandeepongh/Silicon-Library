using Microsoft.UI.Xaml.Controls;

using Silicon_Library.ViewModels;

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
}
