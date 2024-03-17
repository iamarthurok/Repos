using System;

namespace BranchingAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Welcome message
            Console.WriteLine("Welcome to Package Express!");
            Console.WriteLine("###########################");

            // Prompt for package weight
            Console.WriteLine("Please enter the package weight:");
            int weight = Convert.ToInt32(Console.ReadLine());

            // Check if weight is greater than 50
            if (weight > 50)
            {
                Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
                return; // End the program
            }

            // Prompt for package dimensions
            Console.WriteLine("Please enter the package dimensions:");
            Console.WriteLine("width:");
            int width = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("height:");
            int height = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("length:");
            int length = Convert.ToInt32(Console.ReadLine());

            // Check if dimensions total is greater than 50
            if (width + height + length > 50)
            {
                Console.WriteLine("Package is too big to be shipped via Package Express.");
                return; // End the program
            }

            // Calculate to display the quote
            decimal quote = (width * height * length * weight) / 100m;
            Console.WriteLine($"Your estimated total for shipping this package is: ${quote:F2}");
            Console.WriteLine("Thank you!");
        }
    }
}
