using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public enum ShootType { Raycast, Physics }

    [Header("Camera & Settings")]
    [SerializeField] private Camera cam; // Main camera for aiming
    [SerializeField] private ShootType shootType = ShootType.Raycast; // Choose between Raycast or Physics mode
    [SerializeField] private LayerMask raycastMask; // Layers that the raycast can hit

    [Header("Prefabs")]
    [SerializeField] private GameObject bulletParticle; // Bullet impact particle effect (GameObject prefab)
    [SerializeField] private GameObject physicsBulletPrefab; // Bullet prefab with Rigidbody & Collider

    [Header("Animation")]
    [SerializeField] private Animator animator; // Reference to Animator for firing animation
    [SerializeField] private string shootTrigger = "Shoot"; // Trigger name in Animator Controller

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Left mouse button
        {
            OnFirePressed();
        }
    }

    private void OnFirePressed()
    {
        Debug.Log("Firing projectile");

        // Play shoot animation if Animator is assigned
        if (animator != null && !string.IsNullOrEmpty(shootTrigger))
        {
            animator.SetTrigger(shootTrigger);
        }

        // Fire based on selected mode
        switch (shootType)
        {
            case ShootType.Raycast:
                DoRaycastShot();
                break;
            case ShootType.Physics:
                SpawnPhysicsBullet();
                break;
        }
    }

    private void DoRaycastShot()
    {
        // Send a ray forward from the camera
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, 1000f, raycastMask))
        {
            Debug.Log("Raycast hit: " + hit.collider.name);
            SpawnParticle(hit.point, hit.normal);
        }
        else
        {
            Debug.Log("Raycast miss");
        }
    }

    private void SpawnParticle(Vector3 position, Vector3 normal)
    {
        if (bulletParticle != null)
        {
            GameObject vfx = Instantiate(bulletParticle, position, Quaternion.LookRotation(normal));
            Destroy(vfx, 2f); // Destroy the particle effect after 2 seconds
        }
    }

    private void SpawnPhysicsBullet()
    {
        if (physicsBulletPrefab != null)
        {
            // Instantiate the bullet a little in front of the camera
            GameObject bullet = Instantiate(physicsBulletPrefab, cam.transform.position + cam.transform.forward, cam.transform.rotation);

            // Apply forward force
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(cam.transform.forward * 1000f); // Adjust force as needed
            }
        }
    }
}