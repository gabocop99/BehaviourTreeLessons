using UnityEngine;

namespace BTree
{
    public class HasTargetNode : LeafNode
    {
        private string _targetKey;

        public HasTargetNode(string targetKey)
        {
            _targetKey = targetKey;
        }

        protected override NodeState EvaluationMethod(AThinker thinker)
        {
            return TryGetMemory(null, thinker, _targetKey, out Transform transform)
                ? NodeState.Success
                : NodeState.Failure;
        }
    }
}