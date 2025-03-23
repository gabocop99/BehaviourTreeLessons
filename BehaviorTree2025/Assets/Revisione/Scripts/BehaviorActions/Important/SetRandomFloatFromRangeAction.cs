using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SetRandomFloatFromRange", story: "Pick [Float] from [Min] to [Max]", category: "Action", id: "6f4791c8bdc61e3373b4385d39f6ec6e")]
public partial class SetRandomFloatFromRangeAction : Action
{
    [SerializeReference] public BlackboardVariable<float> Float;
    [SerializeReference] public BlackboardVariable<float> Min;
    [SerializeReference] public BlackboardVariable<float> Max;

    protected override Status OnStart()
    {
        Float.Value = UnityEngine.Random.Range(Min.Value, Max.Value);
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

