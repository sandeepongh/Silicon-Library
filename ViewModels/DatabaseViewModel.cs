using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;

using Silicon_Library.Contracts.ViewModels;
using Silicon_Library.Core.Contracts.Services;
using Silicon_Library.Core.Models;

namespace Silicon_Library.ViewModels;

public class DatabaseViewModel : ObservableRecipient, INavigationAware
{
    private readonly DatabaseService _sampleDataService;

    public ObservableCollection<SampleOrder> Source { get; } = new ObservableCollection<SampleOrder>();

    public DatabaseViewModel(DatabaseService sampleDataService)
    {
        _sampleDataService = sampleDataService;
    }

    public async void OnNavigatedTo(object parameter)
    {
        Source.Clear();

        // TODO: Replace with real data.
        var data = await _sampleDataService.GetGridDataAsync();

        foreach (var item in data)
        {
            Source.Add(item);
        }
    }

    public void OnNavigatedFrom()
    {
    }
}
