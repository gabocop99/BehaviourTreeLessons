using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.UI;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Check Button", story: "Interact with [Button]", category: "Action", id: "a13b9f3fbb4eacb02367f2334e50acb5")]
public partial class CheckButtonsAction : Action
{
    [SerializeReference] public BlackboardVariable<Button> Button;

    protected override Status OnStart()
    {
        Button.Value.onClick.Invoke();
        Debug.Log($"{Button.Value.name} Clicked");
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

