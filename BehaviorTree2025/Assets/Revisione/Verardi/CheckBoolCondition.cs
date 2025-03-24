using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "Check Bool", story: "[Bool] [BooleanCondition] [Boolean]", category: "Conditions", id: "b4f6e6675f6d1b42d04208d836536415")]
public partial class CheckBoolCondition : Condition
{
    [SerializeReference] public BlackboardVariable<bool> Bool;
    [SerializeReference] public BlackboardVariable<ConditionOperator> BooleanCondition;

    [SerializeReference] public BlackboardVariable<bool> Boolean;

    public override bool IsTrue()
    {
        return ConditionUtils.Evaluate(Bool, BooleanCondition, Boolean);
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
