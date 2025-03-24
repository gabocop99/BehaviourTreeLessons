using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "FindTarget", story: "Find [Target]", category: "Action",
    id: "341b22accbf20b3efe3d43fa35ef78ed")]
public partial class FindTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<Transform> Target;

    protected override Status OnStart()
    {
        var player = UnityEngine.Object.FindFirstObjectByType<PlayerController>();

        if (player == null)
        {
            Debug.Log("No player found");
            return Status.Failure;
        }

        Target.Value = player.transform;
        return Target.Value != null ? Status.Success : Status.Failure;
    }
}