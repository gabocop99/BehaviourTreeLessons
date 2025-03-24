using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Shoot", story: "[Agent] Shoots", category: "Action", id: "b67ab91dede0251970294420c7efbf95")]
public partial class ShootAction : Action
{
    [SerializeReference] public BlackboardVariable<Transform> Agent;
    private float _currentTime;
    protected override Status OnStart()
    {
        Debug.Log("Shoot");
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

