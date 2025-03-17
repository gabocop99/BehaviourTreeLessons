namespace BTree
{
    public class MoveForwardNode : LeafNode
    {
        private string _speedKey;

        public MoveForwardNode(string speedKey)
        {
            _speedKey = speedKey;
        }

        protected override NodeState EvaluationMethod(AThinker thinker)
        {
            TryGetMemory(0f, thinker, _speedKey, out var currentSpeed);
            thinker.transform.position += thinker.transform.forward * currentSpeed;
            
            return NodeState.Success;
        }
    }
}