using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "RandomFromSelection", story: "Pick random [Target] from [Collection]", category: "Action", id: "261c8934c1a1a31c697eecf50034bd0f")]
public partial class RandomFromSelectionAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    [SerializeReference] public BlackboardVariable<List<GameObject>> Collection;

    protected override Status OnStart()
    {
        Target.Value = Collection.Value[UnityEngine.Random.Range(0, Collection.Value.Count)];
        return Status.Success;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

