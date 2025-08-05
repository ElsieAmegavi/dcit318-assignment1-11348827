# DCIT 318 Assignment 1 - C# Console Applications

This repository contains three separate C# console applications as part of the DCIT 318 Programming II assignment.

## Applications

### 1. Grade Calculator
**Location:** `GradeCalculator/Program.cs`

**Features:**
- Prompts user to enter a numerical grade (0-100)
- Validates input range and format
- Converts numerical grades to letter grades:
  - 90-100: A (Excellent)
  - 80-89: B (Good)
  - 70-79: C (Average)
  - 60-69: D (Below Average)
  - Below 60: F (Failing)
- Displays grade with description
- Handles invalid input gracefully
- Allows multiple calculations

### 2. Ticket Price Calculator
**Location:** `TicketPriceCalculator/Program.cs`

**Features:**
- Prompts user to enter their age
- Calculates ticket price based on age:
  - Regular price: GHC 10.00
  - Senior (65+): GHC 7.00 (discount)
  - Child (12 and under): GHC 7.00 (discount)
- Validates age input (positive numbers only)
- Shows discount reason when applicable
- Displays savings amount for discounted tickets
- Allows multiple calculations

## How to Run

Navigate to the specific project folder and run:

```bash
# For Grade Calculator
cd GradeCalculator
dotnet run

# For Ticket Price Calculator
cd TicketPriceCalculator
dotnet run

# For Triangle Type Identifier
cd TriangleTypeIdentifier
dotnet run
``` -->

### Using VS Code
1. Open the workspace in VS Code
2. Open the terminal (Ctrl + `)
3. Navigate to the desired project folder
4. Run `dotnet run`

## Programming Features Demonstrated

### Input Validation
- **Type validation:** Using `TryParse` methods to ensure valid numerical input
- **Range validation:** Checking values are within acceptable ranges
- **Error handling:** Try-catch blocks to handle unexpected errors
- **User-friendly prompts:** Clear instructions and error messages

### Data Types Used
- `double`: For grades and measurements requiring decimal precision
- `int`: For ages and simple numerical values
- `string`: For user input and text processing
- `bool`: For program flow control
- `struct`: Custom data structure for ticket information

### Control Structures
- **Conditional statements:** if-else chains and switch statements
- **Loops:** while loops for program continuation
- **Method calls:** Organized code into reusable methods

### Best Practices Implemented
- **Meaningful variable names:** Clear, descriptive naming conventions
- **Code comments:** XML documentation and inline comments
- **Proper indentation:** Consistent code formatting
- **Separation of concerns:** Methods for specific functionality
- **Constants:** Using const for fixed values
- **User experience:** Clear output formatting and continuous operation options

## Technical Requirements Met

**Console I/O:** All applications use `Console.WriteLine()` and `Console.ReadLine()`  
**Input Validation:** Comprehensive validation with try-catch blocks  
**Error Handling:** Graceful handling of invalid input  
**Multiple Executions:** All apps allow running multiple times  
**Clear Output:** Well-formatted, user-friendly display  
**Proper Data Types:** Appropriate use of int, double, string, bool  
**Conditional Logic:** Effective use of if-else statements  
**Code Documentation:** Comments explaining logic and functionality  

## Author
Student ID: 11348827  
Course: DCIT 318 - Programming II  
Assignment: Assignment 1 - C# Console Applications
