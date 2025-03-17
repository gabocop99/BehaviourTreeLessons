using BTree;
using UnityEngine;

namespace Project.BTree
{
    public class CanShootNode : LeafNode
    {
        private string _distanceKey;
        private string _targetKey;
        
        public CanShootNode(string distanceKey, string targetKey)
        {
            _distanceKey = distanceKey;
            _targetKey = targetKey;
        }
        
        protected override NodeState EvaluationMethod(AThinker thinker)
        {
            if (!thinker.Memory.TryGetData(_targetKey, out var targetObj))
            {
                return NodeState.Failure;
            }
            var target = (Transform)targetObj;

            var distance = 5f;
            if (thinker.Memory.TryGetData(_distanceKey, out var distanceObj))
            {
                distance = (float)distanceObj;
            }

            var distanceToTarget = Vector3.Distance(thinker.transform.position, target.position);
            
            return distanceToTarget > distance ? NodeState.Failure : NodeState.Success;
        }
    }
}