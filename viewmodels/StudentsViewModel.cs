using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using CanvasApp.Models;
using CanvasApp.Services;
using System.ComponentModel;


namespace Maui.Canvas.viewmodels
{
    internal class StudentsViewModel : INotifyPropertyChanged
    {
    
        private StudentService studentSvc;
 
        public ObservableCollection<Person> Students
        {
            get
            {
                return new ObservableCollection<Person>(studentSvc.Students);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Person SelectedStudent { get; set; }

        public void AddStudent()
        {
            studentSvc.Add(new Person{ Name = "New Student" });
            NotifyPropertyChanged(nameof(Students));
        }

        public void Remove()
        {
            studentSvc.Remove(SelectedStudent);
            Refresh();
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Students));
        }

        public StudentsViewModel()
        {
            studentSvc =  StudentService.Current;
        }
    }


}


