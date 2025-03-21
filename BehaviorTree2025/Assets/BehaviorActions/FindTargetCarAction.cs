using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "FindTargetCar", story: "Find [Target] Car", category: "Action", id: "77724644bcb54dec1843892d21d8847c")]
public partial class FindTargetCarAction : Action
{
    [SerializeReference] public BlackboardVariable<Transform> Target;

    protected override Status OnStart()
    {
        if (Target.Value != null)
        {
            return Status.Success;
        }
        var cars = UnityEngine.Object.FindObjectsByType<Car>(FindObjectsSortMode.None);
        Target.Value = cars[UnityEngine.Random.Range(0, cars.Length)].transform;
        return Status.Success;
    }
}

