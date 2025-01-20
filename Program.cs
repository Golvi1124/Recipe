namespace Recipe;

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
        Console.Write("Do you want the recipe in Metric (m) or US measurements (u)? Enter 'm' or 'u': ");
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

class Ingredient
{
    public string Name { get; set; }
    public double Quantity { get; set; }
    public string MetricUnit { get; set; }
    public string USUnit { get; set; }
    public double ConversionFactor { get; set; } // Conversion factor for Metric to US
    public bool NoConversion { get; set; } //for when no conversion needed

    public Ingredient(string name, double quantity, string metricUnit, string usUnit, double conversionFactor, bool noConversion = false)
    {
        Name = name;
        Quantity = quantity;
        MetricUnit = metricUnit;
        USUnit = usUnit;
        ConversionFactor = conversionFactor;
        NoConversion = noConversion;
    }

    //Method to display in metric or US units
    public string ToString(bool useMetric)
    {
        if (NoConversion)
        {
            return $"{Quantity} {USUnit} {Name}";
        }
        if (useMetric)
        {
            return $"{Quantity} {MetricUnit} {Name}";
        }
        else
        {
            return $"{Quantity * ConversionFactor:F2} {USUnit} {Name}";
        }
    }

}

class Recipe
{
    private List<Ingredient> Ingredients { get; } = new List<Ingredient>
    {
        new Ingredient("macaroni", 226.8, "g", "lb", 0.002205),
        new Ingredient("butter", 3, "tbsp", "tbsp", 1, true),
        new Ingredient("all-purpose four", 2, "tbsp", "tbsp", 1, true),
        new Ingredient("salt", 0.5, "tsp", "tsp", 1, true),
        new Ingredient("ground black pepper", 0.125, "tsp", "tsp", 1, true),
        new Ingredient("milk, any kind", 358, "ml", "cups", 0.00423),
        new Ingredient("half and half", 181.5, "g", "cups", 0.00423),
        new Ingredient("shredded cheddar cheese", 282.5, "g", "cups", 0.008818)
    };

    //Adjust recipe for the given number of servings
    public void ScaleRecipe(int servings)
    {
        foreach (var ingredient in Ingredients)
        {
            ingredient.Quantity *= servings;
        }
    }

    //Display the recipe
    public void DisplayRecipe(bool useMetric)
    {
        foreach (var ingredient in Ingredients)
        {
            Console.WriteLine(ingredient.ToString(useMetric));
        }
    }
}