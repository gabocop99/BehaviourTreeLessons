using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "DecrementFloatByDeltaTime", story: "Decrement [Float] by TimeDeltaTime", category: "Action", id: "e34a95a77ae622eb8d458b73f9d124dc")]
public partial class DecrementFloatByDeltaTimeAction : Action
{
    [SerializeReference] public BlackboardVariable<float> Float;

    protected override Status OnStart()
    {
        Float.Value -= Time.deltaTime;
        return Status.Success; 
    }
}

