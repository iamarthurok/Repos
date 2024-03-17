using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace StudActivDynamicDB
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public int? Height { get; set; }
        public int? Weight { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();

        // Navigation property for StudentActivities
        public ICollection<StudentActivities> StudentActivities { get; set; } = new List<StudentActivities>();
    }
}
