
using UnityEngine;
using UnityEngine.AI;

public class EnemyAiTutorial : MonoBehaviour
{
    public NavMeshAgent agent;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    private GameObject targetPlayer;


    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    private Transform player;

    private void Awake()
    {
        GameObject[] cloneObjects = GameObject.FindGameObjectsWithTag("Clone");

        for (int i = 0; i < cloneObjects.Length; i++)
        {
            player = cloneObjects[i].transform;

        }
        agent = GetComponent<NavMeshAgent>();
    }
        private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
      //  agent.SetDestination(player.position);
        //Debug.Log("player position"+ player.position);

        GameObject[] players = GameObject.FindGameObjectsWithTag("Clone");

        if (players.Length > 0)
        {
            int randomIndex = Random.Range(0, players.Length);
            targetPlayer = players[randomIndex];

            if (targetPlayer != null)
            {
                agent.SetDestination(targetPlayer.transform.position);
            }
        }

        
        //for (int i = 0; i < players.Length; i++)
        //{
        //    agent.SetDestination(players[randomIndex].transform.position);
        //}
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
    

        GameObject[] players = GameObject.FindGameObjectsWithTag("Clone");

        if (players.Length > 0)
        {
            int randomIndex = Random.Range(0, players.Length);
            targetPlayer = players[randomIndex];

            if (targetPlayer != null)
            {
               // agent.SetDestination(targetPlayer.transform.position);
                agent.SetDestination(targetPlayer.transform.position);

                transform.LookAt(targetPlayer.transform);
            }
        }




        if (!alreadyAttacked)
        {
            ///Attack code here
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            Vector3 raycastDirection = transform.forward;

            // Perform the raycast from the object's position
            RaycastHit hit;
            if (Physics.Raycast(transform.position, raycastDirection, out hit, 10f, whatIsPlayer))
            {
                HealthManager healthScript = hit.collider.GetComponent<HealthManager>();
                if (healthScript != null)
                {

                    healthScript.TakeDamage(20);
                }
            }
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    //public void TakeDamage(int damage)
    //{
    //    health -= damage;
    //    Debug.Log("damageeeee" + health);
    //    if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    //}
    //private void DestroyEnemy()
    //{
    //    Destroy(gameObject);
    //}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
