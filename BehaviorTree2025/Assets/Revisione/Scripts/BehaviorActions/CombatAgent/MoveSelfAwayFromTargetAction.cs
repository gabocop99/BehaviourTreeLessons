using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "MoveSelfAwayFromTarget", story: "Move [Self] Away From [Target] by enemy speed",
    category: "Action", id: "1863a9c6bbe3692cdaf9a468e26f29bb")]
public partial class MoveSelfAwayFromTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<Transform> Target;

    protected override Status OnStart()
    {
        if (!Self.Value.TryGetComponent<EnemyShooter>(out var shooter))
        {
            return Status.Failure;
        }

        var direction = Self.Value.transform.position - Target.Value.position;
        direction.Normalize();
        Self.Value.transform.position += direction * shooter.MovementSpeed * Time.deltaTime;

        return Status.Success;
    }
}