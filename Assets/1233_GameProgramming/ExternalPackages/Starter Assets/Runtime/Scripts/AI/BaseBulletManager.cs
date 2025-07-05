using UnityEngine;

public class BaseBulletManager : MonoBehaviour
{
    [Header("Physics Bullets")]
    [SerializeField] private PhysicsBullet PhysicsBulletPrefab;
    [SerializeField] private Transform Cam; // Make sure to assign in Inspector
    [SerializeField] private GameObject BulletParticle;

    protected void SpawnPhysicsBullet(Transform shootersTransform)
    {
        var spawnedBullet = Instantiate(PhysicsBulletPrefab, Cam.position, Cam.rotation);
        // Optionally add bullet logic like direction, etc.
    }

    public void OnProjectileCollision(Vector3 position, Vector3 rotation)
    {
        SpawnParticle(position, rotation);
    }

    public void SpawnParticle(Vector3 position, Vector3 rotation)
    {
        Instantiate(BulletParticle, position, Quaternion.Euler(rotation));
    }
}