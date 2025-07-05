using UnityEngine;
using StarterAssets;

public class BulletShooter : MonoBehaviour
{
    [Header("Prefabs & Effects")]
    public GameObject bulletPrefab; // Bullet prefab with Rigidbody + BulletBehavior script
    public Transform shootOrigin;   // Where bullets spawn from
    public ParticleSystem muzzleFlash; // Muzzle flash VFX
    public GameObject impactEffectPrefab; // Impact effect prefab (e.g. sparks or blood)

    [Header("Audio")]
    public AudioSource audioSource;       // AudioSource for shooting sound
    public AudioClip shootClip;           // Shooting sound effect

    [Header("Bullet Settings")]
    public float bulletSpeed = 20f;
    public float maxRayDistance = 100f;
    public LayerMask hitLayers; // Layers to detect ray hits (e.g., Enemy, Default)

    private StarterAssetsInputs input;

    void Start()
    {
        input = GetComponent<StarterAssetsInputs>();
        if (input == null)
        {
            input = FindAnyObjectByType<StarterAssetsInputs>();
        }

        if (shootOrigin == null)
        {
            Debug.LogError("shootOrigin is not assigned! Please set it in the Inspector.");
        }
    }

    void Update()
    {
        if (input != null && input.shoot)
        {
            Fire();
        }
    }

    void Fire()
    {
        // Play muzzle flash
        if (muzzleFlash != null)
            muzzleFlash.Play();

        // Play shoot sound
        if (audioSource != null && shootClip != null)
            audioSource.PlayOneShot(shootClip);

        // Raycast logic
        Ray ray = new Ray(shootOrigin.position, shootOrigin.forward);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxRayDistance, hitLayers))
        {
            Debug.Log("Hit object: " + hitInfo.collider.name);

            // Spawn impact effect
            if (impactEffectPrefab != null)
            {
                Instantiate(impactEffectPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            }
        }

        // Spawn bullet projectile
        if (bulletPrefab != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootOrigin.position, shootOrigin.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = shootOrigin.forward * bulletSpeed;
            }
        }
    }
}
