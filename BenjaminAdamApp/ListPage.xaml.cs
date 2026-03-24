namespace BenjaminAdamApp;

public partial class ListPage : ContentPage
{
    private CoffeeService _service = new CoffeeService();

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

        var cafes = await _service.GetHotCoffeesAsync();
        
        CoffeeCollection.ItemsSource = cafes;
        
        CoffeeCollection.IsVisible = true;
        LoadingIndicator.IsVisible = false;
        LoadingIndicator.IsRunning = false;
    }
}