using Newtonsoft.Json;
using System.Collections.ObjectModel;
using wcajisacaT6.Objetos;

namespace wcajisacaT6.Vistas;

public partial class CargaDatos : ContentPage
{
	private const string Url = "http://192.168.1.20:8090/pisipService/api/estudiante/get-all";
	private readonly HttpClient _httpClient = new HttpClient();
	private ObservableCollection<Estudiante> estudiantes;
	public CargaDatos()
	{
		InitializeComponent();
		Obtener();
	}
	public async void Obtener()
	{
        var content = await _httpClient.GetStringAsync(Url);
        List<Estudiante> mostrarEst = JsonConvert.DeserializeObject<List<Estudiante>>(content);

        // Definir las columnas
        gridEstudiantes.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(375, GridUnitType.Absolute) });
        gridEstudiantes.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(200, GridUnitType.Absolute) });
        gridEstudiantes.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(200, GridUnitType.Absolute) });
        gridEstudiantes.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(200, GridUnitType.Absolute) });

        // Agregar los elementos a la cuadrícula
        int rowIndex = 0;
        foreach (var estudiante in mostrarEst)
        {
            gridEstudiantes.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });

            var labelCodigo = new Label { Text = estudiante.codigo };
            gridEstudiantes.Children.Add(labelCodigo);
            Grid.SetRow(labelCodigo, rowIndex);
            Grid.SetColumn(labelCodigo, 0);

            var labelNombre = new Label { Text = estudiante.nombre };
            gridEstudiantes.Children.Add(labelNombre);
            Grid.SetRow(labelNombre, rowIndex);
            Grid.SetColumn(labelNombre, 1);

            var labelApellido = new Label { Text = estudiante.apellido };
            gridEstudiantes.Children.Add(labelApellido);
            Grid.SetRow(labelApellido, rowIndex);
            Grid.SetColumn(labelApellido, 2);

            var labelEdad = new Label { Text = estudiante.edad };
            gridEstudiantes.Children.Add(labelEdad);
            Grid.SetRow(labelEdad, rowIndex);
            Grid.SetColumn(labelEdad, 3);

            rowIndex++;
        }
    }
}