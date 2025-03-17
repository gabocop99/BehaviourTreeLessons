using BTree;
using UnityEngine;

namespace Project.BTree
{
    [CreateAssetMenu(menuName = "Project/BehaviourTree2025/ShooterBrain", fileName = "ShooterBrain")]
    public class ShooterBrain : ABrain
    {
        private const string TargetShooting = "Target";

        public override BehaviourTree GetTree()
        {
            MoveTowardsNode moveTo = new MoveTowardsNode("Speed", TargetShooting);
            CheckTargetNode checkTargetNode = new CheckTargetNode(TargetShooting);
            FindTargetNode findTargetNode = new FindTargetNode(TargetShooting);
            ShootingNode shootingNode = new ShootingNode(TargetShooting);
            CanShootNode canShootNode = new CanShootNode("ShootingDistance", TargetShooting);
            SequenceNode shootSequence = new SequenceNode(canShootNode, shootingNode);
            SelectorNode targetSelector = new SelectorNode(checkTargetNode, findTargetNode);
            FailureNode failNode = new FailureNode(targetSelector);
            SelectorNode root = new SelectorNode(failNode, shootSequence, moveTo);
            BehaviourTree bt = new(root);
            bt.OrderAllNodes();
            bt.RegisterToNodes();
            return bt;
        }
    }
}