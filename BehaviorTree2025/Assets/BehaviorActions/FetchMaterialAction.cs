using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Fetch Material", story: "Compares Materials on Workbench and Fetches the missing ones", category: "Action", id: "f0a4ffc7e6a91e7f99ce48962fa553f5")]
public partial class FetchMaterialAction : Action
{

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

