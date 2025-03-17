using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "List Comparison", story: "If [Collection] Comparison isNullOrEmpty", category: "Conditions", id: "f3761e757f11d2bf874d64b470ab3297")]
public partial class ListComparisonCondition : Condition
{
    [SerializeReference] public BlackboardVariable<List<GameObject>> Collection;

    public override bool IsTrue()
    {
        return Collection.Value == null || Collection.Value.Count == 0;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
