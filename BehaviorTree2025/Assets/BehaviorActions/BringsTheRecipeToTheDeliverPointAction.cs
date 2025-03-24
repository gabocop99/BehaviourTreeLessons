using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Brings the recipe to the deliver point", story: "Brings the recipe to the deliver point", category: "Action", id: "37c8c89b9a7e191b8e714855f67f4757")]
public partial class BringsTheRecipeToTheDeliverPointAction : Action
{

    protected override Status OnStart()
    {
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

