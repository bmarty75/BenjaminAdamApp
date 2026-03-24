namespace BenjaminAdamApp;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		LogoImage.Scale = 0;
		await LogoImage.ScaleTo(1.2, 500, Easing.SpringOut);
		await LogoImage.ScaleTo(1, 250, Easing.Linear);
	}

	private async void OnGifButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new GifPage());
	}
}
