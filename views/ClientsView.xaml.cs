using Maui.Canvas.viewmodels;
namespace Maui.Canvas.views;

public partial class ClientsView : ContentPage
{
	public ClientsView()
	{
		InitializeComponent();
		BindingContext = new ClientsViewModel();
	}

	private void Button_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
}