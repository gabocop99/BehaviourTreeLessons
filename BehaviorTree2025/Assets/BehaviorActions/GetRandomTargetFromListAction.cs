using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;


[Serializable, GeneratePropertyBag]
[NodeDescription(name: "GetRandomTargetFromList", story: "Get new Random [Target] from List [Targets]", category: "Action", id: "fc751b4713c4ba1ba613c87ca6898949")]
public partial class GetRandomTargetFromListAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    [SerializeReference] public BlackboardVariable<List<GameObject>> Targets;

    protected override Status OnStart()
    {
        GetTarget();
        return Status.Success;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }

    private void GetTarget()
    { 
        GameObject oldTarget = Target.Value;
        List<GameObject> availableTargets = new List<GameObject>(Targets.Value.FindAll(t => t != oldTarget && t != null));

        if (availableTargets.Count == 0)
        {
            if (oldTarget != null) { Target.Value = oldTarget; return; } 
            return; 
        }
        int randomIndex = UnityEngine.Random.Range(0, availableTargets.Count);
        Target.Value = availableTargets[randomIndex];
    }
}

