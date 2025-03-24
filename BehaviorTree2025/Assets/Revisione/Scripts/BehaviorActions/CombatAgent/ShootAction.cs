using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Shoot", story: "[Self] Shoot forward", category: "Action", id: "943090c9b292723e38d76d35c81ddf74")]
public partial class ShootAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;

    protected override Status OnStart()
    {
        if (!Self.Value.TryGetComponent(out EnemyShooter shooter))
        {
            return Status.Failure;
        }
        
        shooter.Shoot();
        return Status.Running;
    }
}

