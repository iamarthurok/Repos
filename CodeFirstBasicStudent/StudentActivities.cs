using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudActivDynamicDB
{
    public class StudentActivities
    {
        [Key]
        public int StudentID { get; set; }
        [Key]
        public int ActivityID { get; set; }
        [Key]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; private set; }

        // Navigation properties
        public Student Student { get; set; } = null!;
        public Activities Activity { get; set; } = null!;

        // Constructor
        public StudentActivities(int studentID, int activityID, DateTime startDate)
        {
            StudentID = studentID;
            ActivityID = activityID;
            StartDate = startDate;
        }

        // Set EndDate method
        public void SetEndDate(DateTime endDate)
        {
            EndDate = endDate;
        }
    }
}
