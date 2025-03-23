using System;
using Unity.Behavior;
using Composite = Unity.Behavior.Composite;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "CustomSelector", story: "Il selector che funziona", category: "Flow", id: "250ae82305ceht52f2d557d402cef9c1")]
public partial class CustomSelector : Composite
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
                    return Status.Success;
                case Status.Failure:
                    continue;
                case Status.Running:
                    return Status.Running;
                case Status.Waiting:
                    return Status.Waiting;
                default:
                    return Status.Failure;
            }
        }

        return Status.Failure;
    }
}

