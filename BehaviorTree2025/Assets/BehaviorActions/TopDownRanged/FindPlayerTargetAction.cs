using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using Object = UnityEngine.Object;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "FindPlayerTarget", story: "Find Player [Target]", category: "Action",
    id: "b85d1c4c9f4536d29193c7e457285d1f")]
public partial class FindPlayerTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<Transform> Target;

    protected override Status OnStart()
    {
        var target = Object.FindFirstObjectByType<TopDownController>();
        if (target == null)
        {
            return Status.Failure;
        }

        Target.Value = target.transform;
        return Target.Value != null ? Status.Success : Status.Failure;
    }
}