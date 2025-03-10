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
            var nextIndex = new NextIndexNode("CurrentIndex", "Points");
            var updateCurrentTarget = new UpdateCurrentTargetNode("CurrentIndex", "Points", TargetKey);
            var notNode = new NotNode(updateCurrentTarget);
            var moveTo = new MoveTowardsNode("Speed", TargetKey);
            var sequence = new SequenceNode(isCloseTo, nextIndex);
            var root = new SelectorNode(notNode, sequence, moveTo);
            return new BehaviourTree(root);
        }
    }
}
