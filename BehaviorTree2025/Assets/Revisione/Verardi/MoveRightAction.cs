using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "MoveRight", story: "[Agent] Move To Right at [Speed] looking at [Target]", category: "Action", id: "fb5ac132588042e27c0cbc98786af579")]
public partial class MoveRightAction : Action
{
    [SerializeReference] public BlackboardVariable<Transform> Agent;
    [SerializeReference] public BlackboardVariable<float> Speed;
    [SerializeReference] public BlackboardVariable<Transform> Target;

    protected override Status OnStart()
    {        
        Agent.Value.transform.LookAt(Target.Value);
        Agent.Value.position += Agent.Value.right * Speed.Value * Time.deltaTime;
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

