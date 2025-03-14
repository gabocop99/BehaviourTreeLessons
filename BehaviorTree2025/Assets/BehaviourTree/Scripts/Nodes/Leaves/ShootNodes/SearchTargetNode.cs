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
            if (!thinker.Memory.TryGetData(_targetKey, out var targetObj))
            {
                return NodeState.Failure;
            }

            RaycastHit hit;
            Vector3 origin = thinker.transform.position;
            Vector3 direction = thinker.transform.forward;
            float maxDistance = 10f;

            if(Physics.Raycast(origin, direction, out hit, maxDistance))
            {
                return hit.collider.gameObject == (targetObj as GameObject) ? NodeState.Failure : NodeState.Success;
            }
            return NodeState.Failure;
        }
    }
}
