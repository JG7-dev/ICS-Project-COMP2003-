using UnityEngine;
using UnityEngine.AI;

public class AiMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] float maxHealth = 100f;
    float currentHp;
    [Range(0, 100)] [SerializeField] private float speed;
    [Range(0, 500)] [SerializeField] private float walkRadius;

    // Start is called before the first frame update
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null) return;
        agent.speed = speed;
        agent.SetDestination(RandomLocation());
        currentHp = maxHealth;
    }

    // Update is called once per frame
    private void Update()
    {
        if (agent != null && agent.remainingDistance <= agent.stoppingDistance) agent.SetDestination(RandomLocation());
    }

    private Vector3 RandomLocation()
    {
        Vector3 finalPos = Vector3.zero;
        Vector3 randomPos = Random.insideUnitSphere * walkRadius;
        randomPos += transform.position;
        if (NavMesh.SamplePosition(randomPos, out var hit, walkRadius, 1)) finalPos = hit.position;
        return finalPos;
    }
    public void Takedamage(float damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            Die();
        }
        }
    void Die()
    {
        print(name + "was killed");
        Destroy(gameObject);

    }
}