using UnityEngine;

public class AIBulletManager : BaseBulletManager
{
    [SerializeField] private Transform BulletSpawnPoint;

    void Update()
    {
        // Example: simple AI trigger
        if (Time.frameCount % 120 == 0)
        {
            Fire();
        }
    }

    private void Fire()
    {
        SpawnPhysicsBullet(BulletSpawnPoint);
    }
}
