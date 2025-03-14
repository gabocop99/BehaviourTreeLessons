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
            var updateCurrentTarget = new UpdateCurrentTargetNode("CurrentIndex", "Points", TargetKey); //check if it has target
            var searchTarget = new SearchTargetNode(TargetKey); //if !hasTarget: searchTarget
            var nextIndex = new NextIndexNode("CurrentIndex", "Points");
            
            //check distance
            var isCloseTo = new IsCloseToNode("MinDistance", TargetKey);
            var moveTo = new MoveTowardsNode("Speed", TargetKey); //if it has: MoveTowards
            var failNode = new FailureNode(updateCurrentTarget);
            
            //shoot
            var shoot = new ShootNode("BulletSpeed", TargetKey);
                
            //sequence & root
            var sequence = new SequenceNode(searchTarget, isCloseTo, nextIndex);
            var root = new SelectorNode(failNode, sequence, failNode, moveTo, shoot);
            
            var bt = new BehaviourTree(root);
            bt.OrderAllNodes();
            bt.RegisterToNodes();

            return bt;
        }
    }
}
