using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "UpdateTimer", story: "Update [TimePassed]", category: "Action",
    id: "1558cdab4ac56953b43cbceaa12b71d8")]
public partial class UpdateTimerAction : Action
{
    [SerializeReference] public BlackboardVariable<float> TimePassed;

    protected override Status OnStart()
    {
        TimePassed.Value += Time.deltaTime;
        return Status.Success;
    }
}