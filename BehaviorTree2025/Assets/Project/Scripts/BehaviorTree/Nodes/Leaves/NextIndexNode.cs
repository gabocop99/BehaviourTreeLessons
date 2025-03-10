using BTree;
using UnityEngine;

namespace Project.BTree
{
    public class NextIndexNode : LeafNode
    {
        private string _currentIndexKey;
        private string _pointsKey;

        public NextIndexNode(string currentIndexKey, string pointsKey)
        {
            _currentIndexKey = currentIndexKey;
            _pointsKey = pointsKey;
        }

        protected override NodeState EvaluationMethod(AThinker thinker)
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
            currentIndex = (currentIndex + 1) % points.Length;

            thinker.Memory.AddOrEditData(_currentIndexKey, currentIndex);
            return NodeState.Success;
        }
    }
}
