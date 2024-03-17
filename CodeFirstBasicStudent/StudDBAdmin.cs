using StudActivDynamicDB;
using Microsoft.EntityFrameworkCore;
using System;

namespace DeleteStudentActivitiesDatabase
{
    class StudDBAdmin
    {
        static void DropDB()
        {
            DropActivStudDB();
        }

        static void DropActivStudDB()
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
