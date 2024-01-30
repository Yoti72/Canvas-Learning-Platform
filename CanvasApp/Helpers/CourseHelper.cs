
using CanvasApp.Models;
using CanvasApp.Services;

namespace CanvasApp.Helpers
{

    public class CourseHelper 
    {
        private CourseService courseService;
        private StudentService studentService;

        public CourseHelper()
        {
            studentService = StudentService.Current;
            courseService = CourseService.Current;

        }

        public void CreateCourseRecord(Course? selectedCourse = null)
        {
            Console.WriteLine("What is the code of the student");
            var code = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("What is the name of the student?");
            var name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("what is the description of the course? ");
            var description = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Which students should be enrolled in this course? [Q to quit]");
            var roster = new List<Person>();
            bool continueAdding = true;
            while (continueAdding)
            {
                studentService.Students.Where(s => roster.Any(s2 => s2.Id == s.Id)).ToList().ForEach(Console.WriteLine);
                var selection = "Q";
                if (studentService.Students.Any(s => roster.Any(s2 => s2.Id == s.Id)))
                {
                    selection = Console.ReadLine() ?? string.Empty;
                }

                if (selection.Equals("Q", StringComparison.InvariantCultureIgnoreCase)) 
                {
                    continueAdding = false;
                }
                else
                {
                    var selectedId = int.Parse(selection);
                    var selectedStudent = studentService.Students.FirstOrDefault(s => s.Id == selectedId);
                    if (selectedStudent != null)
                    {
                        roster.Add(selectedStudent);
                    }
                }
            }

            Console.WriteLine("Would you like to add assignments? [Y/N]");
            var assignResponse = Console.ReadLine() ?? "N";
            var assignments = new List<Assignment>();
            if (assignResponse.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            {
                continueAdding = true;
                while (continueAdding)
                {
                    Console.WriteLine("What is the name of the assignment?");
                    var assignmentName = Console.ReadLine() ?? string.Empty;

                    Console.WriteLine("What is the description of the assignment?");
                    var assignmentDescription = Console.ReadLine() ?? string.Empty;

                    Console.WriteLine("What is the total points of this assignment?");
                    var totalPoints = decimal.Parse(Console.ReadLine() ?? "100");

                    Console.WriteLine("What is the due date of this assignment?");
                    var dueDate = DateTime.Parse(Console.ReadLine() ?? "01/01/1900");
                 
                    assignments.Add(new Assignment
                    {
                        Name = assignmentName,
                        Description = assignmentDescription,
                        TotalAvailablePoints = totalPoints,
                        DueDate = dueDate
                    });

                    Console.WriteLine("Would you like to add another assignment? [Y/N]");
                    assignResponse = Console.ReadLine() ?? "N";
                    if(assignResponse.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                    {
                        continueAdding = false;

                    }

                }
    
            }

            bool isNewCourse = false;
            if (selectedCourse == null)
            {
                isNewCourse = true;
                selectedCourse = new Course();
            } 
                
                selectedCourse.Code = code;
                selectedCourse.Name = name;
                selectedCourse.Description = description;
                selectedCourse.Roster = new List<Person>();
                selectedCourse.Roster.AddRange(roster);
                selectedCourse.Assignments = new List<Assignment>();
                selectedCourse.Assignments.AddRange(assignments);

            if (isNewCourse)
            {
                courseService.Add(selectedCourse);
            }

        
        }

       
        public void UpdateCourseRecord() {
            Console.WriteLine("Select a course to update");
            SearchCourses();

            var selection = Console.ReadLine();

            var selectedCourse = courseService.Courses.FirstOrDefault(s => s.Code.Equals(selection, StringComparison.InvariantCultureIgnoreCase));

            if (selectedCourse != null)
            {
                CreateCourseRecord(selectedCourse);
            }
       
        }
   

        public void SearchCourses(string? query = null)
        {
            if (string.IsNullOrEmpty(query))
            {
                courseService.Courses.ForEach(Console.WriteLine);
            }
            else {
                courseService.Search(query).ToList().ForEach(Console.WriteLine);
            }

            Console.WriteLine("Select a Course: ");
            var code = Console.ReadLine() ?? string.Empty;
            var selectedCourse = courseService.Courses.FirstOrDefault(c => c.Code.Equals(code, StringComparison.InvariantCultureIgnoreCase));
            if (selectedCourse != null)
            {
                Console.WriteLine(selectedCourse.DetailDisplay);
            }
            
        }

    }

}