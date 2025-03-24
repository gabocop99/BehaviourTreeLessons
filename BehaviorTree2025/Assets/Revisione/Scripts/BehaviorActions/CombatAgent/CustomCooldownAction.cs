using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "CustomCooldown", story: "Coolsdown for seconds [seconds] fr", category: "Action", id: "5cbd21d42cc5c3f11dd2922b33919b0e")]
public partial class CustomCooldownAction : Action
{
    [SerializeReference] public BlackboardVariable<float> Seconds;
    
    [CreateProperty] private float m_CooldownRemainingTime;
    private float m_CooldownEndTime;
    private float m_CooldownTime;

    protected override Status OnStart()
    {
        m_CooldownEndTime = Time.time + Seconds.Value - m_CooldownRemainingTime;
        
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

