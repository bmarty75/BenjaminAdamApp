using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace BenjaminAdamApp;

public class AddViewModel : INotifyPropertyChanged
{
    private string _title = string.Empty;
    public string Title
    {
        get => _title;
        set { _title = value; OnPropertyChanged(); }
    }

    private string _description = string.Empty;
    public string Description
    {
        get => _description;
        set { _description = value; OnPropertyChanged(); }
    }

    private string _imageUrl = string.Empty;
    public string ImageUrl
    {
        get => _imageUrl;
        set { _imageUrl = value; OnPropertyChanged(); }
    }

    public ICommand AddBeerCommand { get; }

    public AddViewModel()
    {
        AddBeerCommand = new Command(OnAddBeer);
    }

    private async void OnAddBeer()
    {
        // Validation simple
        if (string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(Description))
        {
            await Application.Current!.MainPage!.DisplayAlert("Erreur", "Titre et description sont obligatoires", "OK");
            return;
        }

        // Créer l'objet Beer
        var newBeer = new Beer
        {
            Title = Title,
            Description = Description,
            // Image par défaut si vide (pour pas que ça plante visuellement)
            ImageUrl = string.IsNullOrWhiteSpace(ImageUrl) ? "coffee_cup.png" : ImageUrl
        };

        // L'ajouter dans notre store local
        BeerStore.MyBeers.Add(newBeer);

        // Message de succès et retour onglet Liste
        await Application.Current!.MainPage!.DisplayAlert("Succès", $"{Title} ajouté à la carte !", "OK");
        
        // Vider le formulaire pour le prochain ajout
        Title = string.Empty;
        Description = string.Empty;
        ImageUrl = string.Empty;

        // Naviguer vers l'onglet des bières (index 1)
        await Shell.Current.GoToAsync("//ListPage");
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}