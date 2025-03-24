using UnityEngine;

public class CrafterAgentController : MonoBehaviour
{
    public Recipe CurrentRecipe;
    public bool IsBusy;

    private void Start()
    {
        CraftingBenchStatus.Instance.OnRecipeChanged += HandleRecipeChanged;
    }

    private void HandleRecipeChanged(Recipe recipe)
    {
        IsBusy = recipe != null;
        CurrentRecipe = recipe;
    }
}