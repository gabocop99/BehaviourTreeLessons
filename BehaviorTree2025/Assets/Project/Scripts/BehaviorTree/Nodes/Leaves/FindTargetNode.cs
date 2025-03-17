using BTree;
using UnityEngine;


namespace Project.BTree
{
    public class FindTargetNode : LeafNode
    {
        private string _targetKey;

        public FindTargetNode(string targetKey)
        {
            _targetKey = targetKey;
        }
        protected override NodeState EvaluationMethod(AThinker thinker)
        {
            thinker.Memory.AddOrEditData(_targetKey, TryGetTarget(thinker));
            return NodeState.Success;
        }

        private Transform TryGetTarget(AThinker thinker)
        {
            return Object.FindFirstObjectByType<Enemy>().transform;
        }
    }
}