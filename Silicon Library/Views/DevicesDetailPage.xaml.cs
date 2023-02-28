using System.Security.Cryptography.Xml;
using System.Text;
using CommunityToolkit.WinUI.UI.Animations;

using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

using Silicon_Library.Contracts.Services;
using Silicon_Library.Core.Helpers;
using Silicon_Library.ViewModels;
using Windows.UI;

namespace Silicon_Library.Views;

public sealed partial class DevicesDetailPage : Page
{
    public DevicesDetailViewModel ViewModel
    {
        get;
    }

    public DevicesDetailPage()
    {
        ViewModel = App.GetService<DevicesDetailViewModel>();
        InitializeComponent();

    }


    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        this.RegisterElementForConnectedAnimation("animationKeyContentGrid", itemHero);
    }

    protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
    {
        base.OnNavigatingFrom(e);
        if (e.NavigationMode == NavigationMode.Back)
        {
            var navigationService = App.GetService<INavigationService>();

            if (ViewModel.Item != null)
            {
                navigationService.SetListDataItemForNextConnectedAnimation(ViewModel.Item);
            }
        }
    }

    private void btnInvoke_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        //var logText = File.ReadAllText("/Assets/CLIs/TerminalLog.json");
        //ViewModel.ProgressesCollection.Add(new ProgressItem() { CurrentItemName = logText });
        string clipath = txtCliPath.Text;
        var result = RunDeviceTest.Invoke(clipath);
        result.ForEach(x =>
        {
            ViewModel.ProgressesCollection.Add(new ProgressItem() { CurrentItemName = x.CurrentItemName });
        });
        

        var scrollableHeight = process_Scroll.ScrollableHeight;
        if (scrollableHeight > 0)
        {
            process_Scroll.ScrollToVerticalOffset(scrollableHeight);
        }
    }

    private void btnClear_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        chkDeviceCondition.IsChecked= false;;
        txtUserId.Text= string.Empty;
        txtUserName.Text = string.Empty;
        txtDeviceId.Text = string.Empty;
        dateReg.SelectedDate = null;
        dateDue.SelectedDate = null;

    }

    public void btnSubmit_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        int flag = 0;

        if (String.IsNullOrEmpty(txtUserId.Text))
            {
                lblStatus.Text = "Enter User ID";
                flag = 1;
            };

        if (String.IsNullOrEmpty(txtUserName.Text))
            {
                lblStatus.Text = "Enter User Name";
                flag = 1;
            };

        if (String.IsNullOrEmpty(txtDeviceId.Text))
        {
            lblStatus.Text = "Enter Device ID";
            flag = 1;
        };

        //if (String.IsNullOrEmpty(txtDevice.Text))
        //{
        //    lblStatus.Text = "Enter Device Name";
        //    flag = 1;
        //};


        if (flag == 0)
        {
            Records records = new Records()
            {
                UserId = txtUserId.Text,
                Username = txtUserName.Text,
                DeviceId = Int32.Parse(txtDeviceId.Text),
                DeviceName = txtDevice.Text,
                DeviceCondition = chkDeviceCondition.IsChecked,
                DateDue = dateDue.SelectedDate.HasValue ? (DateTime)dateDue.SelectedDate.Value.DateTime : null,
                DateReg = dateReg.SelectedDate.HasValue ? (DateTime)dateReg.SelectedDate.Value.DateTime : null

            };

            DbRepository repo = new DbRepository();
            repo.SaveRecord(records);
            lblStatus.Text = "Success!";
        } 




    }
}


