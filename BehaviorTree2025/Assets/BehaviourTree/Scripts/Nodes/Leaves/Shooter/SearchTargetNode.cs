using UnityEngine;

namespace BTree
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
            var entity = Object.FindFirstObjectByType<Enemy>();
            if (!entity)
            {
                return NodeState.Failure;
            }
            thinker.Memory.AddOrEditData(_targetKey, entity.transform);
            return NodeState.Success;
        }
    }
}