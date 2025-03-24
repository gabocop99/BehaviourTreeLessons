using System;
using Revisione.Scripts.Agents;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

namespace Revisione.Scripts.BehaviorActions.CustomActions
{
    [Serializable, GeneratePropertyBag]
    [NodeDescription(name: "Check distance", story: "Checks [Distance] between [Self] and [Target]", category: "Action",
        id: "2c749044ee2e481dcdb79d4d5c90717f")]
    public partial class CheckDistanceAction : Action
    {
        [SerializeReference] public BlackboardVariable<GameObject> Self;
        [SerializeReference] public BlackboardVariable<Transform> Target;
        [SerializeReference] public BlackboardVariable<float> Distance;

        protected override Status OnStart()
        {
            if (!Self.Value.TryGetComponent<CombatAgent>(out var agentData))
            {
                Debug.LogError("[CheckDistanceAction] Agent is null");
                return Status.Failure;
            }

            var minRange = agentData.MinRange;
            var maxRange = agentData.MaxRange;

            Distance.Value = Vector3.Distance(Target.Value.position, Self.Value.transform.position);


            return Status.Success;
        }
    }
}