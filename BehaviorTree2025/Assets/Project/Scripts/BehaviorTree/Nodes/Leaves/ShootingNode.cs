using BTree;
using UnityEngine;

namespace Project.BTree
{
    public class ShootingNode : LeafNode
    {
        private string _targetKey;

        public ShootingNode(string targetKey)
        {
            _targetKey = targetKey;
        }

        protected override NodeState EvaluationMethod(AThinker thinker)
        {
            if (!thinker.Memory.TryGetData(_targetKey, out var targetObj))
            {
                return NodeState.Failure;
            }
            
            var direction = (thinker.transform.position + (Vector3)targetObj).normalized;
            var charTinker = thinker.GetComponent<CharacterThinker>();
            
           // InstantiateBullet(charTinker.bullet, direction, Quaternion.identity);
            
            return NodeState.Success;
        }
    }
}