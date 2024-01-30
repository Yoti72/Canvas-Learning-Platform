using CanvasApp.Models;

namespace CanvasApp.Services
{

    public class StudentService
    {
        private List<Person> studentList;

        private static StudentService? _instance;

        private StudentService()
        {
            studentList = new List<Person>();
        }

        public static StudentService Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StudentService();
                }
                return _instance;
            }
        }

        public void Add(Person student)
        {
            studentList.Add(student);
        }

        public List<Person> Students
        {
            get
            {
                return studentList;
            }
            
        }

        public IEnumerable<Person> Search(string query)
        {
            return studentList.Where(s => s.Name != null && s.Name.ToUpper().Contains(query.ToUpper()));
            //return studentList.Where(s => s.Name.ToUpper().Contains(query.ToUpper()));
        }


    }
    
}