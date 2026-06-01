# Calorie Tracker App

Aplicación móvil multiplataforma desarrollada con **.NET MAUI** y **C#** que permite llevar un registro diario de alimentos y sus calorías. El usuario puede agregar, consultar y eliminar ingredientes desde su dispositivo móvil, con persistencia de datos mediante una base de datos local **SQLite**.

---

## Tecnologías utilizadas

- **C#** — Lenguaje principal de desarrollo
- **.NET MAUI** — Framework multiplataforma para Android e iOS
- **SQLite** — Base de datos local embebida en el dispositivo
- **Entity Framework Core 8** — ORM para gestión de base de datos
- **Visual Studio 2022** — Entorno de desarrollo

---

## Estructura del proyecto

```
CalorieTrackerConsole/
├── CalorieTrackerApp/              # Proyecto MAUI (interfaz móvil)
│   ├── MainPage                    # Menú principal
│   ├── AgregarIngredientePage      # Agregar alimentos
│   ├── ListaIngredientesPage       # Ver y eliminar alimentos
│   ├── SeleccionarIngredientePage  # Seleccionar y calcular calorías
│   └── Resources/                  # Imágenes, fuentes e íconos
├── CalorieTrackerConsole/          # Proyecto de consola (prototipo inicial)
└── CalorieTrackerData/             # Librería de clases compartida
    ├── Ingrediente.cs              # Modelo de datos
    └── AppDbContext.cs             # Contexto de base de datos
```

## Funcionalidades

- Agregar alimentos con nombre y calorías
- Ver lista completa de alimentos registrados
- Eliminar alimentos de la base de datos
- Seleccionar múltiples alimentos y calcular el total de calorías consumidas
- Persistencia de datos con SQLite — los datos se conservan al cerrar la app
- Compatibilidad con tema claro y oscuro del dispositivo

---

## Arquitectura

El proyecto sigue una **arquitectura en capas**:
- [ Presentación ]  →  CalorieTrackerApp (MAUI)
- [ Datos ]         →  CalorieTrackerData (Class Library)
- [ Prototipo ]     →  CalorieTrackerConsole (Console App)
- La lógica de base de datos está separada en una **Class Library** independiente (`CalorieTrackerData`), lo que permite reutilizarla tanto en la app móvil como en la aplicación de consola.

---

## Cómo ejecutar el proyecto

### Requisitos previos

- Visual Studio 2022 con workload **.NET MAUI** instalado
- .NET 10 SDK
- Android Emulator o dispositivo físico Android

### Pasos

1. Clona el repositorio:
```bash
git clone https://github.com/geran360/CalorieTrackerConsole.git
```

2. Abre la solución en Visual Studio:
CalorieTrackerConsole.sln
3. Establece `CalorieTrackerApp` como proyecto de inicio

4. Selecciona un emulador Android y presiona ▶️

> **Nota:** La base de datos SQLite se crea automáticamente en el primer inicio de la app dentro del directorio de datos de la aplicación en el dispositivo.

---

## Capturas de pantalla

<img width="296" height="633" alt="gif1" src="https://github.com/user-attachments/assets/9ba38497-ea9b-4691-a2e2-6f0ba194e90a" />
<img width="296" height="633" alt="gif2" src="https://github.com/user-attachments/assets/2526edcb-4ec0-4748-9aab-6a470717cbb0" />
<img width="296" height="633" alt="gif3" src="https://github.com/user-attachments/assets/bfd9e4aa-096b-4b07-8c8a-3fcb1f831117" />




---

## Investigación y pensamiento técnico 

- Fundamentos de **C#**: clases, propiedades, listas, bucles y manejo de errores
- Uso de **Entity Framework Core** con SQLite para persistencia de datos
- Operaciones **CRUD** completas desde una interfaz móvil
- Diseño de interfaces con **XAML** en .NET MAUI
- Navegación entre pantallas con `NavigationPage`
- Arquitectura en capas y separación de responsabilidades
- Control de versiones con **Git y GitHub**

---

## Autor

**Gerardo Martin Mercado** — Estudiante de Ingeniería en Sistemas
[GitHub](https://github.com/geran360)
