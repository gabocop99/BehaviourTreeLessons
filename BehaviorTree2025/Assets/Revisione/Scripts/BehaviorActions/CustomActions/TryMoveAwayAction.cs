using System;
using Revisione.Scripts.Agents;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

namespace Revisione.Scripts.BehaviorActions.CustomActions
{
    [Serializable, GeneratePropertyBag]
    [NodeDescription(name: "TryMoveAway", story: "[Self] tries to move away from [Target]",
        category: "Action/Transform",
        id: "04f3c36481d5b3d937adc0c897b7931f")]
    public partial class TryMoveAwayAction : Action
    {
        [SerializeReference] public BlackboardVariable<GameObject> Self;
        [SerializeReference] public BlackboardVariable<Transform> Target;

        protected override Status OnStart()
        {
            if (!Self.Value.TryGetComponent<Agent>(out var agent))
            {
                Debug.LogError("[TryMoveAwayAction] Agent is null");
                return Status.Failure;
            }

            var distance = Vector3.Distance(Self.Value.transform.position, Target.Value.transform.position);

            if (distance < agent.MinRange)
            {
                // Self.Value.transform.position = Vector3.MoveTowards(Self.Value.transform.position,
                //     -Target.Value.position, agentData.Speed * Time.deltaTime);

                var direction = Target.Value.transform.position - agent.transform.position;
                var magnitude = Mathf.Min(Time.deltaTime * agent.Speed, direction.magnitude);
                Self.Value.transform.position += magnitude * -direction.normalized;

                return Status.Success;
            }

            return Status.Failure;
        }
    }
}