using Maui.Canvas.viewmodels;
namespace Maui.Canvas.views;

public partial class StudentsView : ContentPage
{
	public StudentsView()
	{
		InitializeComponent();
		BindingContext = new StudentsViewModel();
	}

	private void Button_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

	private void Add_Clicked(object sender, EventArgs e)
    {
		//(BindingContext as StudentsViewModel)?.AddStudent();
		Shell.Current.GoToAsync("//StudentDetail");
    }

	private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
	{
		(BindingContext as StudentsViewModel)?.Refresh();
	}

	private void Delete_Clicked(object sender, EventArgs e)
	{
	
		(BindingContext as StudentsViewModel)?.Remove();
	}
}