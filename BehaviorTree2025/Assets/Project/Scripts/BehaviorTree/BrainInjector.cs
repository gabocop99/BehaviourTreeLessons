using BTree;
using UnityEngine;

namespace Project.BTree
{
    public class BrainInjector : MonoBehaviour
    {
        [SerializeField]
        private AThinker _thinker;

        [SerializeField]
        private ABrain _brain;

        private void Start()
        {
            _thinker.BehaviourTree = _brain.GetTree();
        }
    }
}
