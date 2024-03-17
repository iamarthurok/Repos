using System;

namespace OperatorsAssignmentSubmission
{
    // Create an Employee class with Id, FirstName and LastName properties
    public class Employee
    {
        public int Id {get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Employee(int id, string firstName, string lastName)

        /*
         *  Employee emp1 = new Employee(1, "Artur", "Malkiewicz");
            Employee emp2 = new Employee(1, "Arturro", "Malkiewicz");
        */
        {  // creating the Constructor to initialize properties
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        
        // Overloading operator to compare Employee objects based on their Id
        public static bool operator ==(Employee emp1, Employee emp2)
        {
            // Return true if both objects are equal or the same object; otherwise, compare their Ids
            return ReferenceEquals(emp1, emp2) || !(emp1 is null || emp2 is null || emp1.Id != emp2.Id);
        }

        // Fixing an operator error that '==' requires a compatible operator '!=' 
        public static bool operator !=(Employee emp1, Employee emp2)
        {
            return !(emp1 == emp2);
        }

        // Override Equals method because we had an alert that it is not overriden
        public override bool Equals(object obj)
        {
            // If the object is not an Employee or null, return false
            if (!(obj is Employee emp))
            {     return false; }

            // overloaded "==" operator for this
            return this == emp;
        }
        // Override the GetHashCode method because we had an alert that it is not overriden
        public override int GetHashCode()
        {
            // Return the correct hash code of the Id property
            return Id.GetHashCode();
        }

        /* NOW THERE IS COMPLETE !!! */


    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter details for Employee 1:");
            Console.Write("Id: ");
            int emp1Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("First Name: ");
            string emp1FirstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string emp1LastName = Console.ReadLine();

            Employee emp1 = new Employee(emp1Id, emp1FirstName, emp1LastName);


            Console.WriteLine("\nEnter details for Employee 2:");
            Console.Write("Id: ");
            int emp2Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("First Name: ");
            string emp2FirstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string emp2LastName = Console.ReadLine();

            Employee emp2 = new Employee(emp2Id, emp2FirstName, emp2LastName);

            // Comparing the Employee objects using the overloaded "==" operator based on the provided EmpId
            if (emp1 == emp2)
            {
                Console.WriteLine("\nEmployees are equal using EmpId only!");
            }
            else
            {
                Console.WriteLine("\nEmployees are not equal using EmpId only!");
            }

          Console.ReadLine();
        }
    }
}
