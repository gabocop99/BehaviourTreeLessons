using UnityEngine;

namespace BTree
{
    public abstract class AThinker : MonoBehaviour
    {
        public BTMemory Memory = new();
        public BehaviourTree BehaviourTree;

        [SerializeField]
        private bool _doesEvaluateInUpdate = true;

        private void Awake()
        {
            Memory = new();
        }

        private void Update()
        {
            if (!_doesEvaluateInUpdate || BehaviourTree == null)
            {
                return;
            }
            Evaluate();
        }

        public NodeState Evaluate()
        {
            return BehaviourTree.Evaluate(this);
        }

        public bool Validate()
        {
            return BehaviourTree.Validate();
        }

        public object GetMemory(string key)
        {
            if (!Memory.TryGetData(key, out var data))
            {
                return null;
            }
            return data;
        }
    }
}
