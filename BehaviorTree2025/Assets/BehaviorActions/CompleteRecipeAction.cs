using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "CompleteRecipe", story: "Complete recipe", category: "Action", id: "0952cf51bd5d1f9dcaff43449c100781")]
public partial class CompleteRecipeAction : Action
{
    protected override Status OnStart()
    {
        CraftingBenchStatus.RecipeDelivered();
        return Status.Success;
    }
}

