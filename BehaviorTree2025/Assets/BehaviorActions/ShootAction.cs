using System;
using System.Collections;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ShootAction", story: "Instantiate [Bullet] at [MuzzlePoint] each [TimeInSeconds]",
    category: "Action", id: "7ea4352bf85efbfd85d75a950b37f53a")]
public partial class ShootAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Bullet;
    [SerializeReference] public BlackboardVariable<GameObject> MuzzlePoint;
    [SerializeReference] public BlackboardVariable<float> TimeInSeconds;
    private float _elapsedTime = 0;

    protected override Status OnStart()
    {
        _elapsedTime += Time.deltaTime;
        Debug.Log(_elapsedTime);
        if (_elapsedTime >= TimeInSeconds.Value)
        {
            _elapsedTime = 0;
            Debug.Log("Shooting");
            return Status.Success;
        }
        return Status.Failure;
    }
    
}