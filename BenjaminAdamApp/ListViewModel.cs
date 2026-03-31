using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace BenjaminAdamApp;

public class ListViewModel : INotifyPropertyChanged
{
    private readonly BeerService _service = new BeerService();

    public ObservableCollection<Beer> Beers { get; } = new ObservableCollection<Beer>();

    private bool _isLoading = true;
    public bool IsLoading
    {
        get => _isLoading;
        set { _isLoading = value; OnPropertyChanged(); }
    }

    private bool _isListVisible = false;
    public bool IsListVisible
    {
        get => _isListVisible;
        set { _isListVisible = value; OnPropertyChanged(); }
    }

    public ICommand LoadBeersCommand { get; }
    public ICommand SelectBeerCommand { get; }

    public ListViewModel()
    {
        LoadBeersCommand = new Command(async () => await LoadBeersAsync());
        SelectBeerCommand = new Command<Beer>(async (beer) => await OnBeerSelected(beer));
    }

    public async Task LoadBeersAsync()
    {
        IsLoading = true;
        IsListVisible = false;

        var list = await _service.GetBeersAsync();
        Beers.Clear();
        
        // D'abord, on charge les bières ajoutées en local par l'utilisateur
        foreach (var myBeer in BeerStore.MyBeers)
        {
            Beers.Add(myBeer);
        }

        // Ensuite on charge les bières de l'API
        foreach (var beer in list)
        {
            Beers.Add(beer);
        }

        IsLoading = false;
        IsListVisible = true;
    }

    private async Task OnBeerSelected(Beer beer)
    {
        if (beer == null) return;
        await Shell.Current.GoToAsync("beerdetail", new Dictionary<string, object>
        {
            { "Beer", beer }
        });
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
