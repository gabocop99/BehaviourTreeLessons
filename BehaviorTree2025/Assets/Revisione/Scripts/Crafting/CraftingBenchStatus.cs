using UnityEngine;

namespace Revisione.Scripts.Crafting
{
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
                   CurrentCloth >= CurrentRecipe.ClothRequired;
        }

        public static void RecipeDelivered()
        {
            CurrentRecipe = null;
        }

        public static bool HasEnoughMaterial(string material)
        {
            switch (material)
            {
                case "Wood":
                    return CurrentWood >= CurrentRecipe.WoodRequired;
                case "Metal":
                    return CurrentMetal >= CurrentRecipe.MetalRequired;
                case "Cloth":
                    return CurrentCloth >= CurrentRecipe.ClothRequired;
                default:
                    Debug.Log("Invalid material");
                    return false;
            }
        }
    }
}