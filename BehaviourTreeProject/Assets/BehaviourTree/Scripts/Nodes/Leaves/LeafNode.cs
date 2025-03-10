namespace BTree
{
    public abstract class LeafNode : ANode
    {
        public override int MaxNumberOfChildren => 0;
        public override int MinNumberOfChildren => 0;
    }
}
