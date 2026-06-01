using CalorieTrackerData;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CalorieTrackerApp;

public partial class ListaIngredientesPage : ContentPage
{
    public ListaIngredientesPage()
    {
        InitializeComponent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        CargarAlimentosDesdeBaseDatos();
    }
    private void btnActualizar(object sender, EventArgs e)
    {
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
    private async void btnEliminar(object sender, EventArgs e)
    {
        var boton = sender as Button;

        if (boton?.CommandParameter is int idIngrediente)
        {
            bool confirmacion = await DisplayAlertAsync("Eliminar Alimento", "Desea eliminar este alimento?", "Si", "No");
            if (confirmacion)
            {
                string dbPath = Path.Combine(FileSystem.AppDataDirectory, "calorias.db");
                using (var context = new AppDbContext(dbPath))
                {
                    var ingredienteEliminar = context.Ingredientes.Find(idIngrediente);

                    if (ingredienteEliminar != null)
                    {
                        context.Ingredientes.Remove(ingredienteEliminar);
                        context.SaveChanges();

                        CargarAlimentosDesdeBaseDatos();

                    }
                }


            }
        }
    }
}