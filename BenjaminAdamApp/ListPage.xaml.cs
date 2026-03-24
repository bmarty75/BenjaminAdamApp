namespace BenjaminAdamApp;

public partial class ListPage : ContentPage
{
    private BeerService _service = new BeerService();

    public ListPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
    
        // lancement du chargement
        LoadingIndicator.IsRunning = true;
        LoadingIndicator.IsVisible = true;

        var bieres = await _service.GetBeersAsync();
        
        BeerCollection.ItemsSource = bieres;
        
        BeerCollection.IsVisible = true;
        LoadingIndicator.IsVisible = false;
        LoadingIndicator.IsRunning = false;
    }
}