using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;


[Serializable, GeneratePropertyBag]
[NodeDescription(name: "GetRandomTargetFromList", story: "Get Random [Target] from List: [Targets]", category: "Action", id: "fc751b4713c4ba1ba613c87ca6898949")]
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
        int randomIndex = UnityEngine.Random.Range(0, Targets.Value.Count);
        Target.Value = Targets.Value[randomIndex];
    }
}

