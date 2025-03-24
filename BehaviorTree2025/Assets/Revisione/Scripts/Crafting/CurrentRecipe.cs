using Revisione.Scripts.Crafting;

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
        return CurrentWood > CurrentRecipe.WoodRequired &&
               CurrentMetal > CurrentRecipe.MetalRequired &&
               CurrentCloth > CurrentRecipe.ClotRequired;
    }
    
    public static void RecipeDelivered()
    {
        CurrentRecipe = null;
    }
}
