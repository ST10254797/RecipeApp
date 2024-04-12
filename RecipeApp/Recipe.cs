class Recipe
{
    private Ingredient[] ingredients;// Array to store ingredients
    private Step[] steps;// Array to store steps
    private int ingredientCount;// Track the number of ingredients
    private int stepCount;// Track the number of steps

    // Constructor to initialize the recipe with arrays for ingredients and steps
    public Recipe()
    {
        ingredients = new Ingredient[10]; // Initial capacity for ingredients array
        steps = new Step[10]; // Initial capacity for steps array
        ingredientCount = 0;// Initialize ingredient count to zero
        stepCount = 0;// Initialize step count to zero
    }


    // Method to add an ingredient to the recipe
    public void AddIngredient(Ingredient ingredient)
    {
        if (ingredientCount < ingredients.Length)
        {
            ingredients[ingredientCount] = ingredient;// Add the ingredient to the array
            ingredients[ingredientCount].OriginalQuantity = ingredient.Quantity; // Store original quantity
            ingredientCount++;// Increment ingredient count
        }
        else
        {
            Console.WriteLine("Cannot add more ingredients. Recipe capacity reached.");
        }
    }

    // Method to add a step to the recipe
    public void AddStep(Step step)
    {
        if (stepCount < steps.Length)
        {
            steps[stepCount++] = step;// Add the step to the array
        }
        else
        {
            Console.WriteLine("Cannot add more steps. Recipe capacity reached.");
        }
    }

    // Method to display the recipe
    public void DisplayRecipe()
    {
        Console.Clear(); // Clear the console before displaying the recipe

        // Set console colors for the header
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Recipe:");
        Console.ResetColor(); // Reset console colors

        // Display ingredients section
        Console.WriteLine("Ingredients:");
        Console.WriteLine("------------------------------");

        // Set console colors for ingredients
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        for (int i = 0; i < ingredientCount; i++)
        {
            string ingredientLine = $"{ingredients[i].Quantity:0.##} {ingredients[i].Unit} of {ingredients[i].Name}";
            Console.WriteLine(ingredientLine);
        }
        Console.ResetColor(); // Reset console colors

        Console.WriteLine("------------------------------");

        // Display steps section
        Console.WriteLine("Steps:");
        Console.WriteLine("------------------------------");

        // Set console colors for steps
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        for (int i = 0; i < stepCount; i++)
        {
            Console.WriteLine($"{i + 1}. {steps[i].Description}");
        }
        Console.ResetColor(); // Reset console colors

        Console.WriteLine("------------------------------");
    }

    // Method to reset the recipe by restoring ingredient quantities to their original values
    public void ResetRecipe()
    {
        // Reset ingredient quantities to their original values
        for (int i = 0; i < ingredientCount; i++)
        {
            ingredients[i].Quantity = ingredients[i].OriginalQuantity;
        }
    }
    // Method to clear the recipe
    public void ClearRecipe()
    {
        Console.WriteLine("Are you sure you want to clear the recipe? (\u001b[32myes\u001b[39m/\u001b[31mno\u001b[39m)"); // Set green for "yes" and red for "no"
        string input = Console.ReadLine().ToLower();

        if (input == "yes")
        {
            Array.Clear(ingredients, 0, ingredients.Length);
            Array.Clear(steps, 0, steps.Length);
            ingredientCount = 0;
            stepCount = 0;
            Console.WriteLine("Recipe cleared successfully!");

        }
        else if (input == "no")
        {
            Console.WriteLine("Clearing operation cancelled.");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
        }
    }

    }
}