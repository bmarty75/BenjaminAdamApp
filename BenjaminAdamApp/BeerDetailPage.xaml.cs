namespace BenjaminAdamApp;

[QueryProperty(nameof(Beer), "Beer")]
public partial class BeerDetailPage : ContentPage
{
    private Beer? _beer;
    public Beer? Beer
    {
        get => _beer;
        set
        {
            _beer = value;
            BindingContext = _beer;
        }
    }

    public BeerDetailPage()
    {
        InitializeComponent();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
