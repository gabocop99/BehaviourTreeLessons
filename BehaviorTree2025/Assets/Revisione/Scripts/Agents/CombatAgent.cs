using UnityEngine;

namespace Revisione.Scripts.Agents
{
    public class CombatAgent : MonoBehaviour
    {
        public float MaxRange;
        public float MinRange;
        public float Speed;
        public float ShootInterval;
        public float IdleTime;

        public bool IsIdle;
    }
}