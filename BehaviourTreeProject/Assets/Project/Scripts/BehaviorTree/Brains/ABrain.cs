using BTree;
using UnityEngine;

namespace Project.BTree
{
    public abstract class ABrain : ScriptableObject
    {
        public abstract BehaviourTree GetTree();
    }
}
