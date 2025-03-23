using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "RotateAroundTarget", story: "Rotate [Self] around [Target]", category: "Action", id: "9f36eca864d103f55d60925b6995d29c")]
public partial class RotateAroundTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<Transform> Target;
    protected override Status OnStart()
    {
        Self.Value.transform.LookAt(Target.Value);
        Self.Value.transform.position += Self.Value.transform.right * 3 * Time.deltaTime;
        
        return Status.Success;
    }

}

