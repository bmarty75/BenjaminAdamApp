namespace BenjaminAdamApp;

public partial class App : Application
{
    public App()
    {
        try
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
        catch (Exception ex)
        {
            MainPage = new ContentPage
            {
                BackgroundColor = Colors.White,
                Content = new ScrollView
                {
                    Content = new Label
                    {
                        Text = "ERREUR DÉMARRAGE:\n\n" + ex.ToString(),
                        TextColor = Colors.Red,
                        Padding = new Thickness(20),
                        FontSize = 12
                    }
                }
            };
        }
    }
}
