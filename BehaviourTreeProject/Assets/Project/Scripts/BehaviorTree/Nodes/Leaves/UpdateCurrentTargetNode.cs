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

        public override NodeState Evaluate(AThinker thinker)
        {
            if (!thinker.Memory.TryGetData(_pointsKey, out var pointsObj))
            {
                return NodeState.Failure;
            }
            var points = (Transform[])pointsObj;

            var currentIndex = 0;
            if (thinker.Memory.TryGetData(_currentIndexKey, out var currentIndexObj))
            {
                currentIndex = (int)currentIndexObj;
            }

            thinker.Memory.AddOrEditData(_targetKey, points[currentIndex]);
            return NodeState.Success;
        }
    }
}
