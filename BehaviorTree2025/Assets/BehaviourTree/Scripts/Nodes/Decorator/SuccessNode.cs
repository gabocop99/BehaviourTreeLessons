namespace BTree
{
    public class SuccessNode : DecoratorNode
    {
        public SuccessNode(ANode child) : base(child) { }

        protected override NodeState EvaluationMethod(AThinker thinker)
        {
            Children[0].Evaluate(thinker);
            return NodeState.Success;
        }
    }
}
