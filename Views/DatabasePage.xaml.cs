using Microsoft.UI.Xaml.Controls;

using Silicon_Library.ViewModels;

namespace Silicon_Library.Views;

// TODO: Change the grid as appropriate for your app. Adjust the column definitions on DataGridPage.xaml.
// For more details, see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid.
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
