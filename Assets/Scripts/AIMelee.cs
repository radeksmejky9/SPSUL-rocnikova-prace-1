using UnityEngine;
using UnityEngine.AI;

public class AIMelee : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, WhatIsPlayer;


    public Vector3 walkPoint;
    public float walkPointRange;
    float lastframe = 0;

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
        if (!gameObject.GetComponent<Animator>().GetBool("Dead") && player.GetComponent<DamageDetector>().hp > 0)
        {
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, WhatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, WhatIsPlayer);



            if (lastframe == 0)
            {
                lastframe = gameObject.transform.position.z;
            }

            if (!(gameObject.GetComponent<Rigidbody>().transform.position.z == lastframe))
            {
                gameObject.GetComponent<Animator>().SetBool("Run", true);
            }
            else
            {
                gameObject.GetComponent<Animator>().SetBool("Run", false);
            }
            lastframe = gameObject.transform.position.z;





            if (playerInSightRange && playerInAttackRange)
            {
                gameObject.GetComponent<Animator>().SetBool("Shoot", true);
                Attacking();
            }
            if (playerInSightRange && !playerInAttackRange)
                Chasing();


        }
    }

    private void Chasing()
    {
        agent.SetDestination(player.position);
        if (player.position.z > transform.position.z)
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        else
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);

    }
    private void Attacking()
    {
        agent.SetDestination(transform.position);
        if (player.position.z > transform.position.z)
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        else
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        if (!alreadyAttacked)
        {
            player.GetComponent<DamageDetector>().TakeDamage(20);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        gameObject.GetComponent<Animator>().SetBool("Shoot", false);
        alreadyAttacked = false;
    }

}
