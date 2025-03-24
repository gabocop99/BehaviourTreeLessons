using System;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public float MovementSpeed;
    [Tooltip("x = minRange, y = maxRange")]public Vector2 Range;
    public Bullet BulletPrefab;

    [ContextMenu("Shoot")]
    public void Shoot()
    {
        Instantiate(BulletPrefab.gameObject, transform.position, transform.localRotation);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Range.x);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range.y);
    }
}
