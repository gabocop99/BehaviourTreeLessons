using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "HasTarget", story: "Has [Target]", category: "Action", id: "063bde08d368c0b890d3b7595117c07f")]
public partial class HasTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<Transform> Target;

    protected override Status OnStart()
    {
        return Target.Value != null ? Status.Success : Status.Failure;
    }
}