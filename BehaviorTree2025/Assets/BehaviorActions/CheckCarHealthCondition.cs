using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "CheckCarHealth", story: "Car Health is [Comparison] [Value]", category: "Conditions", id: "be7022a75abf19325c861fbdef0cf079")]
public partial class CheckCarHealthCondition : Condition
{
    [Comparison(comparisonType: ComparisonType.All)]
    [SerializeReference] public BlackboardVariable<ConditionOperator> Comparison;
    [SerializeReference] public BlackboardVariable<float> Value;

    public override bool IsTrue()
    {
        if (!GameObject.TryGetComponent<Car>(out var car))
        {
            return false;
        }

        return ConditionUtils.Evaluate(car.Hp, Comparison, Value.Value);
    }
}
