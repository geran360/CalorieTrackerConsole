using CalorieTrackerData;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CalorieTrackerApp;

public partial class SeleccionarIngredientePage : ContentPage
{
    public SeleccionarIngredientePage()
    {
        InitializeComponent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        CargarAlimentosDesdeBaseDatos();
    }
    private void CargarAlimentosDesdeBaseDatos()
    {
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "calorias.db");
        using (var context = new AppDbContext(dbPath))
        {
            List<Ingrediente> listaDb = context.Ingredientes.ToList();

            ColeccionAlimentos.ItemsSource = listaDb;
        }
    }
    
    private async void btnCalcular(object sender, EventArgs e)
    {
        var listaAlimentos = ColeccionAlimentos.ItemsSource as List<Ingrediente>;

        if (listaAlimentos != null)
        {
            var alimentosSeleccionados = listaAlimentos.Where(a => a.IsSelected).ToList();

            if (alimentosSeleccionados.Count == 0)
            {
                await DisplayAlertAsync("Atencion", "Selecciona al menos un alimento", "OK");
                return;
            }

            int totalCalorias = alimentosSeleccionados.Sum(a => a.Calorias);

            string detalle = string.Join(", ", alimentosSeleccionados.Select(a => a.Nombre));

            await DisplayAlertAsync("Consumo total", $"Alimentos: {detalle}\nTotal: {totalCalorias} kcal", "OK");
        }

    }
}