using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;

using Silicon_Library.Contracts.ViewModels;
using Silicon_Library.Core.Contracts.Services;
using Silicon_Library.Core.Models;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

using Silicon_Library.Contracts.Services;
using Silicon_Library.Core.Helpers;
using Silicon_Library.Core.Services;

namespace Silicon_Library.ViewModels;

public class DatabaseViewModel : ObservableRecipient, INavigationAware
{
    private readonly ISampleDataService _sampleDataService;
    private readonly INavigationService _navigationService;
    private readonly RecordData recordData;

    //public ObservableCollection<SampleOrder> Source { get; } = new ObservableCollection<SampleOrder>();
    public ObservableCollection<Records> Source { get; } = new ObservableCollection<Records>();
    public DatabaseViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        recordData = new RecordData();
    }

    public async void OnNavigatedTo(object parameter)
    {
        Source.Clear();

        // TODO: Replace with real data.
        //var data = await _sampleDataService.GetGridDataAsync();
        RecordData recordData = new RecordData();
        var data = recordData.GetRecordData();

        foreach (var item in data)
        {
            Source.Add(item);
        }
    }

    public void OnNavigatedFrom()
    {
    }
}
