namespace Recipe.Extras;

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