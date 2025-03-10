using UnityEngine;

namespace BTree
{
    public class MoveTowardsNode : LeafNode
    {
        private string _speedKey;
        private string _targetKey;

        public MoveTowardsNode(string speedKey, string targetKey)
        {
            _speedKey = speedKey;
            _targetKey = targetKey;
        }

        protected override NodeState EvaluationMethod(AThinker thinker)
        {
            if (!thinker.Memory.TryGetData(_targetKey, out var targetObj))
            {
                return NodeState.Failure;
            }
            var target = (Transform)targetObj;

            var speed = 2f;
            if (thinker.Memory.TryGetData(_speedKey, out var speedObj))
            {
               speed = (float)speedObj;
            }

            var direction = target.position - thinker.transform.position;
            direction.Normalize();

            thinker.transform.position += speed * Time.deltaTime * direction;
            var targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            thinker.transform.rotation = Quaternion.Lerp(thinker.transform.rotation, targetRotation, .1f);
            return NodeState.Success;
        }
    }
}
