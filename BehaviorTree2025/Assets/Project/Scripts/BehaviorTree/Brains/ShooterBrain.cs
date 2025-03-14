using UnityEngine;
using BTree;

namespace Project.BTree
{
    [CreateAssetMenu(menuName = "Project/Brain/Shooter", fileName = "BR_Shooter")]
    public class ShooterBrain : ABrain
    {
        private const string TargetKey = "Target";

        public override BehaviourTree GetTree()
        {
            var moveTowardsTarget = new MoveTowardsNode("Speed", TargetKey);
            var isCloseTo = new IsCloseToNode("Distance", TargetKey);
            var shoot = new ShootNode();
            var shootSequence = new SequenceNode(isCloseTo, shoot);
            var hasTarget = new HasTargetNode("Target");
            var searchTarget = new SearchTargetNode("Target");
            var notNode = new NotNode(hasTarget);
            var targetSearchSequence = new SequenceNode(notNode, searchTarget);
            var root = new SelectorNode(targetSearchSequence, shootSequence, moveTowardsTarget);
            var bt = new BehaviourTree(root);
            return bt;
        }
    }
}