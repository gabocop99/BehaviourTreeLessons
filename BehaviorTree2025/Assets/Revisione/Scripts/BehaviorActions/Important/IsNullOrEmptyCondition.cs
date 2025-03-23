using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "IsNullOrEmpty", story: "[Collection] [comparison] null or empty", category: "Conditions", id: "338f71d9b6d96c1d9a5a662c89d07ab1")]
public partial class IsNullOrEmptyCondition : Condition
{
    [SerializeReference] public BlackboardVariable<List<GameObject>> Collection;
    [Comparison(comparisonType: ComparisonType.Boolean)]
    [SerializeReference] public BlackboardVariable<ConditionOperator> Comparison;

    public override bool IsTrue()
    {
        var isEqual = Collection.Value == null || Collection.Value.Count == 0;

        switch (Comparison.Value)
        {
            case ConditionOperator.Equal:
                return isEqual;
            case ConditionOperator.NotEqual:
                return !isEqual;
            default:
                return false;
        }

    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
