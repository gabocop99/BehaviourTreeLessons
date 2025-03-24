using System;
using System.Collections;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Set Bool After Time", story: "Wait for [Seconds] to set [Boolean] to [Bool]", category: "Action", id: "9cc4f6962982087059dd4f03f25d194f")]
public partial class WaitForTimeAction : Action
{
    [SerializeReference] public BlackboardVariable<float> Seconds;
    private float _currentTime;
    [SerializeReference] public BlackboardVariable<bool> Boolean;
    [SerializeReference] public BlackboardVariable<bool> Bool;
    protected override Status OnStart()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= Seconds.Value)
        {
            Debug.Log("Can Shoot");
            Boolean.Value = Bool.Value;
            return Status.Success;
        }
        return Status.Running;
    }


    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

