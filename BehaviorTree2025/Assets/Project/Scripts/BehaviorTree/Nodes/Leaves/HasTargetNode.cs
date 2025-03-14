using UnityEngine;
using BTree;

namespace Project.BTree
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
            TryGetMemory(null, thinker, _targetKey, out Transform target);

            return target != null ? NodeState.Success : NodeState.Failure;
        }
    }
}