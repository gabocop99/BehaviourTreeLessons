using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "HasRecipe", story: "Has Recipe", category: "Conditions", id: "2b28e61de39531303db541a4048afe42")]
public partial class HasRecipeCondition : Condition
{

    public override bool IsTrue()
    {
        return CraftingBenchStatus.CurrentRecipe != null;
    }
}
