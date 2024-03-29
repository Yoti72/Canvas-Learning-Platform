
namespace CanvasApp.Models
{
    public class Course
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Person> Roster { get; set; }
        public List<Assignment> Assignments { get; set; }
        public List<Module> Modules { get; set; }

        public Course()
        {
            Code = string.Empty;
            Name = string.Empty;
            Description = string.Empty;
            Roster = new List<Person>();
            Assignments = new List<Assignment>();
            Modules = new List<Module>();
        }

        public override string ToString()
        {
            return $"{Code} {Name}";
        }

        public string DetailDisplay
        {
            get
            {
                return $"{ToString()}\n{Description}\n\n" + 
                $"Roster:\n{string.Join("\n", Roster.Select(s => s.ToString()).ToArray())}\n\n" +
                 $"Assignments:\n{string.Join("\n", Assignments.Select(a => a.ToString()).ToArray())}";
            }
        }
    }
}