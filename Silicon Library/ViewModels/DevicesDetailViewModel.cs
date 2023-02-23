using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

using Silicon_Library.Contracts.ViewModels;
using Silicon_Library.Core.Contracts.Services;
using Silicon_Library.Core.Helpers;
using Silicon_Library.Core.Models;
using Silicon_Library.Core.Services;

namespace Silicon_Library.ViewModels;

public class DevicesDetailViewModel : ObservableRecipient, INavigationAware
{
    
    public ObservableCollection<ProgressItem> ProgressesCollection
    {
        get;set;
    }

    private DetailViewModel? _item;

    public string CLIPath = string.Empty;

    public DetailViewModel? Item
    {
        get => _item;
        set => SetProperty(ref _item, value);
    }

    public DevicesDetailViewModel()
    {
        this.ProgressesCollection = new();

    }

    public async void OnNavigatedTo(object parameter)
    {
        //if (parameter is long orderID)
        //{
        //    var data = await _sampleDataService.GetContentGridDataAsync();
        //    Item = data.First(i => i.OrderID == orderID);
        //}
        if (parameter is DeviceDetails _deviceDetails) {
            CLIPath = _deviceDetails.CLIPath;
            Item = new DetailViewModel()
            {
                DeviceDetailsModel = _deviceDetails,
                ProcessingModel = this.ProgressesCollection
            };
            
        }
         
    }

    public void OnNavigatedFrom()
    {
    }
}

public class DetailViewModel
{
    public DeviceDetails? DeviceDetailsModel
    {
        get; set;
    }
    public ObservableCollection<ProgressItem> ProcessingModel
    {
        get; set;
    }
}

