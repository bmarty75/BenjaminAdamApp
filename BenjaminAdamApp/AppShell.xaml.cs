namespace BenjaminAdamApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("beerdetail", typeof(BeerDetailPage));
	}
}
