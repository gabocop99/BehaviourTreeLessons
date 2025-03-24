using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "CheckFarDistance",
    story: " [DistanceFromPlayer] < [MaxDistance] or [DistanceFromPlayer] > [MinDistance] from [TargetPosition]", category: "Conditions",
    id: "5a13a519020deb66f2468a19cb5c47e8")]
public partial class CheckFarDistanceCondition : Condition
{
    [SerializeReference] public BlackboardVariable<float> DistanceFromPlayer;
    [SerializeReference] public BlackboardVariable<float> MaxDistance;
    [SerializeReference] public BlackboardVariable<float> MinDistance;
    [SerializeReference] public BlackboardVariable<GameObject> TargetPosition;

    public override bool IsTrue()
    {
        DistanceFromPlayer.Value =
            Vector3.Distance(GameObject.transform.position, TargetPosition.Value.transform.position);
        if (DistanceFromPlayer < MaxDistance.Value)
        {
            if (DistanceFromPlayer > MinDistance.Value)
            {
                return true;
            }

            return false;
        }

        return false;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}