using Unity.VisualScripting;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float Hp = 100;
    
    [SerializeField]
    private float _speed;
    public float Speed
    {
        get => _speed;
        set
        {
            _speed = Mathf.Clamp(value, 1f, _maxSpeed);
        }
    }
    
    public Vector3 Direction;
    public float DamageAngle = 30;

    public float Acceleration = 3;
    public float Deceleration = -3;

    public float AngularSpeed = 60;

    [SerializeField]
    private float _maxSpeed = 10;

    private void OnDrawGizmos()
    {
        var wallMask = LayerMask.GetMask("Wall");

        var origin = transform.position + Vector3.up * .3f;
        var direction = Quaternion.AngleAxis(-100 / 2, Vector3.up) * transform.forward;
        var angleDelta = 100 / (14);

        var optimalDirection = Vector3.zero;

        Gizmos.color = Color.yellow;

        for (var i = 0; i < 15; i++)
        {
            var ray = new Ray(origin, direction);
            if (!Physics.Raycast(ray, out var hit, 8, wallMask))
            {
                optimalDirection += direction * 8;
                Gizmos.DrawLine(origin, origin + direction * 8);
            }
            else
            {
                var distance = Vector3.Distance(origin, hit.point);
                optimalDirection += direction * distance;
                Gizmos.DrawLine(origin, origin + direction * distance);
            }
            direction = Quaternion.AngleAxis(angleDelta, Vector3.up) * direction;
        }

        optimalDirection /= 15;
        var bestDir = optimalDirection.normalized;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(origin, origin + bestDir * 5);
    }

    private void Awake()
    {
        Direction = transform.forward;
    }

    private void Update()
    {
        transform.position += Speed * Time.deltaTime * Direction;
        transform.rotation = Quaternion.LookRotation(Direction, Vector3.up);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var contactPoint = collision.contacts[0];
        if (collision.gameObject.CompareTag("Wall"))
        {
            Hp -= Speed * 3;
            var newDirection = Vector3.Reflect(Direction, contactPoint.normal);
            newDirection.y = 0;
            Direction = newDirection;
            return;
        }

        if (!collision.gameObject.TryGetComponent<Car>(out var otherCar))
        {
            return;
        }

        var directionToOther = (otherCar.transform.position - transform.position).normalized;
        var angle = Vector3.Angle(transform.forward, directionToOther);
        if (angle > DamageAngle)
        {
            return;
        }

        otherCar.Hp -= Speed * 3;
    }
}
