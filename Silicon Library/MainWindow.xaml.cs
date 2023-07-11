using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Silicon_Library.Helpers;

namespace Silicon_Library;

public sealed partial class MainWindow : WindowEx
{
    public MainWindow()
    {
        InitializeComponent();

        AppWindow.SetIcon(Path.Combine(AppContext.BaseDirectory, "Assets/WindowIcon.ico"));
        Content = null;
        Title = "AppDisplayName".GetLocalized();

        this.InitializeComponent();
        var root = this.Content as FrameworkElement;
        if (root != null)
            root.Loaded += async (s, e) => await DisplayDialog();
    }
    private async Task DisplayDialog()
    {
        var dlg = new ContentDialog();
        dlg.XamlRoot = this.Content.XamlRoot;
        dlg.Content = "Hello World";
        await dlg.ShowAsync();
    }
}
