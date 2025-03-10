namespace BTree
{
    public abstract class DecoratorNode : ANode
    {
        public override int MaxNumberOfChildren => 1;
        public override int MinNumberOfChildren => 1;

        public DecoratorNode(ANode child) : base(child) { }
    }
}
