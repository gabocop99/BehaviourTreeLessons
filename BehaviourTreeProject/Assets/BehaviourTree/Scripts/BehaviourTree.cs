namespace BTree
{
    [System.Serializable]
    public class BehaviourTree
    {
        public ANode Root;

        public BehaviourTree(ANode root)
        {
            Root = root;
        }

        public NodeState Evaluate(AThinker thinker)
        {
            return Root.Evaluate(thinker);
        }

        public bool Validate()
        {
            return Root.Validate();
        }
    }
}
