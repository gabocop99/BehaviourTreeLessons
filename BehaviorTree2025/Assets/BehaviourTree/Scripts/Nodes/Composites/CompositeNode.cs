
using System.Linq;
using UnityEngine;

namespace BTree
{
    public abstract class CompositeNode : ANode
    {
        public override int MaxNumberOfChildren => int.MaxValue;
        public override int MinNumberOfChildren => 1;

        public CompositeNode(ANode child, params ANode[] children) : base(children) 
        {
            var newChildren = new ANode[children.Length + 1];
            children.CopyTo(newChildren, 1);
            newChildren[0] = child;
            Children = newChildren;
        }
    }
}
