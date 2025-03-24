using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ResetFloat", story: "Reset [Value]", category: "Action",
    id: "8e38e78637d47c67223b040824182b01")]
public partial class ResetFloatAction : Action
{
    [SerializeReference] public BlackboardVariable<float> Value;

    protected override Status OnStart()
    {
        Value.Value = 0;
        return Status.Success;
    }
}