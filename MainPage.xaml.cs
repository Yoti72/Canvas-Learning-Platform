namespace Maui.Canvas;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
	}

	private void Courses_View_Clicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//Courses");
	}

	private void Students_View_Clicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//Students");	
	}


}

