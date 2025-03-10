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

        protected override NodeState EvaluationMethod(AThinker thinker)
        {
            thinker.Memory.AddOrEditData("LastLog", Message);
            Debug.Log(Message);
            return NodeState.Success;
        }
    }
}
