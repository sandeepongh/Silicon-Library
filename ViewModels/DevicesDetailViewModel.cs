using CommunityToolkit.Mvvm.ComponentModel;

using Silicon_Library.Contracts.ViewModels;
using Silicon_Library.Core.Contracts.Services;
using Silicon_Library.Core.Models;

namespace Silicon_Library.ViewModels;

public class DevicesDetailViewModel : ObservableRecipient, INavigationAware
{
    private readonly DatabaseService _sampleDataService;
    private SampleOrder? _item;

    public SampleOrder? Item
    {
        get => _item;
        set => SetProperty(ref _item, value);
    }

    public DevicesDetailViewModel(DatabaseService sampleDataService)
    {
        _sampleDataService = sampleDataService;
    }

    public async void OnNavigatedTo(object parameter)
    {
        if (parameter is long orderID)
        {
            var data = await _sampleDataService.GetContentGridDataAsync();
            Item = data.First(i => i.OrderID == orderID);
        }
    }

    public void OnNavigatedFrom()
    {
    }
}
