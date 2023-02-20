using Microsoft.UI.Xaml.Controls;

using Silicon_Library.ViewModels;

namespace Silicon_Library.Views;

public sealed partial class DatabasePage : Page
{
    public DatabaseViewModel ViewModel
    {
        get;
    }

    public DatabasePage()
    {
        ViewModel = App.GetService<DatabaseViewModel>();
        InitializeComponent();
    }
}
