using System;
using Revisione.Scripts.Agents;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

namespace Revisione.Scripts.BehaviorActions.CustomActions
{
    [Serializable, GeneratePropertyBag]
    [NodeDescription(name: "Shoot", story: "[Self] shoots at Target , resets [Timer] and sets [IsIdle]", category: "Action", id: "51d6159b311f43832a3297a280c953ca")]
    public partial class ShootAction : Action
    {
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<float> Timer;
    [SerializeReference] public BlackboardVariable<bool> IsIdle;
        protected override Status OnStart()
        {
            if (!Self.Value.TryGetComponent<Agent>(out var agent))
            {
                Debug.LogError("[ShootAction] Agent is null");
                return Status.Failure;
            }

            Timer.Value = 0f;
            Debug.Log("Shoot");
            IsIdle.Value = true;
            agent.IsIdle = true;
            return Status.Success;
        }
    }
}