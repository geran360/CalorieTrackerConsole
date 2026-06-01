using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CalorieTrackerData;
using System;
using System.Linq;

using (var context = new AppDbContext("calorias.db"))
{
    context.Database.EnsureCreated();

    Console.WriteLine("Registro de alimentos");
    int opMenu = 0;

    do
    {
        Console.WriteLine("\nElija una Opcion");
        Console.WriteLine("1. Ingresar un Alimento");
        Console.WriteLine("2. Ver todos los Alimentos");
        Console.WriteLine("3. Eliminar un Alimento");
        Console.WriteLine("4. Salir");
        string entrada = Console.ReadLine();
        if (!int.TryParse(entrada, out opMenu))
        {
            Console.WriteLine("Opcion no valida");
            continue;
        }

        switch (opMenu)
        {
            case 1:
                bool agregarIngrediente = true;

                while (agregarIngrediente)
                {
                    Console.WriteLine("\nNombre de Alimento: ");
                    string nombreInput = Console.ReadLine();

                    Console.WriteLine($"Cuantas calorias tiene '{nombreInput}'?");
                    string caloriasInput = Console.ReadLine();
                    int caloriasInputInt = int.Parse(caloriasInput);

                    Ingrediente nuevoIngrediente = new Ingrediente(nombreInput, caloriasInputInt);
                    context.Ingredientes.Add(nuevoIngrediente);


                    Console.WriteLine($"{nombreInput} agregado con exito a la base de datos");

                    Console.WriteLine("Deseas agregar otro alimento? s/n");
                    string op = Console.ReadLine().ToLower();

                    if (op != "s")
                    {
                        agregarIngrediente = false;
                    }
                }
                context.SaveChanges();
                Console.WriteLine("Datos guardados");
                break;


            case 2:

                Console.WriteLine("Lista completa de Alimentos");

                var listaIngredientesDb = context.Ingredientes.ToList();

                if (listaIngredientesDb.Count == 0)
                {
                    Console.WriteLine("No existen ingredientes");
                }
                else
                {
                    foreach (var ing in listaIngredientesDb)
                    {
                        Console.WriteLine($"ID: {ing.Id} | Nombre: {ing.Nombre} | Calorias: {ing.Calorias} kcal");
                    }
                    Console.WriteLine("");

                    int totalCalorias = listaIngredientesDb.Sum(i => i.Calorias);

                    Console.WriteLine($"Total de Calorias: {totalCalorias} kcal");
                }
                break;

            case 3:
                
                Console.WriteLine("Que alimento desea eliminar? (ID)");
                string idInput = Console.ReadLine();
                if (int.TryParse(idInput, out int idEliminar))
                {
                    var ingredienteEliminar = context.Ingredientes.Find(idEliminar);

                    if (ingredienteEliminar != null)
                    {
                        context.Ingredientes.Remove(ingredienteEliminar);
                        context.SaveChanges();
                        Console.WriteLine($"{ingredienteEliminar.Nombre} eliminado");
                    }
                    else
                    {
                        Console.WriteLine($"No existe alimento con ID {idEliminar}");
                    }
                }
                else
                {
                    Console.WriteLine("ID no valido");
                }
                break;

            case 4:
                Console.WriteLine("Saliendo...");
                break;

                default: 
                Console.WriteLine("Opcion no valida");
                break;

        }
    }
    while (opMenu != 4);


}

