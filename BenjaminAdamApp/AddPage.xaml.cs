namespace BenjaminAdamApp;

public partial class AddPage : ContentPage
{
    public AddPage()
    {
        InitializeComponent();
        BindingContext = new AddViewModel();
    }
}