using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace BenjaminAdamApp;

public class ExtraViewModel : INotifyPropertyChanged
{
    private static readonly List<Beer> _mockBeers = new()
    {
        new Beer { Title = "Founders Centennial IPA", Description = "$16.79", ImageUrl = "https://www.totalwine.com/media/sys_master/twmmedia/h9d/h94/11167126519838.png" },
        new Beer { Title = "Lagunitas IPA", Description = "$8.99", ImageUrl = "https://www.totalwine.com/media/sys_master/twmmedia/h2c/h78/8804310777886.png" },
        new Beer { Title = "Duvel Belgian Ale", Description = "$12.49", ImageUrl = "https://www.totalwine.com/media/sys_master/twmmedia/h0c/h86/8810864082974.png" },
        new Beer { Title = "Chimay Grande Reserve Blue", Description = "$21.49", ImageUrl = "https://www.totalwine.com/media/sys_master/twmmedia/h8a/h92/8798154031134.png" },
        new Beer { Title = "Stone Arrogant Bastard Ale", Description = "$11.49", ImageUrl = "https://www.totalwine.com/media/sys_master/twmmedia/h7a/h9c/11770097860638.png" },
        new Beer { Title = "Delirium Tremens", Description = "$18.99", ImageUrl = "https://www.totalwine.com/media/sys_master/twmmedia/h05/ha0/8804687970334.png" },
        new Beer { Title = "Dogfish Head 60-Minute IPA", Description = "$19.99", ImageUrl = "https://www.totalwine.com/media/sys_master/twmmedia/h5f/h00/10124016648222.png" },
        new Beer { Title = "Kona Big Wave Golden Ale", Description = "$7.99", ImageUrl = "https://www.totalwine.com/media/sys_master/twmmedia/hb9/h8e/8797338894366.png" },
    };

    private readonly Random _random = new();

    // --- Fonctionnalité 1 : Suggestion aléatoire ---

    private Beer? _suggestedBeer;
    public Beer? SuggestedBeer
    {
        get => _suggestedBeer;
        set { _suggestedBeer = value; OnPropertyChanged(); OnPropertyChanged(nameof(HasSuggestion)); }
    }

    public bool HasSuggestion => _suggestedBeer != null;

    public ICommand SuggestBeerCommand { get; }

    // --- Fonctionnalité 2 : Compteur de bières goûtées ---

    private int _tastedCount = 0;
    public int TastedCount
    {
        get => _tastedCount;
        set { _tastedCount = value; OnPropertyChanged(); OnPropertyChanged(nameof(TastedLabel)); }
    }

    public string TastedLabel => _tastedCount switch
    {
        0 => "Aucune bière goûtée pour l'instant",
        1 => "1 bière goûtée",
        _ => $"{_tastedCount} bières goûtées"
    };

    public ICommand IncrementCommand { get; }
    public ICommand DecrementCommand { get; }
    public ICommand ResetCommand { get; }

    public ExtraViewModel()
    {
        SuggestBeerCommand = new Command(SuggestRandomBeer);
        IncrementCommand = new Command(() => TastedCount++);
        DecrementCommand = new Command(() => { if (TastedCount > 0) TastedCount--; });
        ResetCommand = new Command(() => TastedCount = 0);
    }

    private void SuggestRandomBeer()
    {
        var allBeers = _mockBeers.Concat(BeerStore.MyBeers).ToList();
        SuggestedBeer = allBeers[_random.Next(allBeers.Count)];
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
