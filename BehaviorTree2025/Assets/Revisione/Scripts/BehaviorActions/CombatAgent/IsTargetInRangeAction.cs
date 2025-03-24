using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "IsTargetInRange", story: "Is [Target] in [Self] Range", category: "Action",
    id: "adb5f7b6f1a07388bf83756822e388f5")]
public partial class IsTargetInRangeAction : Action
{
    [SerializeReference] public BlackboardVariable<Transform> Target;
    [SerializeReference] public BlackboardVariable<GameObject> Self;

    protected override Status OnStart()
    {
        if (!Self.Value.TryGetComponent<EnemyShooter>(out var shooter))
        {
            return Status.Failure;
        }
    
        var distance = Vector3.Distance(Target.Value.transform.position, Self.Value.transform.position);
        return distance > shooter.Range.x && distance < shooter.Range.y ? Status.Success : Status.Failure;
    }
}