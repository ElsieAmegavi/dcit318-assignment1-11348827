using System;

namespace GradeCalculator
{
    /// Grade Calculator Console Application
    /// Converts numerical grades (0-100) to letter grades
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Grade Calculator ===");
            Console.WriteLine("This program converts numerical grades to letter grades.");
            Console.WriteLine();

            bool continueProgram = true;

            while (continueProgram)
            {
                try
                {
                    // Prompt user for grade input
                    Console.Write("Enter a numerical grade (0-100): ");
                    string? input = Console.ReadLine();

                    // Validate and parse the input
                    if (!string.IsNullOrEmpty(input) && double.TryParse(input, out double numericalGrade))
                    {
                        // Validate grade range
                        if (numericalGrade < 0 || numericalGrade > 100)
                        {
                            Console.WriteLine("Error: Grade must be between 0 and 100.");
                        }
                        else
                        {
                            // Calculate letter grade
                            string letterGrade = CalculateLetterGrade(numericalGrade);
                            
                            // Display results
                            Console.WriteLine($"\nGrade Results:");
                            Console.WriteLine($"Numerical Grade: {numericalGrade:F1}");
                            Console.WriteLine($"Letter Grade: {letterGrade}");
                            Console.WriteLine($"Grade Description: {GetGradeDescription(letterGrade)}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: Please enter a valid numerical value.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }

                // Ask if user wants to continue
                Console.WriteLine();
                Console.Write("Do you want to calculate another grade? (y/n): ");
                string? continueInput = Console.ReadLine()?.ToLower();
                continueProgram = continueInput == "y" || continueInput == "yes";
                
                if (continueProgram)
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine("\nThank you for using the Grade Calculator!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        /// Converts numerical grade to letter grade
        /// <param name="grade">Numerical grade between 0-100</param>
        /// <returns>Letter grade (A, B, C, D, or F)</returns>
        static string CalculateLetterGrade(double grade)
        {
            if (grade >= 90)
                return "A";
            else if (grade >= 80)
                return "B";
            else if (grade >= 70)
                return "C";
            else if (grade >= 60)
                return "D";
            else
                return "F";
        }


        /// Provides a description for the letter grade
        /// <param name="letterGrade">Letter grade (A, B, C, D, or F)</param>
        static string GetGradeDescription(string letterGrade)
        {
            switch (letterGrade)
            {
                case "A":
                    return "Excellent (90-100)";
                case "B":
                    return "Good (80-89)";
                case "C":
                    return "Average (70-79)";
                case "D":
                    return "Below Average (60-69)";
                case "F":
                    return "Failing (Below 60)";
                default:
                    return "Unknown";
            }
        }
    }
}
