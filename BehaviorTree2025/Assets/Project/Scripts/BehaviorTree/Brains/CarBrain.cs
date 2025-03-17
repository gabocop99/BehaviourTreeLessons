using BTree;
using UnityEngine;

namespace Project.BTree
{
    [CreateAssetMenu(fileName = "Project/Brain/CarBrain", menuName = "Scriptable Objects/CarBrain")]
    public class CarBrain : ABrain
    {
        private const string CurrentSpeedKey = "CurrentSpeed";
        private const string MinSpeedKey = "MinSpeed";
        private const string MaxSpeedKey = "MaxSpeed";
        private const string AngularSpeedKey = "AngularSpeed";
        private const string ObstacleDetectionDistanceKey = "ObstacleDetectionDistance";
        


        public override BehaviourTree GetTree()
        {

            var moveForward = new MoveForwardNode(CurrentSpeedKey);
            var notMoveForward = new NotNode(moveForward);
            
            
            var root = new SelectorNode();
            var bt = new BehaviourTree(root);
            bt.OrderAllNodes();
            bt.RegisterToNodes();
            return bt;
        }
    }
}