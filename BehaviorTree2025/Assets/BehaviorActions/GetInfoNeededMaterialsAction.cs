using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "GetInfoNeededMaterials", story: "Obtain values of [wood] [metal] [cloth]", category: "Action", id: "6ae050ec5e3bf62f710e5acc5e203271")]
public partial class GetInfoNeededMaterialsAction : Action
{
    [SerializeReference] public BlackboardVariable<int> Wood;
    [SerializeReference] public BlackboardVariable<int> Metal;
    [SerializeReference] public BlackboardVariable<int> Cloth;

    protected override Status OnStart()
    {
        
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

