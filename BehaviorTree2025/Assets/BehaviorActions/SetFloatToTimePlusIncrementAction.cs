using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SetFloatToTimePlusIncrement", story: "Set [Float] to Time plus [Increment]", category: "Action", id: "b6b29d04cfc4bea00ae196db3b0524dc")]
public partial class SetFloatToTimePlusIncrementAction : Action
{
    [SerializeReference] public BlackboardVariable<float> Float;
    [SerializeReference] public BlackboardVariable<float> Increment;

    protected override Status OnStart()
    {
        Float.Value = Time.time + Increment.Value;
        return Status.Success;
    }
}

