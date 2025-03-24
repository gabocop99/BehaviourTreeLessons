using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "MoveSelfTowardsTarget", story: "Move [Self] towards [Target] by enemy speed",
    category: "Action", id: "8e2ccde3b001a3efe9de70b288321672")]
public partial class MoveSelfTowardsTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<Transform> Target;

    protected override Status OnStart()
    {
        if (!Self.Value.TryGetComponent<EnemyShooter>(out var shooter))
        {
            return Status.Failure;
        }

        var distance = Target.Value.position - Self.Value.transform.position;
        var magnitude = Mathf.Min(Time.deltaTime * shooter.MovementSpeed, distance.magnitude);
        Self.Value.transform.position += magnitude * distance.normalized;

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