using UnityEngine;

public class BulletMover : MonoBehaviour
{
    public float speed = 25f; // Bullet speed
    public float lifeTime = 5f; // Auto-destroy after time

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * speed;

        // Destroy bullet after some time
        Destroy(gameObject, lifeTime);
    }
}
