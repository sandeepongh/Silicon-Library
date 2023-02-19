using System.Collections.ObjectModel;
using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Silicon_Library.Contracts.Services;
using Silicon_Library.Contracts.ViewModels;
using Silicon_Library.Core.Contracts.Services;
using Silicon_Library.Core.Helpers;
using Silicon_Library.Core.Models;
using Silicon_Library.Core.Services;

namespace Silicon_Library.ViewModels;

public class DevicesViewModel : ObservableRecipient, INavigationAware
{
    private readonly INavigationService _navigationService;
    private readonly DeviceData deviceData;

    public ICommand ItemClickCommand
    {
        get;
    }

    //public ObservableCollection<SampleOrder> Source { get; } = new ObservableCollection<SampleOrder>();
    public ObservableCollection<DeviceDetails> Source { get; } = new ObservableCollection<DeviceDetails>();
    public DevicesViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        deviceData = new DeviceData();

        ItemClickCommand = new RelayCommand<DeviceDetails>(OnItemClick);
    }

    public async void OnNavigatedTo(object parameter)
    {
        Source.Clear();

        // TODO: Replace with real data.
        DeviceData deviceData = new DeviceData();
        var data = deviceData.GetDeviceData();

        //var data = await _sampleDataService.GetContentGridDataAsync();
        //foreach (var item in data)
        //{
        //    Source.Add(item);
        //}
      
        foreach (var item in data)
        {
            Source.Add(item);
        }

    }

    public void OnNavigatedFrom()
    {
    }

    private void OnItemClick(DeviceDetails? clickedItem)
    {
        if (clickedItem != null)
        {
            _navigationService.SetListDataItemForNextConnectedAnimation(clickedItem);
            _navigationService.NavigateTo(typeof(DevicesDetailViewModel).FullName!, clickedItem);
        }
    }
}
