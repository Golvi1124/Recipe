namespace Recipe;
using Recipe.Extras;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\nWelcome to measurement converter for Mac and Cheese");
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine("For how many persons are you planning to cook?");
        string? servingsInput = Console.ReadLine();

        // Validate and parse the input
        if (!int.TryParse(servingsInput, out int servings) || servings <= 0)
        {
            Console.WriteLine("Invalid input. Defaulting to 1 serving.");
            servings = 1; // Default value
        }

       // Ask the user for the measurement system
        Console.WriteLine("Do you want the recipe in Metric (m) or US measurements (u)? Enter 'm' or 'u': ");
        string? measurementChoice = Console.ReadLine()?.ToLower();

        if (measurementChoice is not ("m" or "u"))
        {
            Console.WriteLine("Invalid input. Defaulting to Metric system.");
            measurementChoice = "m"; // Default value
        }

        bool useMetric = measurementChoice == "m";

        //Create the recipe
        Recipe recipe= new Recipe();

        //Scale the recipe
        recipe.ScaleRecipe(servings);

        // Display the recipe
        Console.WriteLine($"\nRecipe for {servings} person/-s in {(useMetric ? "Metric" : "US")} system:");
        recipe.DisplayRecipe(useMetric);
    }
}