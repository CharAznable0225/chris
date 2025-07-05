using UnityEngine;

/// <summary>
/// Placeholder for raycast bullet visual effects.
/// </summary>
public class RaycastBullet : MonoBehaviour
{
    [SerializeField] private float lifetime = 1.5f;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }
}
