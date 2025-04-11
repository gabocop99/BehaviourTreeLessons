public static class CraftingBenchStatus
{
    public static Recipe CurrentRecipe;

    public static int CurrentWood;
    public static int CurrentMetal;
    public static int CurrentCloth;

    public static bool HasAllMaterials()
    {
        if (CurrentRecipe == null)
        {
            return false;
        }
        return CurrentWood >= CurrentRecipe.WoodRequired &&
               CurrentMetal >= CurrentRecipe.MetalRequired &&
               CurrentCloth >= CurrentRecipe.ClotRequired;
    }

    public static bool IsMissingWood()
    {
        if (CurrentRecipe == null)
        {
            return false;
        }
        return CurrentWood < CurrentRecipe.WoodRequired;
    }

    public static bool IsMissingMetal()
    {
        if (CurrentRecipe == null)
        {
            return false;
        }
        return CurrentMetal < CurrentRecipe.MetalRequired;
    }

    public static bool IsMissingCloth()
    {
        if (CurrentRecipe == null)
        {
            return false;
        }
        return CurrentCloth < CurrentRecipe.ClotRequired;
    }

    public static void RecipeDelivered()
    {
        CurrentRecipe = null;
        CurrentCloth = 0;
        CurrentMetal = 0;
        CurrentWood = 0;
    }
}
