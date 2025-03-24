using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "StrifeAction", story: "[Agent] Moves Strife", category: "Action",
    id: "4c33c3227edd942b6ce4cc9863e44bce")]
public partial class StrifeAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;

    protected override Status OnStart()
    {
        Agent.Value.transform.Translate(Vector3.right * 5 * Time.deltaTime);
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