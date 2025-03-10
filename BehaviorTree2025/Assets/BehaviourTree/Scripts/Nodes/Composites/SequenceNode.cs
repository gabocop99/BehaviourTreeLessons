namespace BTree
{
    public class SequenceNode : CompositeNode
    {
        public SequenceNode(ANode child, params ANode[] children) : base(child, children) { }

        protected override NodeState EvaluationMethod(AThinker thinker)
        {
            foreach (var child in Children)
            { 
                switch (child.Evaluate(thinker))
                {
                    case NodeState.Failure:
                        return NodeState.Failure;
                    case NodeState.Running:
                        return NodeState.Running;
                    case NodeState.Success:
                        continue;
                }
            }
            return NodeState.Success;

        }
    }
}
