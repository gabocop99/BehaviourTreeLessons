using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "TimeComparison", story: "Is Time [Comparison] [Float]", category: "Conditions", id: "e7fcb6fd78362e864f3c9fbb79b9bf4f")]
public partial class TimeComparisonCondition : Condition
{
    [Comparison(comparisonType: ComparisonType.All)]
    [SerializeReference] public BlackboardVariable<ConditionOperator> Comparison;
    [SerializeReference] public BlackboardVariable<float> Float;

    public override bool IsTrue()
    {
        return ConditionUtils.Evaluate(Time.time, Comparison, Float.Value);
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
