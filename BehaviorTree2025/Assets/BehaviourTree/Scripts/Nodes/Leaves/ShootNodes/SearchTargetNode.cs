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
            var enemy = Object.FindObjectOfType<Enemy>();

            if (enemy != null)
            {
                thinker.Memory.AddOrEditData(_targetKey, enemy.transform);
                return NodeState.Success;
            }
  
            return NodeState.Failure;
        }
    }
}
