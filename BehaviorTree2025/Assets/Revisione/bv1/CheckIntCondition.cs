using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "Check int", story: "[CurrentInt] [is] [MaxInt]", category: "Conditions", id: "c9ba346ff9369369f0467a185bc286ac")]
public partial class CheckIntCondition : Condition
{
    [SerializeReference] public BlackboardVariable<int> CurrentInt;
    [Comparison(comparisonType: ComparisonType.Boolean)]
    [SerializeReference] public BlackboardVariable<ConditionOperator> Is;
    [SerializeReference] public BlackboardVariable<int> MaxInt;

    public override bool IsTrue()
    {
        return ConditionUtils.Evaluate(CurrentInt, Is, MaxInt);
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
