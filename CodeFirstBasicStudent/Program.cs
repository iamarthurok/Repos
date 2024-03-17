using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace StudActivDynamicDB
{
    class Program
    {
        static void Main(string[] args)
        {
        /* The idea of deleting the database is not a good one and goes against the concept 
            of the application, which is supposed to create the database itself and then simply
            add new records to it. THIS APPROACH WAS USED SOLELY FOR EDUCATIONAL PURPOSES TO 
            AVOID THE NEED TO ELABORATE ON THE MECHANISM OF INSERTING SAMPLE DATA INTO TABLES 
            - multiple runs of the application result in duplicates in the StudentActivities 
            table, and the data is not inserted  
        */
            DropDatabase(); // Comment in this line to NOT deleting the database

            var optionsBuilder = new DbContextOptionsBuilder<SchoolContext>();
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=StudActivDB;Trusted_Connection=True;");

            using (var context = new SchoolContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();

                // Adding sample students
                var students = new[]
                {
                    new Student { StudentName = "John Doe", Height = 180, Weight = 75 },
                    new Student { StudentName = "Jane Smith", Height = 170, Weight = 65 }
                };

                context.Students.AddRange(students);
                context.SaveChanges();

                Console.WriteLine("Students added successfully.");

                // Get all students
                var allStudents = context.Students.ToList();
                Console.WriteLine("\nAll Students:");
                foreach (var s in allStudents)
                {
                    Console.WriteLine($"ID: {s.StudentID}, Name: {s.StudentName}, Height: {s.Height}, Weight: {s.Weight}");
                }

                // Adding sample activities
                var activities = new[]
                {
                    new Activities { ActivityName = "Swimming", Duration = 3600 },
                    new Activities { ActivityName = "Running", Duration = 1800 },
                    new Activities { ActivityName = "Cycling", Duration = 2400 }
                };

                context.Activities.AddRange(activities);
                context.SaveChanges();

                Console.WriteLine("\nSample activities added successfully.");

                // Get all activities
                var allActivities = context.Activities.ToList();
                Console.WriteLine("\nAll Activities:");
                foreach (var activity in allActivities)
                {
                    Console.WriteLine($"ActivityID: {activity.ActivityID}, ActivityName: {activity.ActivityName}, Duration: {activity.Duration} seconds");
                }

                // Assign random activities to students
                var random = new Random();
                foreach (var student in allStudents)
                {
                    var randomActivities = allActivities.OrderBy(x => random.Next()).Take(3).ToList();
                    foreach (var activity in randomActivities)
                    {
                        var studentActivity = new StudentActivities(student.StudentID, activity.ActivityID, DateTime.Now);
                        studentActivity.SetEndDate(DateTime.Now.AddDays(7)); // Set end date
                        context.StudentActivities.Add(studentActivity);
                    }
                }

                context.SaveChanges();

                Console.WriteLine("\nActivities assigned to students successfully.");
            }
        }

        static void DropDatabase()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SchoolContext>();
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=StudActivDB;Trusted_Connection=True;");

            using (var context = new SchoolContext(optionsBuilder.Options))
            {
                // Check if the database exists
                if (context.Database.CanConnect())
                {
                    // Delete the database
                    context.Database.EnsureDeleted();
                    Console.WriteLine("Database deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Database does not exist.");
                }
            }
        }
    }
}
