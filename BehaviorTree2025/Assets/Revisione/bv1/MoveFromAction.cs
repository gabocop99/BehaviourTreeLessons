using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "MoveFrom", story: "Move [Agent] away from [Target] by [Speed]", category: "Action", id: "2433e6f902b252aeed2b62bfebc5d37b")]
public partial class MoveFromAction : Action
{
    [SerializeReference] public BlackboardVariable<Transform> Agent;
    [SerializeReference] public BlackboardVariable<Transform> Target;
    [SerializeReference] public BlackboardVariable<float> Speed;

    protected override Status OnStart()
    {
        var distance = Agent.Value.position - Target.Value.position;
        var magnitude = Mathf.Min(Time.deltaTime * Speed.Value, distance.magnitude);
        Agent.Value.position += magnitude * distance.normalized;
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

