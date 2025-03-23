using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "IsTargetInRange", story: "Is [Target] in [Self] range", category: "Action",
    id: "f9b5c811c7818a6ad1ab70d21102fe15")]
public partial class IsTargetInRangeAction : Action
{
    [SerializeReference] public BlackboardVariable<Transform> Target;
    [SerializeReference] public BlackboardVariable<GameObject> Self;

    protected override Status OnStart()
    {
        if (!Self.Value.TryGetComponent(out TopDownEnemy topDownEnemy))
        {
            return Status.Failure;
        }

        var minRange = topDownEnemy.Range.x;
        var maxRange = topDownEnemy.Range.y;

        var distance = Vector3.Distance(Target.Value.position, Self.Value.transform.position);
        return distance > minRange && distance < maxRange ? Status.Success : Status.Failure;
    }
}