using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SetCurrentRecipe", story: "Set [CurrentRecipe]", category: "Action", id: "676f64b216e6df148775e273aaa6660b")]
public partial class SetCurrentRecipeFromScriptAction : Action
{

    [SerializeReference] public BlackboardVariable<string> Recipe;
    protected override Status OnStart()
    {
        if (CraftingBenchStatus.CurrentRecipe == null)
        {
            Debug.Log("No CurrentRecipe assigned");
            return Status.Failure;
        }
        Recipe.Value = CraftingBenchStatus.CurrentRecipe.ToString();
        Debug.Log($"CurrentRecipe");
        return Status.Success;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

