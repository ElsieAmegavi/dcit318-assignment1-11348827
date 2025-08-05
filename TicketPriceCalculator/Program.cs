using System;

namespace TicketPriceCalculator
{
    /// Ticket Price Calculator Console Application
    /// Calculates ticket prices based on age with discounts for seniors and children
    class Program
    {
        // Constants for ticket pricing
        private const double REGULAR_PRICE = 10.0;
        private const double DISCOUNTED_PRICE = 7.0;
        private const int CHILD_AGE_LIMIT = 12;
        private const int SENIOR_AGE_LIMIT = 65;

        static void Main(string[] args)
        {
            Console.WriteLine("=== Movie Ticket Price Calculator ===");
            Console.WriteLine("Calculate your ticket price based on your age.");
            Console.WriteLine($"Regular Price: GHC {REGULAR_PRICE:F2}");
            Console.WriteLine($"Senior (65+) and Child (12 and under) Price: GHC {DISCOUNTED_PRICE:F2}");
            Console.WriteLine();

            bool continueProgram = true;

            while (continueProgram)
            {
                try
                {
                    // Prompt user for age input
                    Console.Write("Enter your age: ");
                    string? input = Console.ReadLine();

                    // Validate and parse the input
                    if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int age))
                    {
                        // Validate age is positive
                        if (age < 0)
                        {
                            Console.WriteLine("Error: Age cannot be negative. Please enter a valid age.");
                        }
                        else if (age > 150)
                        {
                            Console.WriteLine("Error: Please enter a realistic age.");
                        }
                        else
                        {
                            // Calculate ticket price and discount information
                            var ticketInfo = CalculateTicketPrice(age);
                            
                            // Display results
                            Console.WriteLine($"\n=== Ticket Price Results ===");
                            Console.WriteLine($"Age: {age} years old");
                            Console.WriteLine($"Category: {ticketInfo.Category}");
                            Console.WriteLine($"Ticket Price: GHC {ticketInfo.Price:F2}");
                            
                            if (!string.IsNullOrEmpty(ticketInfo.DiscountReason))
                            {
                                Console.WriteLine($"Discount Applied: {ticketInfo.DiscountReason}");
                                Console.WriteLine($"You saved: GHC {(REGULAR_PRICE - ticketInfo.Price):F2}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: Please enter a valid numerical age.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }

                // Ask if user wants to continue
                Console.WriteLine();
                Console.Write("Do you want to calculate another ticket price? (y/n): ");
                string? continueInput = Console.ReadLine()?.ToLower();
                continueProgram = continueInput == "y" || continueInput == "yes";
                
                if (continueProgram)
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine("\nThank you for using the Ticket Price Calculator!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        /// Calculates ticket price based on age
        /// <param name="age">Customer's age</param>
        static TicketInfo CalculateTicketPrice(int age)
        {
            var ticketInfo = new TicketInfo();

            if (age <= CHILD_AGE_LIMIT)
            {
                ticketInfo.Price = DISCOUNTED_PRICE;
                ticketInfo.Category = "Child";
                ticketInfo.DiscountReason = "Child discount (12 and under)";
            }
            else if (age >= SENIOR_AGE_LIMIT)
            {
                ticketInfo.Price = DISCOUNTED_PRICE;
                ticketInfo.Category = "Senior";
                ticketInfo.DiscountReason = "Senior discount (65 and over)";
            }
            else
            {
                ticketInfo.Price = REGULAR_PRICE;
                ticketInfo.Category = "Regular";
                ticketInfo.DiscountReason = "";
            }

            return ticketInfo;
        }

        /// Structure to hold ticket pricing information
        public struct TicketInfo
        {
            public double Price { get; set; }
            public string Category { get; set; }
            public string DiscountReason { get; set; }
        }
    }
}
