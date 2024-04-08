namespace CanvasApp.Models {
    public class Project {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid Id { get; }
        public Guid StudentId { get; private set; } 

    }
}