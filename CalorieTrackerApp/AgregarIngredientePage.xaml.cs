using CalorieTrackerData;

namespace CalorieTrackerApp;

public partial class AgregarIngredientePage : ContentPage
{
	public AgregarIngredientePage()
	{
		InitializeComponent();
	}
    private async void btnEnviarAlimento(object sender, EventArgs e)
    {

        string alimentoIntroducido = entradaAlimento.Text;
        string caloriasIntroducidas = entradaCalorias.Text;
        if (!string.IsNullOrWhiteSpace(alimentoIntroducido) && int.TryParse(caloriasIntroducidas, out int CaloriasAlimento))
        {
            await DisplayAlertAsync("Listo", $"{alimentoIntroducido} agregado con éxito", "OK");
            entradaAlimento.Text = string.Empty;
            entradaCalorias.Text = string.Empty;

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "calorias.db");
            using (var context = new AppDbContext(dbPath))
            {
                context.Database.EnsureCreated();
                context.Ingredientes.Add(new Ingrediente(alimentoIntroducido, CaloriasAlimento));
                context.SaveChanges();
            }
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlertAsync("Error", "Entrada no válida", "OK");
        }
    }
}