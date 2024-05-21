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
		estudiantes = new ObservableCollection<Estudiante>(mostrarEst);
		listaEstudiantes.ItemsSource = estudiantes;
    }

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new VAgregar());
    }

    private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		var estudiante = (Estudiante)e.SelectedItem;
		Navigation.PushAsync(new VActEliminar(estudiante));
    }
}