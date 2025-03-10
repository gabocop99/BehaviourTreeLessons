namespace BTree
{
    public class FailureNode : DecoratorNode
    {
        public FailureNode(ANode child) : base(child) { }

        protected override NodeState EvaluationMethod(AThinker thinker)
        {
            Children[0].Evaluate(thinker);
            return NodeState.Failure;
        }
    }
}
