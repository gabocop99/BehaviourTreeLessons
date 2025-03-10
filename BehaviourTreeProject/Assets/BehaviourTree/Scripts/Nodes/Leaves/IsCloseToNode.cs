using UnityEngine;

namespace BTree
{
    public class IsCloseToNode : LeafNode
    {
        private string _distanceKey;
        private string _targetKey;

        public IsCloseToNode(string distanceKey, string targetKey)
        {
            _distanceKey = distanceKey;
            _targetKey = targetKey;
        }

        public override NodeState Evaluate(AThinker thinker)
        {
            if (!thinker.Memory.TryGetData(_targetKey, out var targetObj))
            {
                return NodeState.Failure;
            }
            var target = (Transform)targetObj;

            var distance = 0.1f;
            if (thinker.Memory.TryGetData(_distanceKey, out var distanceObj))
            {
                distance = (float)distanceObj;
            }

            var distanceToTarget = Vector3.Distance(thinker.transform.position, target.position);

            return distanceToTarget > distance ? NodeState.Failure : NodeState.Success;
        }
    }
}
