namespace Maui.Canvas;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
	}

	private void Projects_View_Clicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//Projects");
	}

	private void Clients_View_Clicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//Clients");	
	}


}

