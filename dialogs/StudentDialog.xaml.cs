namespace Maui.Canvas.dialogs;
using Maui.Canvas.viewmodels;

public partial class StudentDialog : ContentPage
{
	public StudentDialog()
	{
		InitializeComponent();
		BindingContext = new StudentDialogViewModel();
	}

	private void Cancel_Clicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//Students");
	}

	private void Save_Clicked(object sender, EventArgs e)
	{
		(BindingContext as StudentDialogViewModel)?.AddStudent();
		Shell.Current.GoToAsync("//Students");
	}

	private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
	{
		BindingContext = new StudentDialogViewModel();
	}
}