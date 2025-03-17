using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ChangeObjectMaterial", story: "Change [Target] Material To: [Material]", category: "Action", id: "aaeae7fca7c1c9f0d0e04db06f52e4f8")]
public partial class ChangeObjectMaterialAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    [SerializeReference] public BlackboardVariable<Material> Material;

    protected override Status OnStart()
    {
        ChangeMaterial();
        return Status.Success;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }

    private void ChangeMaterial()
    {
        Target.Value.GetComponent<Renderer>().material = Material.Value;
    }
}

