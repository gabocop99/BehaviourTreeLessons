using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "AgentRaycastsCheck", story: "Agent shoots [N] raycasts in [Angle] with [Range] , and sets [BestDirection] and if [AnyHits]", category: "Action", id: "dc8692ac79b987af3d2e2e91c8c6455f")]
public partial class AgentRaycastsCheckAction : Action
{
    [SerializeReference] public BlackboardVariable<int> N;
    [SerializeReference] public BlackboardVariable<float> Angle;
    [SerializeReference] public BlackboardVariable<float> Range;
    [SerializeReference] public BlackboardVariable<Vector3> BestDirection;
    [SerializeReference] public BlackboardVariable<bool> AnyHits;

    protected override Status OnStart()
    {
        var wallMask = LayerMask.GetMask("Wall");

        var origin = GameObject.transform.position + Vector3.up * .3f;
        var direction = Quaternion.AngleAxis(-Angle.Value / 2, Vector3.up) * GameObject.transform.forward;
        var angleDelta = Angle.Value / (N.Value - 1);

        var optimalDirection = Vector3.zero;

        AnyHits.Value = false;

        for (var i = 0; i < N.Value; i++)
        {
            var ray = new Ray(origin, direction);
            if (!Physics.Raycast(ray, out var hit, Range.Value, wallMask))
            {
                optimalDirection += direction * Range.Value;
            }
            else
            {
                var distance = Vector3.Distance(origin, hit.point);
                optimalDirection += direction * distance;
                AnyHits.Value = true;
            }
            direction = Quaternion.AngleAxis(angleDelta, Vector3.up) * direction;
        }

        optimalDirection /= N.Value;
        BestDirection.Value = optimalDirection.normalized;
        return Status.Success;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

