using System;
using System.Collections.Generic;
using UnityEngine;

namespace BTree
{
    [Serializable]
    public class BehaviourTree
    {
        public ANode Root;

        private ANode _lastNode;
        private NodeState _lastNodeState;

        public BehaviourTree(ANode root)
        {
            Root = root;
        }

        public NodeState Evaluate(AThinker thinker)
        {
            _lastNodeState = Root.Evaluate(thinker);

            if (_lastNodeState is NodeState.Success or NodeState.Failure)
            {
                Reset();
            }

            return _lastNodeState;
        }

        public bool Validate()
        {
            return Root.Validate();
        }

        public void RegisterToNodes()
        {
            foreach (var node in GetAllNodes())
            {
                node.OnEvaluated += OnNodeEvaluated;
            }
        }

        public List<ANode> GetAllNodes()
        {
            var allNodes = new List<ANode>();
            Root.GetAllChildren(ref allNodes);
            return allNodes;
        }

        public void OrderAllNodes()
        {
            var order = 0;
            Root.OrderAllChildren(ref order);
        }

        private void OnNodeEvaluated(ANode node)
        {
            if (node is not LeafNode leafNode)
            {
                return;
            }
            _lastNode = leafNode;
        }

        private void Reset()
        {
            foreach (var node in GetAllNodes())
            {
                node.State = NodeState.None;
            }
        }
    }
}