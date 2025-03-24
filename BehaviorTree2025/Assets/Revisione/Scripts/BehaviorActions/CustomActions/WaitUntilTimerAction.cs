using System;
using Revisione.Scripts.Agents;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

namespace Revisione.Scripts.BehaviorActions.CustomActions
{
    [Serializable, GeneratePropertyBag]
    [NodeDescription(name: "WaitUntilTimer",
        story: "[Self] stays idle until [IdleTime] seconds elapsed then resets [IsIdle]", category: "Action",
        id: "9e192de96cf00344a6f8e2c349ea3642")]
    public partial class WaitUntilTimerAction : Action
    {
        [SerializeReference] public BlackboardVariable<GameObject> Self;
        [SerializeReference] public BlackboardVariable<float> IdleTime;
        [SerializeReference] public BlackboardVariable<bool> IsIdle;

        protected override Status OnStart()
        {
            if (!Self.Value.TryGetComponent<Agent>(out var agent))
            {
                Debug.LogError("[WaitUntilTimerAction] Agent is null");
                return Status.Failure;
            }

            if (IdleTime.Value >= agent.IdleTime)
            {
                IdleTime.Value = 0f;
                agent.IsIdle = false;
                IsIdle.Value = false;
                return Status.Failure;
            }

            IdleTime.Value += Time.deltaTime;
            return Status.Success;
        }
    }
}