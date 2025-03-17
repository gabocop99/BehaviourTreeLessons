using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "CheckDistance", story: "distance between [Agent] and [Target] is [lower] [targetDistance]", category: "Conditions", id: "87556bf09d9cc4adf0185c3e6751cc2b")]
public partial class CheckDistanceCondition : Condition
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    [Comparison(comparisonType: ComparisonType.All)]
    [SerializeReference] public BlackboardVariable<ConditionOperator> Lower;
    [SerializeReference] public BlackboardVariable<float> TargetDistance;

    public override bool IsTrue()
    {

        float distance = Vector3.Distance(Agent.Value.transform.position, Target.Value.transform.position); ;
        return ConditionUtils.Evaluate(distance, Lower, TargetDistance.Value);
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }


}
