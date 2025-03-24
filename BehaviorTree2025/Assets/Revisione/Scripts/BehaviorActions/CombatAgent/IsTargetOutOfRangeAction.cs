using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "IsTargetOutOfRange", story: "Is [Target] out of [Self] range, [checkIfTooClose]",
    category: "Action", id: "f40e271f86bdf9d9acb9e7e014d8bae2")]
public partial class IsTargetOutOfRangeAction : Action
{
    [SerializeReference] public BlackboardVariable<Transform> Target;
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<bool> CheckIfTooClose;

    protected override Status OnStart()
    {
        if (!Self.Value.TryGetComponent<EnemyShooter>(out var shooter))
        {
            return Status.Failure;
        }

        var distance = Vector3.Distance(Target.Value.transform.position, Self.Value.transform.position);

        if (CheckIfTooClose.Value)
        {
            return distance < shooter.Range.x ? Status.Success : Status.Failure;
        }

        return distance > shooter.Range.y ? Status.Success : Status.Failure;
    }
}