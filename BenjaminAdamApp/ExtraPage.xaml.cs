namespace BenjaminAdamApp;

public partial class ExtraPage : ContentPage
{
    public ExtraPage()
    {
        InitializeComponent();
        BindingContext = new ExtraViewModel();
    }
}
