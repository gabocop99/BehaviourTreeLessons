using System;
using UnityEngine;

public class CraftingBenchStatus : MonoBehaviour
{
    public static CraftingBenchStatus Instance;

    public event Action<Recipe> OnRecipeChanged;

    private Recipe _currentRecipe;

    public Recipe CurrentRecipe
    {
        get { return _currentRecipe; }
        set
        {
            OnRecipeChanged?.Invoke(value);
            _currentRecipe = value;
        }
    }

    public int CurrentWood;
    public int CurrentMetal;
    public int CurrentCloth;

    private void Awake()
    {
        Instance = this;
    }

    public bool HasAllMaterials()
    {
        if (CurrentRecipe == null)
        {
            return false;
        }

        return CurrentWood > CurrentRecipe.WoodRequired &&
               CurrentMetal > CurrentRecipe.MetalRequired &&
               CurrentCloth > CurrentRecipe.ClotRequired;
    }

    [ContextMenu("RecipeDelivered")]
    public void RecipeDelivered()
    {
        CurrentRecipe = null;
    }
}