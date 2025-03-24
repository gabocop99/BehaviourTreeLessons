using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Set Int from Script", story: "Set [Int] from Script", category: "Action", id: "bd2c45ddda58b25c31b45298951a94a6")]
public partial class SetIntFromScriptAction : Action
{
    [SerializeReference] public BlackboardVariable<int> Int;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

