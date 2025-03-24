using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;

    private void Update()
    {
        transform.Translate(transform.forward * (Speed * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
