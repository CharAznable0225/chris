using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public GameObject impactEffectPrefab;
    public float destroyDelay = 2f;
    public LayerMask hitLayers;

    void OnCollisionEnter(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & hitLayers) != 0)
        {
            Debug.Log("Bullet hit: " + collision.gameObject.name);

            if (impactEffectPrefab != null)
            {
                Instantiate(impactEffectPrefab, transform.position, Quaternion.identity);
            }

            Destroy(gameObject); // Destroy bullet on impact
        }
    }

    void Start()
    {
        Destroy(gameObject, destroyDelay); // Self-destroy if not hitting anything
    }
}
