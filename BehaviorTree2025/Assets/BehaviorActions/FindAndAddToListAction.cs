using System;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Find and Add to List", story: "Find and Add with Tag [Target] to List: [Targets]", category: "Action", id: "59dc2ebf4efaba0ecc9fcb3fd0c161a0")]
public partial class FindAndAddToListAction : Action
{
    [SerializeReference] public BlackboardVariable<string> Target;
    [SerializeReference] public BlackboardVariable<GameObject> TargetGameObject;

    [SerializeReference] public BlackboardVariable<List<GameObject>> Targets;
    protected override Status OnStart()
    {
        GetTargets();
        Targets.Value.Add(TargetGameObject.Value);
        return Status.Success;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }

    private void GetTargets()
    {
        Targets.Value.Clear();
        GameObject[] targetGameObjects = GameObject.FindGameObjectsWithTag(Target);
        foreach (GameObject target in targetGameObjects)
        { Targets.Value.Add(target); }
    }
}

