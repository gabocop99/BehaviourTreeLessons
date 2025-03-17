using BTree;
using UnityEngine;

namespace Project.BTree
{
    public class CheckTargetNode : LeafNode
    {
        private string _targetKey;

        public CheckTargetNode(string target)
        {
            _targetKey = target;
        }
        protected override NodeState EvaluationMethod(AThinker thinker)
        {
            TryGetMemory(null, thinker, _targetKey, out Transform target);
            return target != null ? NodeState.Success : NodeState.Failure;
        }
    }
}
