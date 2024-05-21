using System.Net;
using wcajisacaT6.Objetos;

namespace wcajisacaT6.Vistas;

public partial class VActEliminar : ContentPage
{
    public VActEliminar(Estudiante datos)
	{
		InitializeComponent();
		txtCodigo.Text =datos.codigo.ToString();
		txtNombre.Text = datos.nombre;
		txtApellido.Text = datos.apellido;
		txtEdad.Text = datos.edad.ToString();
	}

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("id", txtCodigo.Text);
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);
            cliente.UploadValues("http://192.168.1.20:8090/pisipService/api/estudiante/update", "POST", parametros);
            Navigation.PushAsync(new CargaDatos());
        }
        catch (Exception ex)
        {
            DisplayAlert("Alerta", ex.Message, "Cerrar");
        }
    }

    private void btnActualizar_Clicked_1(object sender, EventArgs e)
    {

    }

    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        string codigo = txtCodigo.Text;

        string url = $"http://192.168.1.20:8090/pisipService/api/estudiante/delete?codigo={codigo}";

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.DeleteAsync(url);

            if (response.IsSuccessStatusCode)
            {
                await Navigation.PushAsync(new CargaDatos());
            }
            else
            {
                await DisplayAlert("Alerta", "No se pudo eliminar", "Cerrar");
            }
        }
    }
}