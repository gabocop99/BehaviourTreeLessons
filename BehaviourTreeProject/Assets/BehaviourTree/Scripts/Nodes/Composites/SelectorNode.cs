using UnityEngine;

namespace BTree
{
    public class SelectorNode : CompositeNode
    {
        public SelectorNode(ANode child, params ANode[] children) : base(child, children) { }

        public override NodeState Evaluate(AThinker thinker)
        {
            foreach (var child in Children)
            {
                switch (child.Evaluate(thinker))
                {
                    case NodeState.Failure:
                        continue;
                    case NodeState.Running:
                        return NodeState.Running;
                    case NodeState.Success:
                        return NodeState.Success;
                }
            }
            return NodeState.Failure;
        }
    }
}
