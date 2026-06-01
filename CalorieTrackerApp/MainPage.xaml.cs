
namespace CalorieTrackerApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnAgregar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgregarIngredientePage());
        }

        private async void btnVer(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaIngredientesPage());
        }
        private async void btnSeleccionar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SeleccionarIngredientePage());
        }
    }
}
