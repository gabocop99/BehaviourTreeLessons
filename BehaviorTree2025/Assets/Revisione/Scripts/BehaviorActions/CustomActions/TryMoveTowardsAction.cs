using System;
using Revisione.Scripts.Agents;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

namespace Revisione.Scripts.BehaviorActions.CustomActions
{
    [Serializable, GeneratePropertyBag]
    [NodeDescription(name: "TryMoveTowards", story: "[Self] tries to move to [Target]", category: "Action",
        id: "4e5ef58c07f29a84aba79650a755ca9c")]
    public partial class TryMoveTowardsAction : Action
    {
        [SerializeReference] public BlackboardVariable<GameObject> Self;
        [SerializeReference] public BlackboardVariable<Transform> Target;

        protected override Status OnStart()
        {
            if (!Self.Value.TryGetComponent<CombatAgent>(out var agent))
            {
                Debug.LogError("[TryMoveAction] Agent is null");
                return Status.Failure;
            }

            var distance = Vector3.Distance(Self.Value.transform.position, Target.Value.transform.position);

            if (distance > agent.MaxRange)
            {
                // Self.Value.transform.position = Vector3.MoveTowards(Self.Value.transform.position,
                //     Target.Value.position, agent.Speed * Time.deltaTime);

                var direction = Target.Value.transform.position - agent.transform.position;
                var magnitude = Mathf.Min(Time.deltaTime * agent.Speed, direction.magnitude);
                Self.Value.transform.position += magnitude * direction.normalized;

                return Status.Success;
            }

            return Status.Failure;
        }
    }
}