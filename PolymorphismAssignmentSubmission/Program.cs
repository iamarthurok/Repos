using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismAssignmentSubmission
{

    // Define an interface
    public interface IQuittable
    {
        // Define a void method called Quit
        void Quit();
    }

    // Define class called Employee that inherits from IQuittable interface
    public class Employee : IQuittable
    {
        // Implement the Quit method defined in the IQuittable interface
        public void Quit()
        {
            Console.WriteLine("Employee quits the job."); // Display a message indicating quitting action
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Create an object emp of type IQuittable interface - using polymorphism
            IQuittable emp = new Employee(); // object can be of type Employee class since it implements IQuittable interface

            // call the Quit method on the object emp
            emp.Quit();
        }
    }
}
