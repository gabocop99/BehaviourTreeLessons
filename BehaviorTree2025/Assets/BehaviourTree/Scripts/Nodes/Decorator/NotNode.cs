using UnityEngine;

namespace BTree
{
    public class NotNode : DecoratorNode
    {
        public NotNode(ANode child) : base(child) { }

        protected override NodeState EvaluationMethod(AThinker thinker)
        {
            switch (Children[0].Evaluate(thinker))
            {
                case NodeState.Running:
                    return NodeState.Running;
                case NodeState.Success:
                    return NodeState.Failure;
                case NodeState.Failure:
                    return NodeState.Success;
                case NodeState.None:
                    return NodeState.None;
                default:
                    Debug.LogError("Unsupported State");
                    return NodeState.Failure;
            }
        }
    }
}
