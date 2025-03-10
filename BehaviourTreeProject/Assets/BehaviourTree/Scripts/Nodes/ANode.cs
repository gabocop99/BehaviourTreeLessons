using System.Linq;
using UnityEngine;

namespace BTree
{
    [System.Serializable]
    public abstract class ANode
    {
        public ANode[] Children;

        public abstract int MaxNumberOfChildren { get; }
        public abstract int MinNumberOfChildren { get; }

        [SerializeField]
        protected NodeState State;

        public ANode(params ANode[] children)
        {
            Children = children;
        }

        public abstract NodeState Evaluate(AThinker thinker);

        public bool Validate()
        {
            if (Children.Length < MinNumberOfChildren || Children.Length > MaxNumberOfChildren)
            {
                Debug.LogError($"The node {GetType().Name} is initialized with wrong number of children");
                return false;
            }
            return Children.All(child => child.Validate());
        }
    }
}
