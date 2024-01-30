using CanvasApp.Models;
using CanvasApp.Services;

namespace CanvasApp.Helpers {
    internal class StudentHelper {


        private StudentService studentService;
        private CourseService courseService;

        public StudentHelper()
        {
            studentService = StudentService.Current;
            courseService = CourseService.Current;
        }
        public void AddOrUpdateStudent(Person? selectedStudent = null)
        {
            

            Console.WriteLine("What is the ID of the student");
            var id = Console.ReadLine();
            Console.WriteLine("What is the name of the student?");
            var name = Console.ReadLine();
            Console.WriteLine("what is the classification of the student? [(F)reshman, S(o)phomore, (J)unior, (S)enior]");
            var classification = Console.ReadLine() ?? string.Empty;

            PersonClassification classEnum = PersonClassification.Freshman;

        
            if (classification.Equals("O", StringComparison.InvariantCultureIgnoreCase))
            {
                classEnum = PersonClassification.Sophomore;
            }
            else if (classification.Equals("J", StringComparison.InvariantCultureIgnoreCase))
            {
                classEnum = PersonClassification.Junior;
            }
            else if (classification.Equals("S", StringComparison.InvariantCultureIgnoreCase))
            {
                classEnum = PersonClassification.Senior;
            }
           
            bool isCreate = false;
            if (selectedStudent == null)
            {
                selectedStudent = new Person();
            }

            selectedStudent.Id = int.Parse(id ?? "0");
            selectedStudent.Name = name ?? string.Empty;
            selectedStudent.Classification = classEnum;

            if (isCreate)
            {
                studentService.Add(selectedStudent);
            }
            
        }

        public void UpdateStudentRecord() {
            Console.WriteLine("Select a student to update");
            ListStudents();
            var selectionString = Console.ReadLine();

            if (int.TryParse(selectionString, out int selectionInt))
            { 
                var selectedStudent = studentService.Students.FirstOrDefault(s => s.Id == selectionInt);
                if (selectedStudent != null)
                {
                    AddOrUpdateStudent(selectedStudent);
                }
            }
        }

        public void ListStudents()
        {
            studentService.Students.ForEach(Console.WriteLine);
            Console.WriteLine("Select a student to update");
            var selectionStr = Console.ReadLine();
            var selectionInt = int.Parse(selectionStr ?? "0");
            Console.WriteLine("Student Course List:");
            courseService.Courses.Where(c => c.Roster.Any(s => s.Id == selectionInt)).ToList().ForEach(Console.WriteLine);
        }
    
        public void SearchStudents()
        {
            Console.WriteLine("Enter a query");
            var query = Console.ReadLine() ?? string.Empty;
            studentService.Search(query).ToList().ForEach(Console.WriteLine);

            var selectionStr = Console.ReadLine();
            var selectionInt = int.Parse(selectionStr ?? "0");
            Console.WriteLine("Student Course List:");
            courseService.Courses.Where(c => c.Roster.Any(s => s.Id == selectionInt)).ToList().ForEach(Console.WriteLine);
        }

    }



}