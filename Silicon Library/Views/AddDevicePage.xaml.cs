using Microsoft.UI.Xaml.Controls;

using Silicon_Library.ViewModels;

namespace Silicon_Library.Views;

public sealed partial class AddDevicePage : Page
{
    public AddDeviceViewModel ViewModel
    {
        get;
    }

    public AddDevicePage()
    {
        ViewModel = App.GetService<AddDeviceViewModel>();
        InitializeComponent();
    }
}
