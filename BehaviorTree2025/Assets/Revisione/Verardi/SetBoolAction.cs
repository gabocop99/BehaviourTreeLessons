using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Set Bool", story: "Set [Boolean] to [Bool]", category: "Action", id: "b3a12f10464cbf90e2f950d9e171589f")]
public partial class SetBoolAction : Action
{
    [SerializeReference] public BlackboardVariable<bool> Boolean;
    [SerializeReference] public BlackboardVariable<bool> Bool;

    protected override Status OnStart()
    {
        Boolean.Value = Bool.Value;
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

