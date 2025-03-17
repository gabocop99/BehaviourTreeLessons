using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "GetDirectionBetween", story: "Sets the [Direction] from [A] to [B]", category: "Action", id: "e4be88686afe3c5fe62195b4bc71f088")]
public partial class GetDirectionBetweenAction : Action
{
    [SerializeReference] public BlackboardVariable<Vector3> Direction;
    [SerializeReference] public BlackboardVariable<Transform> A;
    [SerializeReference] public BlackboardVariable<Transform> B;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Direction.Value = (B.Value.position - A.Value.position).normalized;
        return Status.Success;
    }

    protected override void OnEnd()
    {       
    }
}

