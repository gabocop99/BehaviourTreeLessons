using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "HasTarget", story: "Is [Target] null", category: "Action", id: "e6ba9c539ae9d2b7dd40a7dba6fa1bb6")]
public partial class HasTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<Transform> Target;

    protected override Status OnStart()
    {
        return Target.Value != null ? Status.Failure : Status.Success;
    }
}