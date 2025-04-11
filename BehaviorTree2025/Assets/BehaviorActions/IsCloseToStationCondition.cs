using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "IsCloseToStation", story: "Is close to [Station]", category: "Conditions", id: "5262031c32109245ec94f94f8f35a731")]
public partial class IsCloseToStationCondition : Condition
{
    [SerializeReference] public BlackboardVariable<Station> Station;

    public override bool IsTrue()
    {
        Transform station = null;
        switch (Station.Value)
        {
            case global::Station.Workbench:
                station = CraftingStations.Instance.CraftingBench;
                break;
            case global::Station.Deposit:
                station = CraftingStations.Instance.Deposit;
                break;
            case global::Station.Wood:
                station = CraftingStations.Instance.Wood;
                break;
            case global::Station.Metal:
                station = CraftingStations.Instance.Metal;
                break;
            case global::Station.Cloth:
                station = CraftingStations.Instance.Cloth;
                break;
        }
        var distance = Vector3.Distance(GameObject.transform.position, station.position);
        return distance < 1f;
    }
}
