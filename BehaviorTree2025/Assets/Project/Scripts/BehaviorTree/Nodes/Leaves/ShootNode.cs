using BTree;
using UnityEngine;

namespace Project.BTree
{
    public class ShootNode : LeafNode
    {
        protected override NodeState EvaluationMethod(AThinker thinker)
        {
            Debug.Log("Shooting");
            return NodeState.Success;
        }
    }
}