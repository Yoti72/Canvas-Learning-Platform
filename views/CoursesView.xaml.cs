namespace Maui.Canvas.views;

public partial class CoursesView : ContentPage
{
	public CoursesView()
	{
		InitializeComponent();
	}
	private void Button_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
}