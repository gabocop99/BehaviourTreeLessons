using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BTree
{
    [Serializable]
    public abstract class ANode
    {
        public Action<ANode> OnEvaluated;

        public ANode[] Children;

        public int Order;

        public abstract int MaxNumberOfChildren { get; }
        public abstract int MinNumberOfChildren { get; }

        public NodeState State;

        public ANode(params ANode[] children)
        {
            Children = children;
        }

        public NodeState Evaluate(AThinker thinker)
        {
            if (State is NodeState.Success or NodeState.Failure)
            {
                return State;
            }
            var evaluationResult = EvaluationMethod(thinker);
            State = evaluationResult;
            OnEvaluated?.Invoke(this);
            return evaluationResult;
        }

        public bool Validate()
        {
            if (Children.Length < MinNumberOfChildren || Children.Length > MaxNumberOfChildren)
            {
                Debug.LogError($"The node {GetType().Name} is initialized with wrong number of children");
                return false;
            }
            return Children.All(child => child.Validate());
        }

        public bool TryGetMemory<T>(T defaultValue, AThinker thinker, string key, out T data)
        {
            data = defaultValue;
            if (thinker.Memory.TryGetData(key, out var obj))
            {
                if (obj is T castObj)
                {
                    data = castObj;
                    return true;
                }
            }
            return false;
        }

        public void GetAllChildren(ref List<ANode> allChildren)
        {
            allChildren ??= new List<ANode>();
            
            allChildren.Add(this);

            foreach (var child in Children)
            {
                child.GetAllChildren(ref allChildren);
            }
        }

        public void OrderAllChildren(ref int order)
        {
            Order = order;

            foreach (var child in Children)
            {
                order++;
                child.OrderAllChildren(ref order);
            }
        }

        protected abstract NodeState EvaluationMethod(AThinker thinker);
    }
}
