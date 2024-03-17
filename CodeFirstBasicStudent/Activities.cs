using System.ComponentModel.DataAnnotations;

namespace StudActivDynamicDB
{
    public class Activities
    {
        [Key]
        public int ActivityID { get; set; }
        public string? ActivityName { get; set; } // Allows null values
        public int Duration { get; set; } // activity duration in seconds
        // Constructor
        public Activities()
        {
            ActivityName = ""; // Initializes ActivityName with an empty string
        }

        // Navigation property for StudentActivities
        public ICollection<StudentActivities> StudentActivities { get; set; } = new List<StudentActivities>();
    
}
}
