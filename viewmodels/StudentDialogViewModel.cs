using CanvasApp.Models;
using CanvasApp.Services;

namespace Maui.Canvas.viewmodels;

public class StudentDialogViewModel
{
    private Person? student;

  
    public string Name
    {
        get { return student?.Name ?? string.Empty; }
        set { 
            if (student == null ) student = new Person();
            student.Name = value;
            }
    }

    public int Id
    {
        get { return student.Id ?? 0; }
        set { 
            if (student == null ) student = new Person();
            student.Id = value; 
            }
    }

    public StudentDialogViewModel()
    {
        student = new Person();
    }

    public void AddStudent()
    {
        if (student != null)
        {
            StudentService.Current.Add(student);
  
        }
    }

}
