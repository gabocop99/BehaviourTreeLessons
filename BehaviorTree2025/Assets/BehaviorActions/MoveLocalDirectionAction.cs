using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using static UnityEngine.Rendering.DebugUI;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "MoveLocalDirection", story: "Move towards local [Direction] by [Speed]", category: "Action", id: "1b613dd6eda9238585247cf261e32cf0")]
public partial class MoveLocalDirectionAction : Action
{
    [SerializeReference] public BlackboardVariable<Vector3> Direction;
    [SerializeReference] public BlackboardVariable<float> Speed;

    protected override Status OnStart()
    {
        var transform = GameObject.transform;
        var localDirection = 
            transform.right * Direction.Value.x +
            transform.up * Direction.Value.y +
            transform.forward * Direction.Value.z;
        transform.position += localDirection * Speed * Time.deltaTime;
        return Status.Success;
    }
}

