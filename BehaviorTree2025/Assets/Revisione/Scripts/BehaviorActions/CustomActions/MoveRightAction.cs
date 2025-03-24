using System;
using Revisione.Scripts.Agents;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

namespace Revisione.Scripts.BehaviorActions.CustomActions
{
    [Serializable, GeneratePropertyBag]
    [NodeDescription(name: "MoveRight", story: "Moves [Self] right and adds time to [Timer]", category: "Action",
        id: "680c50435187b9b2cd075ec141b01268")]
    public partial class MoveRightAction : Action
    {
        [SerializeReference] public BlackboardVariable<GameObject> Self;
        [SerializeReference] public BlackboardVariable<float> Timer;

        protected override Status OnStart()
        {
            if (!Self.Value.TryGetComponent<CombatAgent>(out var agent))
            {
                Debug.LogError("[TryMoveAwayAction] Agent is null");
                return Status.Failure;
            }

            if (Timer.Value >= agent.ShootInterval)
            {
                return Status.Failure;
            }

            Timer.Value += Time.deltaTime;
            Self.Value.transform.position += Self.Value.transform.right * agent.Speed * Time.deltaTime;
            return Status.Success;
        }
    }
}