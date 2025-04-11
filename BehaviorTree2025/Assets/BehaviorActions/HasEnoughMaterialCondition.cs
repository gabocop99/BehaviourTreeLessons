using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "HasEnoughMaterial", story: "Has enough [Material]", category: "Conditions", id: "59af953d26faf355f85ef634df7af552")]
public partial class HasEnoughMaterialCondition : Condition
{
    [SerializeReference] public BlackboardVariable<Material> Material;

    public override bool IsTrue()
    {
        switch (Material.Value)
        {
            case global::Material.Wood:
                return !CraftingBenchStatus.IsMissingWood();
            case global::Material.Metal:
                return !CraftingBenchStatus.IsMissingMetal();
            case global::Material.Cloth:
                return !CraftingBenchStatus.IsMissingCloth();
        }
        return true;
    }
}
