using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

namespace Revisione.Scripts.BehaviorActions.CustomActions
{
    [Serializable, GeneratePropertyBag]
    [NodeDescription(name: "CompareTransformToNull", story: "Compares [Transform] to Null", category: "Action",
        id: "b2fd2a5f3d5867017a83d9c7e113ed1f")]
    public partial class CompareTransformToNullAction : Action
    {
        [SerializeReference] public BlackboardVariable<Transform> Transform;

        protected override Status OnStart()
        {
            return Transform.Value == null ? Status.Success : Status.Failure;
        }
    }
}