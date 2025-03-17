using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "Check Target", story: "[Target] isNullOrEmpty", category: "Conditions", id: "4638fd3adee7641b66c609abf48bfc4d")]
public partial class CheckTargetCondition : Condition
{
    [SerializeReference] public BlackboardVariable<GameObject> Target;


    public override bool IsTrue()
    {
        return Target.Value == null;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
