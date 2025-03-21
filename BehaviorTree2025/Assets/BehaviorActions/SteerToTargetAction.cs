using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SteerToTarget", story: "Rotate [Self] towards [Target]", category: "Action", id: "d382c8ad72def30993e91f6dac638657")]
public partial class SteerToTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<Transform> Target;

    protected override Status OnStart()
    {
        if (!Self.Value.TryGetComponent<Car>(out var car))
        {
            return Status.Failure;
        }
        var direction = (Target.Value.position - Self.Value.transform.position).normalized;
        var angleDifference = Vector3.SignedAngle(car.Direction, direction, Vector3.up);
        var frameSpeed = car.AngularSpeed * Time.deltaTime * Mathf.Sign(angleDifference);
        frameSpeed = Mathf.Min(frameSpeed, angleDifference);
        car.Direction = Quaternion.AngleAxis(frameSpeed, Vector3.up) * car.Direction; 

        return Status.Success;
    }
}

