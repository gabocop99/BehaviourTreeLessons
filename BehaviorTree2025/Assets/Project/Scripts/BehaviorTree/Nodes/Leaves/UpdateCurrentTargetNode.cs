using BTree;
using UnityEngine;

namespace Project.BTree
{
    public class UpdateCurrentTargetNode : LeafNode
    {
        private string _currentIndexKey;
        private string _pointsKey;
        private string _targetKey;

        public UpdateCurrentTargetNode(string currentIndexKey, string pointsKey, string targetKey)
        {
            _currentIndexKey = currentIndexKey;
            _pointsKey = pointsKey;
            _targetKey = targetKey;
        }

        protected override NodeState EvaluationMethod(AThinker thinker)
        {
            TryGetMemory(0, thinker, _currentIndexKey, out int currentIndex);
            if (!TryGetMemory(null, thinker, _pointsKey, out Transform[] points))
            {
                return NodeState.Failure;
            }

            thinker.Memory.AddOrEditData(_targetKey, points[currentIndex]);
            return NodeState.Success;
        }
    }
}
