using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "WaitForButtonClick", story: "Button has been pressed?", category: "Action",
    id: "e0b72c9394c8e00a05f8eaba4000448d")]
public partial class WaitForButtonClickAction : Action
{
    public Status OnClick()
    {
        return Status.Success;
    }
}