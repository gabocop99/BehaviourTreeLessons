using UnityEngine;

namespace BTree
{
    public class LogNode : LeafNode
    {
        public string Message = "Message";

        public LogNode(string message)
        {
            Message = message;
        }

        public override NodeState Evaluate(AThinker thinker)
        {
            thinker.Memory.AddOrEditData("LastLog", Message);
            Debug.Log(Message);
            return NodeState.Success;
        }
    }
}
