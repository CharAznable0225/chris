using UnityEngine;

public class PhysicsBullet : MonoBehaviour
{
    [Tooltip("Time in seconds before bullet self-destructs")]
    public float lifetime = 3f;

    void Start()
    {
        // Destroy bullet after lifetime expires to avoid clutter
        Destroy(gameObject, lifetime);
    }

    // Optional: handle collision event (e.g., damage or effect)
    private void OnCollisionEnter(Collision collision)
    {
        // You can add logic here, like spawning effects or dealing damage

        // Destroy bullet on impact
        Destroy(gameObject);
    }
}