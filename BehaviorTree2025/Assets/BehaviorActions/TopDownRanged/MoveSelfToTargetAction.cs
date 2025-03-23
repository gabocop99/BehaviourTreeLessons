using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "MoveSelfToTarget", story: "Move [Self] to [Target] [checkMoveTowards]", category: "Action",
    id: "fe3fb18918a6905aefca478f934c17cf")]
public partial class MoveSelfToTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<Transform> Target;
    [SerializeReference] public BlackboardVariable<bool> CheckMoveTowards;

    protected override Status OnStart()
    {
        if (!Self.Value.TryGetComponent(out TopDownEnemy self))
        {
            return Status.Failure;
        }

        if (CheckMoveTowards.Value)
        {
            Self.Value.transform.LookAt(Target.Value.position, Vector3.up);
            Self.Value.transform.position += Self.Value.transform.forward * self.Speed * Time.deltaTime;
            return Status.Success;
        }

        var direction = Self.Value.transform.position - Target.Value.position;
        direction.Normalize();
        Self.Value.transform.position += direction * self.Speed * Time.deltaTime;
        return Status.Success;
    }
}