using UnityEngine;
using StarterAssets;

public class PlayerShooter : MonoBehaviour
{
    [Header("Prefabs & Effects")]
    public GameObject bulletPrefab;             
    public Transform shootOrigin;               
    public ParticleSystem muzzleFlash;          
    public GameObject impactEffectPrefab;       

    [Header("Audio")]
    public AudioSource audioSource;            
    public AudioClip shootClip;                 

    [Header("Bullet Settings")]
    public float bulletSpeed = 20f;            
    public float maxRayDistance = 100f;         
    public LayerMask hitLayers;                 

    [Header("Cooldown")]
    public float fireCooldown = 0.2f;           
    private float fireTimer = 0f;               

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
            Debug.LogError("shootOrigin is not assigned!");
        }
    }

    void Update()
    {
        fireTimer -= Time.deltaTime;

        if (input != null && input.shoot && fireTimer <= 0f)
        {
            Fire();
            fireTimer = fireCooldown;
        }
    }

    void Fire()
    {
        
        if (muzzleFlash != null)
        {
            muzzleFlash.Play();
        }

        
        if (audioSource != null && shootClip != null)
        {
            audioSource.PlayOneShot(shootClip);
        }

        // Raycast hit
        Ray ray = new Ray(shootOrigin.position, shootOrigin.forward);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxRayDistance, hitLayers))
        {
            Debug.Log("Ray hit: " + hitInfo.collider.name);

            if (impactEffectPrefab != null)
            {
                Instantiate(impactEffectPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            }
        }

        
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