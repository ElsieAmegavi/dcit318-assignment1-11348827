using System;

namespace TriangleTypeIdentifier
{
    /// Triangle Type Identifier Console Application
    /// Determines triangle type (Equilateral, Isosceles, or Scalene) based on side lengths
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Triangle Type Identifier ===");
            Console.WriteLine("Enter three side lengths to determine the triangle type.");
            Console.WriteLine("Note: All sides must be positive numbers and form a valid triangle.");
            Console.WriteLine();

            bool continueProgram = true;

            while (continueProgram)
            {
                try
                {
                    // Get three side lengths from user
                    double side1 = GetValidSideLength("Enter the length of side 1: ");
                    double side2 = GetValidSideLength("Enter the length of side 2: ");
                    double side3 = GetValidSideLength("Enter the length of side 3: ");

                    // Validate triangle inequality
                    if (IsValidTriangle(side1, side2, side3))
                    {
                        // Determine triangle type
                        string triangleType = DetermineTriangleType(side1, side2, side3);
                        
                        // Display results
                        Console.WriteLine($"\n=== Triangle Analysis Results ===");
                        Console.WriteLine($"Side 1: {side1:F2}");
                        Console.WriteLine($"Side 2: {side2:F2}");
                        Console.WriteLine($"Side 3: {side3:F2}");
                        Console.WriteLine($"Triangle Type: {triangleType}");
                        Console.WriteLine($"Description: {GetTriangleDescription(triangleType)}");
                        
                        // Calculate and display perimeter as bonus information
                        double perimeter = side1 + side2 + side3;
                        Console.WriteLine($"Perimeter: {perimeter:F2} units");
                    }
                    else
                    {
                        Console.WriteLine("\nError: These side lengths cannot form a valid triangle!");
                        Console.WriteLine("Triangle Inequality Rule: The sum of any two sides must be greater than the third side.");
                        DisplayTriangleValidation(side1, side2, side3);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }

                // Ask if user wants to continue
                Console.WriteLine();
                Console.Write("Do you want to analyze another triangle? (y/n): ");
                string? continueInput = Console.ReadLine()?.ToLower();
                continueProgram = continueInput == "y" || continueInput == "yes";
                
                if (continueProgram)
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine("\nThank you for using the Triangle Type Identifier!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        /// Prompts user for a valid side length and validates input
        /// <param name="prompt">The prompt message to display</param>
        static double GetValidSideLength(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input) && double.TryParse(input, out double sideLength))
                {
                    if (sideLength > 0)
                    {
                        return sideLength;
                    }
                    else
                    {
                        Console.WriteLine("Error: Side length must be a positive number. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: Please enter a valid numerical value. Please try again.");
                }
            }
        }

        /// Validates if three sides can form a valid triangle using triangle inequality theorem
        /// <param name="side1">First side length</param>
        /// <param name="side2">Second side length</param>
        /// <param name="side3">Third side length</param>
        static bool IsValidTriangle(double side1, double side2, double side3)
        {
            // Triangle inequality: sum of any two sides must be greater than the third side
            return (side1 + side2 > side3) && 
                   (side1 + side3 > side2) && 
                   (side2 + side3 > side1);
        }

        /// Determines the type of triangle based on side lengths
        /// <param name="side1">First side length</param>
        /// <param name="side2">Second side length</param>
        /// <param name="side3">Third side length</param>
        static string DetermineTriangleType(double side1, double side2, double side3)
        {
            // Use a small tolerance for floating point comparison
            const double tolerance = 1e-10;

            bool side1EqualsSide2 = Math.Abs(side1 - side2) < tolerance;
            bool side1EqualsSide3 = Math.Abs(side1 - side3) < tolerance;
            bool side2EqualsSide3 = Math.Abs(side2 - side3) < tolerance;

            // Check for equilateral (all three sides equal)
            if (side1EqualsSide2 && side1EqualsSide3)
            {
                return "Equilateral";
            }
            // Check for isosceles (exactly two sides equal)
            else if (side1EqualsSide2 || side1EqualsSide3 || side2EqualsSide3)
            {
                return "Isosceles";
            }
            // Otherwise scalene (no sides equal)
            else
            {
                return "Scalene";
            }
        }

        /// Provides a description for the triangle type
        /// <param name="triangleType">The type of triangle</param>
        static string GetTriangleDescription(string triangleType)
        {
            return triangleType switch
            {
                "Equilateral" => "All three sides are equal in length",
                "Isosceles" => "Exactly two sides are equal in length",
                "Scalene" => "All three sides are different in length",
                _ => "Unknown triangle type"
            };
        }

        /// Displays triangle validation details for debugging
        /// <param name="side1">First side length</param>
        /// <param name="side2">Second side length</param>
        /// <param name="side3">Third side length</param>
        static void DisplayTriangleValidation(double side1, double side2, double side3)
        {
            Console.WriteLine("Validation Details:");
            Console.WriteLine($"Side 1 + Side 2 = {side1:F2} + {side2:F2} = {(side1 + side2):F2} > {side3:F2}? {(side1 + side2 > side3)}");
            Console.WriteLine($"Side 1 + Side 3 = {side1:F2} + {side3:F2} = {(side1 + side3):F2} > {side2:F2}? {(side1 + side3 > side2)}");
            Console.WriteLine($"Side 2 + Side 3 = {side2:F2} + {side3:F2} = {(side2 + side3):F2} > {side1:F2}? {(side2 + side3 > side1)}");
        }
    }
}
