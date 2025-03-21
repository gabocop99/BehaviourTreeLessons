using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ManageSpeed", story: "[Self] Accelerates [DoesAccelerate] ?", category: "Action", id: "26d93dec2849f464fafcd29b04dc6620")]
public partial class ManageSpeedAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<bool> DoesAccelerate;

    protected override Status OnStart()
    {
        if (!Self.Value.TryGetComponent<Car>(out var car))
        {
            return Status.Failure;
        }

        var delta = DoesAccelerate.Value ? car.Acceleration : car.Deceleration;
        car.Speed += delta * Time.deltaTime;

        return Status.Success;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

