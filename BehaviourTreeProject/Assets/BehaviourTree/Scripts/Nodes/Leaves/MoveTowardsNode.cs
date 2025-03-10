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

        public override NodeState Evaluate(AThinker thinker)
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
            thinker.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
            return NodeState.Success;
        }
    }
}
