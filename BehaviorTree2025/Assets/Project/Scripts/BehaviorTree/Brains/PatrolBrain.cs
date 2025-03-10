using BTree;
using UnityEngine;

namespace Project.BTree
{
    [CreateAssetMenu(menuName = "Project/Brain/Patrol", fileName = "BR_patrol")]
    public class PatrolBrain : ABrain
    {
        private const string TargetKey = "Target";

        public override BehaviourTree GetTree()
        {
            var isCloseTo = new IsCloseToNode("MinDistance", TargetKey);
            var lookAround = new LookAroundNode("LookAroundTime", "LookAroundAngle");
            var wait1 = new WaitNode(1);
            var wait2 = new WaitNode(2);
            var nextIndex = new NextIndexNode("CurrentIndex", "Points");
            var updateCurrentTarget = new UpdateCurrentTargetNode("CurrentIndex", "Points", TargetKey);
            var failNode = new FailureNode(updateCurrentTarget);
            var moveTo = new MoveTowardsNode("Speed", TargetKey);
            var sequence = new SequenceNode(isCloseTo, wait1, lookAround, wait2, nextIndex);
            var root = new SelectorNode(failNode, sequence, moveTo);
            var bt = new BehaviourTree(root);
            bt.OrderAllNodes();
            bt.RegisterToNodes();
            return bt;
        }
    }
}
