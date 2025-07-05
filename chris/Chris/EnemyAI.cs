using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public enum AIState { Patrol, Chase, Attack }

    [Header("References")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private Transform player;
    [SerializeField] private Animator animator;

    [Header("Detection")]
    [SerializeField] private float detectionRadius = 10f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float fieldOfView = 120f;

    [Header("Attack Settings")]
    [SerializeField] private float attackCooldown = 2f;
    private float lastAttackTime;

    [Header("Health Settings")]
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    private int currentWaypointIndex = 0;
    private AIState currentState = AIState.Patrol;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth; 
    }

    void Update()
    {
        if (isDead) return; // Dead enemies do nothing

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Debug.Log($"distance to Player{distanceToPlayer}");
        Debug.Log($"Check the AI{currentState}");

        switch (currentState)
        {
            case AIState.Patrol:
                Patrol();
                if (IsPlayerInSight())
                    SwitchState(AIState.Chase);
                break;

            case AIState.Chase:
                agent.SetDestination(player.position);
                animator.SetBool("IsWalking", true);

                if (distanceToPlayer <= attackRange)
                    SwitchState(AIState.Attack);
                else if (!IsPlayerInSight())
                    SwitchState(AIState.Patrol);
                break;

            case AIState.Attack:
                agent.ResetPath();
                animator.SetBool("IsWalking", false);
                transform.LookAt(player);

                if (Time.time - lastAttackTime >= attackCooldown)
                {
                    animator.SetTrigger("Attack");
                    lastAttackTime = Time.time;
                }

                if (distanceToPlayer > attackRange)
                    SwitchState(AIState.Chase);
                break;
        }
    }

    private void Patrol()
    {
        if (waypoints.Length == 0) return;

        agent.SetDestination(waypoints[currentWaypointIndex].position);
        animator.SetBool("IsWalking", true);

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    private bool IsPlayerInSight()
    {
        Vector3 dirToPlayer = (player.position - transform.position).normalized;
        float angle = Vector3.Angle(transform.forward, dirToPlayer);
        return Vector3.Distance(transform.position, player.position) <= detectionRadius && angle < fieldOfView * 0.5f;
    }

    private void SwitchState(AIState newState)
    {
        currentState = newState;
        Debug.Log("Switched to state: " + newState);
    }

    // Called externally by PlayerShooter when hit
    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        Debug.Log("Enemy took damage: " + amount + " Current HP: " + currentHealth);

        // TODO: Add hit visual/sound feedback here

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        Debug.Log("Enemy died.");
        animator.SetTrigger("Die");
        agent.isStopped = true;
        Destroy(gameObject, 3f); // Destroy after animation
    }
    void Awake()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
    }
}