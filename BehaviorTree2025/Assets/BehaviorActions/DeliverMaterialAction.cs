using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "DeliverMaterial", story: "Deliver [Material]", category: "Action", id: "88ce638ed54b80794c913c092ea1150c")]
public partial class DeliverMaterialAction : Action
{
    [SerializeReference] public BlackboardVariable<Material> Material;

    protected override Status OnStart()
    {
        switch (Material.Value)
        {
            case global::Material.Wood:
                CraftingBenchStatus.CurrentWood++;
                break;
            case global::Material.Metal:
                CraftingBenchStatus.CurrentMetal++;
                break;
            case global::Material.Cloth:
                CraftingBenchStatus.CurrentCloth++;
                break;
        }
        Material.Value = global::Material.None;
        return Status.Success;
    }
}

