using BTree;
using UnityEngine;

namespace Project.BTree
{
    [CreateAssetMenu(menuName = "Project/Brain/Shooter", fileName = "BR_shooter")]
    public class ShooterBrain : ABrain
    {
        private const string TargetKey = "Target";
        private const string RangeKey = "Range";
        private const string SpeedKey = "Speed";

        public override BehaviourTree GetTree()
        {
            var hasTarget = new HasTargetNode(TargetKey);
            var notHasTarget = new NotNode(hasTarget);
            var searchTarget = new SearchTargetNode(TargetKey);
            var isInRange = new IsCloseToNode(RangeKey, TargetKey);
            var shoot = new LogNode("Shooting");
            var move = new MoveTowardsNode(SpeedKey, TargetKey);

            var targetSequence = new SequenceNode(notHasTarget, searchTarget);
            var rangeSequence = new SequenceNode(isInRange, shoot);
            var root = new SelectorNode(targetSequence, rangeSequence, move);
            var bt = new BehaviourTree(root);
            bt.OrderAllNodes();
            bt.RegisterToNodes();
            return bt;
        }
    }
}