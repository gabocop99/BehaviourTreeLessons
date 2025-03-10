using System.Collections;
using UnityEngine;

namespace BTree
{
    public class WaitNode : LeafNode
    {
        private float _time;
        private bool _isDone;

        public WaitNode(float time)
        {
            _time = time;
        }

        protected override NodeState EvaluationMethod(AThinker thinker)
        {
            if (State == NodeState.None)
            {
                thinker.StartCoroutine(EvaluationCoroutine());
                return NodeState.Running;
            }

            if (!_isDone)
            {
                return NodeState.Running;
            }

            _isDone = false;
            return NodeState.Success;
        }

        private IEnumerator EvaluationCoroutine()
        {
            _isDone = false;

            yield return new WaitForSeconds(_time);

            _isDone = true;
        }
    }
}
