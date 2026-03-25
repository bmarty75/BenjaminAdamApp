namespace BenjaminAdamApp;

public partial class ListPage : ContentPage
{
    private readonly ListViewModel _viewModel = new ListViewModel();

    public ListPage()
    {
        InitializeComponent();
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadBeersAsync();
    }
}