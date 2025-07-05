using UnityEngine;
using StarterAssets;

public class PlayerShooter : MonoBehaviour
{
    private StarterAssetsInputs inputs;

    [Header("Shooting Settings")]
    public GameObject bulletPrefab;   // The bullet prefab to spawn
    public Transform shootOrigin;     // The position and rotation to spawn the bullet from
    public float bulletSpeed = 20f;   // Speed at which the bullet travels

    void Start()
    {
        inputs = GetComponent<StarterAssetsInputs>();
        if (inputs == null)
        {
            inputs = FindObjectOfType<StarterAssetsInputs>();
            if (inputs == null)
                Debug.LogError("StarterAssetsInputs not found in the scene.");
        }
    }

    void Update()
    {
        if (inputs != null && inputs.Shoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || shootOrigin == null)
        {
            Debug.LogWarning("Please assign bulletPrefab and shootOrigin in the inspector.");
            return;
        }

        // Instantiate the bullet prefab at shootOrigin position and rotation
        GameObject bullet = Instantiate(bulletPrefab, shootOrigin.position, shootOrigin.rotation);

        // If the bullet has a Rigidbody, give it velocity
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = shootOrigin.forward * bulletSpeed;
        }

        Debug.Log("Bullet fired!");
    }
}