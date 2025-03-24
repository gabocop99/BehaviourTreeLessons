using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "GetButtonData", story: "Get Materials Data from Button", category: "Action", id: "6cb4a92c205d145100948268c711c020")]
public partial class GetButtonDataAction : Action
{
    
    

    protected override Status OnStart()
    {
        return Status.Success;
    }

}

