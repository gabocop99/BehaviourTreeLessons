using BTree;
using UnityEngine;

namespace Project.BTree
{
    [CreateAssetMenu(menuName = "Project/Brain/Shoot", fileName = "BR_shoot")]
    public class ShootBrain : ABrain
    {
        private const string TargetKey = "Target";
        public override BehaviourTree GetTree()
        {
            //1- check for player
            //2- if false → look for player 
            //2- if true →
            //4- check playerDistance <= distance 
            //6- true = shoot at player
            //6- false = move towards player
            
            //check detection
            var hasTarget = new CheckTargetNode(TargetKey);
            var notHasTarget = new NotNode(hasTarget);
            var searchTarget = new SearchTargetNode(TargetKey); //if !hasTarget: searchTarget
            
            //check distance
            var isCloseTo = new IsCloseToNode("Distance", TargetKey);
            var isFarFrom = new NotNode(isCloseTo);
            var moveTo = new MoveTowardsNode("Speed", TargetKey); //if it has: MoveTowards
            
            //shoot
            var shoot = new ShootNode("BulletSpeed", TargetKey);
                
            //sequence & root
            var sequenceHasTarget = new SequenceNode(notHasTarget, searchTarget);
            var sequenceCheckDistance = new SequenceNode(isFarFrom, moveTo);
            var root = new SelectorNode(sequenceHasTarget, sequenceCheckDistance ,shoot);
            
            var bt = new BehaviourTree(root);
            bt.OrderAllNodes();
            bt.RegisterToNodes();

            return bt;
        }
    }
}
