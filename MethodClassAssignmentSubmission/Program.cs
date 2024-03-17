using System;

// Define a class named MathOperations
public class MathOperations
{
    // Define a void method named PerformOperation that takes two integers as parameters
    public void PerformOperation(int nbr1, int nbr2)
    {
        // Perform a simple math operation on the first integer
        int result = nbr1 * 2;

        // Display the second integer to the screen
        Console.WriteLine($"Second integer parameter is: {nbr2}");

    }
}

class Program
{
    static void Main()
    {
        // Instantiate the MathOperations class to using methods from that class
        MathOperations mathOpe = new MathOperations();

        // Calling the PerformOperation method in the class
        mathOpe.PerformOperation(5, 10);

        // Call the PerformOperation method in the class, specifying the parameters by name
        mathOpe.PerformOperation(nbr2: 6, nbr1: 5);

        Console.ReadLine();
    }
}
