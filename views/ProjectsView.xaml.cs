namespace Maui.Canvas.views;

public partial class ProjectsView : ContentPage
{
	public ProjectsView()
	{
		InitializeComponent();
	}
	private void Button_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
}