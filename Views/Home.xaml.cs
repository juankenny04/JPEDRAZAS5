using Semana5.Modelos;

namespace Semana5.Views;

public partial class Home : ContentPage
{
	public Home()
	{
		InitializeComponent();
	}
    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        status.Text = string.Empty;
        App.PersonaRepository.AddNewPerson(txtNombre.Text);
        status.Text = App.PersonaRepository.StatusMessage;
    }

    private void btnListar_Clicked(object sender, EventArgs e)
    {
        status.Text = string.Empty;
        List<Persona> personas = App.PersonaRepository.GetAll();
        ListaPersona.ItemsSource = personas;
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        status.Text = string.Empty;
        if (int.TryParse(txtID.Text, out int id))
        {
            App.PersonaRepository.DeletePerson(id);
            status.Text = App.PersonaRepository.StatusMessage;
            btnListar_Clicked(sender, e);  
        }
        else
        {
            status.Text = "ID no válido.";
        }
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        status.Text = string.Empty;
        if (int.TryParse(txtID.Text, out int id))
        {
            App.PersonaRepository.UpdatePerson(id, txtNombre.Text);
            status.Text = App.PersonaRepository.StatusMessage;
            btnListar_Clicked(sender, e);  
        }
        else
        {
            status.Text = "ID no válido.";
        }
    }
}

