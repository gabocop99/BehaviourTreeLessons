using System;
using Unity.Behavior;
using UnityEngine;
using Composite = Unity.Behavior.Composite;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "CustomSequence", story: "La sequence che funziona", category: "Flow", id: "250ae82305ceda52f2d557d402cef9c1")]
public partial class CustomSequence : Composite
{
    protected override Status OnStart()
    {
        if (Children.Count == 0)
            return Status.Failure;

        foreach (var child in Children)
        {
            var status = StartNode(child);
            switch(status)
            {
                case Status.Success:
                    continue;
                case Status.Failure:
                    return Status.Failure;
                case Status.Running:
                    return Status.Running;
                case Status.Waiting:
                    return Status.Waiting;
                default:
                    return Status.Success;
            }
        }

        return Status.Success;
    }
}

