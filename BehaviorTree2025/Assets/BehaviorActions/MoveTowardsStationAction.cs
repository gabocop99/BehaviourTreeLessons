using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using static UnityEngine.GraphicsBuffer;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "MoveTowardsStation", story: "Move towards [Station] by [Speed]", category: "Action", id: "d58db786e4db17d708741b5eb0dd2077")]
public partial class MoveTowardsStationAction : Action
{
    [SerializeReference] public BlackboardVariable<Station> Station;
    [SerializeReference] public BlackboardVariable<float> Speed;

    protected override Status OnStart()
    {
        Transform target = null;
        switch (Station.Value)
        {
            case global::Station.Workbench:
                target = CraftingStations.Instance.CraftingBench;
                break;
            case global::Station.Deposit:
                target = CraftingStations.Instance.Deposit;
                break;
            case global::Station.Wood:
                target = CraftingStations.Instance.Wood;
                break;
            case global::Station.Metal:
                target = CraftingStations.Instance.Metal;
                break;
            case global::Station.Cloth:
                target = CraftingStations.Instance.Cloth;
                break;
        }
        var distance = target.position - GameObject.transform.position;
        var magnitude = Mathf.Min(Time.deltaTime * Speed.Value, distance.magnitude);
        GameObject.transform.position += magnitude * distance.normalized;
        GameObject.transform.LookAt(target, Vector3.up);

        return Status.Success;
    }
}

