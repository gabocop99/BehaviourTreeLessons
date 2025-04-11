using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "GetMissingMaterial", story: "Get missing [Material]", category: "Action", id: "d6530691f5f97ea6da92a4e4975ab4b8")]
public partial class GetMissingMaterialAction : Action
{
    [SerializeReference] public BlackboardVariable<Material> Material;

    protected override Status OnStart()
    {
        if (CraftingBenchStatus.IsMissingWood())
        {
            Material.Value = global::Material.Wood;
            return Status.Success;
        }
        if (CraftingBenchStatus.IsMissingMetal())
        {
            Material.Value = global::Material.Metal;
            return Status.Success;
        }
        if (CraftingBenchStatus.IsMissingCloth())
        {
            Material.Value = global::Material.Cloth;
            return Status.Success;
        }
        return Status.Success;
    }
}

