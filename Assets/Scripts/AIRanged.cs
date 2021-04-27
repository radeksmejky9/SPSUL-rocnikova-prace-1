using UnityEngine;
using UnityEngine.AI;

public class AIRanged : MonoBehaviour
{
    public NavMeshAgent agent;
    float lastframe;
    public Transform player;
    public GameObject projectile;

    public LayerMask whatIsGround, WhatIsPlayer;


    public Vector3 walkPoint;

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
        if (!gameObject.GetComponent<Animator>().GetBool("Dead") && player.GetComponent<DamageDetector>().hp > 0)
        {

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




            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, WhatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, WhatIsPlayer);



            if (playerInSightRange && playerInAttackRange)
            {
                Attacking();
                gameObject.GetComponent<Animator>().SetBool("Shoot", true);
            }
            else
            {
                gameObject.GetComponent<Animator>().SetBool("Shoot", false);
            }
            if (playerInSightRange && !playerInAttackRange)
            {
                Chasing();
                gameObject.GetComponent<Animator>().SetBool("Run", true);
            }
            else
            {
                gameObject.GetComponent<Animator>().SetBool("Run", false);
                gameObject.GetComponent<Animator>().SetBool("Shoot", false);

            }


        }
    }



    private void Chasing()
    {
        if (player.position.z > transform.position.z)
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        else
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);

        agent.SetDestination(player.position);
    }
    private void Attacking()
    {
        agent.SetDestination(transform.position);

        if (player.position.z > transform.position.z)
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        else
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);


        if (!gameObject.GetComponent<Animator>().GetBool("Dead") && player.GetComponent<DamageDetector>().hp > 0)
        {
            if (!alreadyAttacked)
            {
                Vector3 t = new Vector3(transform.position.x, transform.position.y + 0.9f, transform.position.z);
                Rigidbody rb = Instantiate(projectile, t, Quaternion.identity).GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * 0.03f, ForceMode.Impulse);


                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }
        }
    }
    private void ResetAttack()
    {
        if (!gameObject.GetComponent<Animator>().GetBool("Dead") && player.GetComponent<DamageDetector>().hp > 0)
            alreadyAttacked = false;
    }

}
