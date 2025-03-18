using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "Check Material", story: "[Target] [is] [Material]", category: "Conditions", id: "3ac021f48eb27fb76fe9494d2975785e")]
public partial class CheckMaterialCondition : Condition
{
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    [Comparison(comparisonType: ComparisonType.Boolean)]
    [SerializeReference] public BlackboardVariable<ConditionOperator> Is;
    [SerializeReference] public BlackboardVariable<Material> Material;

    public override bool IsTrue()
    {
        Material targetMaterial = Target.Value.GetComponent<Renderer>().sharedMaterial;
        return ConditionUtils.Evaluate(targetMaterial,Is, Material.Value);
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
