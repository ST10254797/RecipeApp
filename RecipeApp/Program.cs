using System;

class Program
{
    static void Main(string[] args)
    {
        Recipe recipe = new Recipe();// Create a new Recipe object
        string userInput;
        bool exit = false;

        Console.WriteLine("Welcome to the Recipe App!");

        // Main loop for the program
        while (!exit)
        {
            Console.ForegroundColor = ConsoleColor.White; // Set text color to white
            Console.WriteLine("\nMenu:");
            Console.WriteLine("\u001b[32m1. Add Ingredient\u001b[39m"); // Set green color for menu option
            Console.WriteLine("\u001b[33m2. Add Step\u001b[39m"); // Set yellow color for menu option
            Console.WriteLine("\u001b[34m3. Display Recipe\u001b[39m"); // Set blue color for menu option
            Console.WriteLine("\u001b[35m4. Scale Recipe\u001b[39m"); // Set magenta color for menu option
            Console.WriteLine("\u001b[36m5. Reset Recipe\u001b[39m"); // Set cyan color for menu option
            Console.WriteLine("\u001b[31m6. Clear Recipe\u001b[39m"); // Set red color for menu option
            Console.WriteLine("\u001b[90m7. Exit\u001b[39m"); // Set gray color for menu option

            Console.Write("Enter your choice: ");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    AddIngredient(recipe);
                    break;
                case "2":
                    AddStep(recipe);
                    break;
                case "3":
                    recipe.DisplayRecipe();
                    break;
                case "4":
                    ScaleRecipe(recipe);
                    break;
                case "5":
                    ResetRecipe(recipe);
                    break;
                case "6":
                    ClearRecipe(recipe);
                    break;
                case "7":
                    exit = true;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red; // Set text color to red for error message
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.ResetColor(); // Reset color
                    break;
            }
        }

        Console.WriteLine("Thank you for using the Recipe App!");
    }

    //
    static void AddIngredient(Recipe recipe)
    {
        string userInput;
        do
        {
            Ingredient ingredient = new Ingredient();
            Console.Write("Enter ingredient name: ");
            ingredient.Name = Console.ReadLine();

            double quantity;
            // Loop to handle invalid quantity inputs
            do
            {
                Console.Write("Enter quantity: ");
                if (!double.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid quantity. Please enter a valid positive number.");
                    Console.ResetColor();
                }
            } while (quantity <= 0);
            ingredient.Quantity = quantity;

            Console.Write("Enter unit: ");
            ingredient.Unit = Console.ReadLine();

            recipe.AddIngredient(ingredient);
            Console.WriteLine("Ingredient added successfully!");

            Console.Write("Do you want to add another ingredient? (\u001b[32myes\u001b[39m/\u001b[31mno\u001b[39m): "); // Set green for "yes" and red for "no"
            userInput = Console.ReadLine();
        } while (userInput.ToLower() == "yes");
    }
    // Method to add steps to the recipe
    static void AddStep(Recipe recipe)
    {
        string userInput;
        do
        {
            Step step = new Step();
            // Loop to handle empty step description inputs
            do
            {
                Console.Write("Enter step description: ");
                step.Description = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(step.Description))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Step description cannot be empty. Please enter a valid description.");
                    Console.ResetColor();
                }
            } while (string.IsNullOrWhiteSpace(step.Description));

            recipe.AddStep(step);
            Console.WriteLine("Step added successfully!");

            Console.Write("Do you want to add another step? (\u001b[32myes\u001b[39m/\u001b[31mno\u001b[39m): "); // Set green for "yes" and red for "no"
            userInput = Console.ReadLine();
        } while (userInput.ToLower() == "yes");
    }

    // Method to scale the recipe by a factor
    static void ScaleRecipe(Recipe recipe)
    {
        double factor;
        string userInput;
        bool validInput = false;
        do
        {
            Console.Write("Enter scaling factor: ");
            userInput = Console.ReadLine();
            if (double.TryParse(userInput, out factor) && factor > 0)
            {
                validInput = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid scaling factor. Please enter a positive number.");
                Console.ResetColor();
            }
        } while (!validInput);

        recipe.ScaleRecipe(factor);
        Console.WriteLine("Recipe scaled successfully!");
    }

    // Method to reset the recipe
    static void ResetRecipe(Recipe recipe)
    {
        recipe.ResetRecipe();
        Console.WriteLine("Recipe reset successfully!");
    }

    // Method to clear the recipe
    static void ClearRecipe(Recipe recipe)
    {
        recipe.ClearRecipe();
    }
}
