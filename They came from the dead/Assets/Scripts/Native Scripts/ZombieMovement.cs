using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
    public Transform MainCharacterRef;
    NavMeshAgent agent;

    private Vector2 moveDirection;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;

    public float AttackRange;

    public float Damage;
    [SerializeField] private float lastAttackTime;
    public float AttackDelay;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        agent = GetComponent<NavMeshAgent>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //AttackPlayer();
        //AttackPlayer();

        if (MainCharacterRef)
        {
            agent.SetDestination(MainCharacterRef.position);
            ChasePlayer();
            agent.speed = moveSpeed;

            //AttackPlayer();
        }
        //if (MainCharacterRef)
        //{
        //    float distanceToPlayer = Vector3.Distance(transform.position, MainCharacterRef.position);

        //    if (distanceToPlayer > AttackRange)
        //    {
        //        // Move towards player
        //        agent.isStopped = false;
        //        agent.speed = moveSpeed;
        //        agent.SetDestination(MainCharacterRef.position);
        //        ChasePlayer();
        //    }
        //    else
        //    {
        //        // Stop when close enough to attack
        //        agent.isStopped = true;
        //        agent.velocity = Vector3.zero; // Optional: stops momentum
        //        AttackPlayer();
        //    }
        //}
    }

    public void ChasePlayer()
    {
        Vector3 direction = (MainCharacterRef.position - transform.position).normalized;
        moveDirection = direction;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }

    public void AttackPlayer()
    {
        Debug.Log("ZOMBIEATTACL");
        if (Time.time > lastAttackTime + AttackDelay)
        {
            //Finds the Function inside object and activates it
            MainCharacterRef.SendMessage("TakeDamage", Damage);
            lastAttackTime = Time.time;
        }
    }
}
