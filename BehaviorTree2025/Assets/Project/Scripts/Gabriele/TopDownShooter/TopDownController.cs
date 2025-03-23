using UnityEngine;

public class TopDownController : MonoBehaviour
{
    private Vector2 _direction;
    private float _evaluatedSpeed;

    [SerializeField] private float _speed;

    void Update()
    {
        _evaluatedSpeed = Input.GetKey(KeyCode.LeftShift) ? _speed * 2 : _speed;
        
        if (Input.GetKey(KeyCode.W))
        {
            _direction += Vector2.up;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _direction += Vector2.left;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _direction += Vector2.down;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _direction += Vector2.right;
        }

        _direction.Normalize();
        transform.position += new Vector3(_direction.x, 0, _direction.y) * (_evaluatedSpeed * Time.deltaTime);
        _direction = Vector2.zero;
    }
}