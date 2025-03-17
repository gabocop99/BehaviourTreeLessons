using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "MoveTowards", story: "Move [Agent] towards [Target] by [UnitPerSecond]", category: "Action/Transform", id: "ad7a6ceb8e97fbb45d3c9fc0317719b2")]
public partial class MoveTowardsAction : Action
{
    [SerializeReference] public BlackboardVariable<Transform> Agent;
    [SerializeReference] public BlackboardVariable<Transform> Target;
    [SerializeReference] public BlackboardVariable<float> UnitPerSecond;

    protected override Status OnStart()
    {
        var distance = Target.Value.position - Agent.Value.position;
        var magnitude = Mathf.Min(Time.deltaTime * UnitPerSecond.Value, distance.magnitude);
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

