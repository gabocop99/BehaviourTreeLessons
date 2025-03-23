using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;


[Serializable, GeneratePropertyBag]
[NodeDescription(name: "IsTargetOutOfRange", story: "Is [Target] out of [Self] range [checkTooClose]",
    category: "Action", id: "ee6db3cac67607b0d2f5eac80b8bf318")]
public partial class IsTargetOutOfRange : Action
{
    [SerializeReference] public BlackboardVariable<Transform> Target;
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<bool> CheckTooClose;

    protected override Status OnStart()
    {
        if (!Self.Value.TryGetComponent<TopDownEnemy>(out var enemy))
        {
            return Status.Failure;
        }
        
        var distance = Vector3.Distance(Target.Value.position, Self.Value.transform.position);

        if (CheckTooClose.Value)
        {
            return distance < enemy.Range.x ? Status.Success : Status.Failure;
        }
        
        return distance > enemy.Range.y ? Status.Success : Status.Failure;
    }
}