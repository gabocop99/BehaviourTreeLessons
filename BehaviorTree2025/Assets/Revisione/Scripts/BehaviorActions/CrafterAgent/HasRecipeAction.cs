using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "HasRecipe", story: "Has [Self] a Recipe", category: "Action",
    id: "b9fa3163af403db3046752481bfe35a7")]
public partial class HasRecipeAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;

    protected override Status OnStart()
    {
        if (!Self.Value.TryGetComponent<CrafterAgentController>(out var agent))
        {
            return Status.Failure;
        }

        return agent.IsBusy ? Status.Success : Status.Failure;
    }
}