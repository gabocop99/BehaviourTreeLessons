using System.Collections.Generic;
using UnityEngine;

namespace BTree
{
    public class IsNearObstaclesNode : LeafNode
    {
        private string _obstacleDetectionDistanceKey;
        private string _obstacleDetectionAngleKey;
        private string _obstacleDetectionRaysKey;

        public IsNearObstaclesNode(string obstacleDetectionDistanceKey, string obstacleDetectionAngleKey,
            string obstacleDetectionRaysKey)
        {
            _obstacleDetectionDistanceKey = obstacleDetectionDistanceKey;
            _obstacleDetectionAngleKey = obstacleDetectionAngleKey;
            _obstacleDetectionRaysKey = obstacleDetectionRaysKey;
        }

        protected override NodeState EvaluationMethod(AThinker thinker)
        {
            TryGetMemory(0f, thinker, _obstacleDetectionDistanceKey, out float distance);
            TryGetMemory(0f, thinker, _obstacleDetectionAngleKey, out float angle);
            TryGetMemory(0, thinker, _obstacleDetectionRaysKey, out int raysNumber);

            Vector3 forward = thinker.transform.forward;
            Vector3 origin = thinker.transform.position;
            float angleBetweenRays = angle / raysNumber;
            float halfAngle = angle / 2;

            List<Vector3> directions = new();

            for (int i = 0; i < raysNumber; i++)
            {
                //get current angle
                var currentAngle = -halfAngle + (i * angleBetweenRays);

                //get rotation to apply to forward direction
                Quaternion rotation = Quaternion.Euler(0, currentAngle, 0);
                Vector3 direction = rotation * forward;

                //shoot raycast
                Vector3 rayVector;
                if (Physics.Raycast(origin, direction, out RaycastHit hit, distance))
                {
                    rayVector = hit.point - origin;
                }
                else
                {
                    rayVector = direction * distance;
                }
                
                directions.Add(rayVector);
            }
            
            //sum rayVectors
            
        }
    }
}