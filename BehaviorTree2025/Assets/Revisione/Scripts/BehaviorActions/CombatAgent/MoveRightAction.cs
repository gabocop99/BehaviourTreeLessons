using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "MoveRight", story: "Move [Self] to the right", category: "Action",
    id: "055fa2ad47da2c2e084a40757424ddc6")]
public partial class MoveRightAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;

    protected override Status OnStart()
    {
        if (!Self.Value.TryGetComponent<EnemyShooter>(out var shooter))
        {
            return Status.Failure;
        }

        Self.Value.transform.position += Self.Value.transform.right * shooter.MovementSpeed * Time.deltaTime;

        return Status.Success;
    }
}