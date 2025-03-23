using System;
using UnityEngine;

public class TopDownEnemy : MonoBehaviour
{
    public float Speed;
    public int MagazineSize;
    [SerializeField] private int _currentMagazine;

    public int CurrentMagazine
    {
        get => _currentMagazine;
        private set => _currentMagazine = value;
    }

    public float FireRate;
    public int Damage;


    [SerializeField] private Vector2 _range;

    public Vector2 Range
    {
        get => _range;
        private set => _range = value;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _range.y);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range.x);
    }

    private void Awake()
    {
        CurrentMagazine = MagazineSize;
    }
}