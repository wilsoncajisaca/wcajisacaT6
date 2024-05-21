using System.Net;

namespace wcajisacaT6.Vistas;

public partial class VAgregar : ContentPage
{
	public VAgregar()
	{
		InitializeComponent();
	}

    private void btnGuardar_Clicked(object sender, EventArgs e)
    {
		try 
		{
			WebClient cliente = new WebClient();
			var parametros = new System.Collections.Specialized.NameValueCollection();
			parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);
			cliente.UploadValues("http://192.168.1.20:8090/pisipService/api/estudiante/create","POST", parametros);
			Navigation.PushAsync(new CargaDatos());
        } 
		catch (Exception ex)
		{
			DisplayAlert("Alerta", ex.Message, "Cerrar");
		}
    }
}