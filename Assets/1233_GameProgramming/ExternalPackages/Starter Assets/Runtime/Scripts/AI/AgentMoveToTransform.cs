using UnityEngine;
using UnityEngine.AI;

public class MoveToTransformAgent : MonoBehaviour
{
    [SerializeField] private Transform MoveToPoint;
    [SerializeField] private NavMeshAgent NavMeshAgent;

    void Update()
    {
        if (PlayerLocatorSingleton.Instance != null)
        {
            NavMeshAgent.SetDestination(PlayerLocatorSingleton.Instance.transform.position);
        }
    }
}