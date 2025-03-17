using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Mod", story: "Save in [Result] the operation: [A] % [B]", category: "Action/Math", id: "91e6812d5305a15020368ecaf7061d02")]
public partial class ModAction : Action
{
    [SerializeReference] public BlackboardVariable<float> Result;
    [SerializeReference] public BlackboardVariable<float> A;
    [SerializeReference] public BlackboardVariable<float> B;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Result.Value = A.Value % B.Value;
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

