using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SteerToDirection", story: "Rotate [Self] towards [Direction]", category: "Action", id: "d382c8ad52def30993e91f6dac638657")]
public partial class SteerToDirectionAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<Vector3> Direction;

    protected override Status OnStart()
    {
        if (!Self.Value.TryGetComponent<Car>(out var car))
        {
            return Status.Failure;
        }

        var angleDifference = Vector3.SignedAngle(car.Direction, Direction.Value, Vector3.up);
        var frameSpeed = car.AngularSpeed * Time.deltaTime * Mathf.Sign(angleDifference);
        frameSpeed = Mathf.Min(frameSpeed, angleDifference);
        car.Direction = Quaternion.AngleAxis(frameSpeed, Vector3.up) * car.Direction; 

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

