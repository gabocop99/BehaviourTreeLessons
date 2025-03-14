using UnityEngine;
using BTree;

namespace Project.BTree
{
    public class SearchTargetNode : LeafNode
    {
        private string _targetKey;

        public SearchTargetNode(string targetKey)
        {
            _targetKey = targetKey;
        }

        protected override NodeState EvaluationMethod(AThinker thinker)
        {
            var enemy = Object.FindFirstObjectByType<Enemy>().transform;

            thinker.Memory.AddOrEditData(_targetKey, enemy);

            return enemy != null ? NodeState.Success : NodeState.Failure;
        }
    }
}