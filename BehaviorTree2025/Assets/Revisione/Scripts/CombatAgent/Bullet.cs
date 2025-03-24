using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;

    private void Awake()
    {
        Destroy(gameObject, 3f);
    }

    private void Update()
    {
        transform.position += transform.forward * (Speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}