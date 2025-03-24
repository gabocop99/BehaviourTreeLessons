using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "IsTransformNull", story: "Is [Transform] null", category: "Action/Transform",
    id: "85cb123a69cb71dd18db46a92248ddc3")]
public partial class IsTransformNullAction : Action
{
    [SerializeReference] public BlackboardVariable<Transform> Transform;

    protected override Status OnStart()
    {
        return Transform.Value == null ? Status.Success : Status.Failure;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}