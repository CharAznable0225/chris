using UnityEngine;

/// <summary>
/// Manages shooting logic: raycast vs projectile.
/// </summary>
public class BulletManager : MonoBehaviour
{
    public enum ShootType { Raycast, Physics }

    [Header("Camera & Settings")]
    [SerializeField] private Camera cam;
    [SerializeField] private ShootType shootType;
    [SerializeField] private LayerMask raycastMask;

    [Header("Prefabs")]
    [SerializeField] private RaycastBullet bulletParticle;
    [SerializeField] private GameObject physicsBulletPrefab;

    void Update()
    {
        // Fire when left mouse or "Fire1" button is pressed
        if (Input.GetButtonDown("Fire1"))
        {
            OnFirePressed();
        }
    }

    private void OnFirePressed()
    {
        Debug.Log("Firing projectile");

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
        // Shoot a ray from the camera forward
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
        // Spawn particle at hit point facing the hit normal
        Instantiate(bulletParticle, position, Quaternion.LookRotation(normal));
    }

    private void SpawnPhysicsBullet()
    {
        // Spawn bullet in front of the camera and use its Rigidbody to fly forward
        Instantiate(physicsBulletPrefab, cam.transform.position + cam.transform.forward, cam.transform.rotation);
    }
}