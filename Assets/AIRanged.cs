using UnityEngine;
using UnityEngine.AI;

public class AIRanged : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;
    public GameObject projectile;

    public LayerMask whatIsGround, WhatIsPlayer;


    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;


    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("MC").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, WhatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, WhatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange)
            Patroling();

        if (playerInSightRange && !playerInAttackRange)
            Chasing();

        if (playerInSightRange && playerInAttackRange)
            Attacking();
    }

    private void Patroling()
    {
        if (!walkPointSet)
            SearchWalkPoint();
        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;


        if (distanceToWalkPoint.magnitude < 0.1f)
            walkPointSet = false;

    }

    private void SearchWalkPoint()
    {
        float randomZ = UnityEngine.Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;

    }

    private void Chasing()
    {
        agent.SetDestination(player.position);
    }
    private void Attacking()
    {
        agent.SetDestination(transform.position);

        if (player.position.z > transform.position.z)
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        else
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);


        if (player.GetComponent<DamageDetector>().hp > 0)
            if (!alreadyAttacked)
            {
                Vector3 t = new Vector3(transform.position.x, transform.position.y + 0.9f, transform.position.z);
                Rigidbody rb = Instantiate(projectile, t, Quaternion.identity).GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * 0.03f, ForceMode.Impulse);


                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

}
