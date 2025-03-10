using System.Collections;
using UnityEngine;

namespace BTree
{
    public class LookAroundNode : LeafNode
    {
        private string _timeKey;
        private string _angleKey;

        private bool _isDone;

        public LookAroundNode(string timeKey, string angleKey)
        {
            _timeKey = timeKey;
            _angleKey = angleKey;
        }

        protected override NodeState EvaluationMethod(AThinker thinker)
        {
            TryGetMemory(1f, thinker, _timeKey, out float time);
            TryGetMemory(45f, thinker, _angleKey, out float angle);

            if (State == NodeState.None)
            {
                thinker.StartCoroutine(EvaluationCoroutine(thinker, time, angle));
                return NodeState.Running;
            }

            if (!_isDone)
            {
                return NodeState.Running;
            }

            _isDone = false;
            return NodeState.Success;
        }

        private IEnumerator EvaluationCoroutine(AThinker thinker, float time, float angle)
        {
            _isDone = false;

            yield return thinker.StartCoroutine(AngularMovement(thinker, 1, time / 4, angle / 2));
            yield return thinker.StartCoroutine(AngularMovement(thinker, -1, time / 2, angle));
            yield return thinker.StartCoroutine(AngularMovement(thinker, 1, time / 4, angle / 2));

            _isDone = true;
        }

        private IEnumerator AngularMovement(AThinker thinker, float direction, float time, float angle)
        {
            float t = 0;
            while (t < time)
            {
                var deltaTime = Time.deltaTime;
                t += deltaTime;
                var angularMovement = angle * deltaTime * direction / time;
                thinker.transform.Rotate(Vector3.up, angularMovement);
                yield return null;
            }
        }
    }
}
