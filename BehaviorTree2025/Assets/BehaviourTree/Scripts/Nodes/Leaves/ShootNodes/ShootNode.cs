using UnityEngine;

namespace BTree
{
    public class ShootNode : LeafNode
    {
        private string _targetKey;
        
        public ShootNode(string speedKey, string targetKey)
        {
            _targetKey = targetKey;
            
        }
        
        protected override NodeState EvaluationMethod(AThinker thinker)
        {
            if (!thinker.Memory.TryGetData(_targetKey, out var targetObj))
            {
                return NodeState.Failure;
            }

            // RaycastHit hit;
            // Vector3 origin = thinker.transform.position;
            // Vector3 direction = thinker.transform.forward;
            // float maxDistance = 10f;
            
            Debug.Log("Shoot");
            
            return NodeState.Success;
        }
    }
}
