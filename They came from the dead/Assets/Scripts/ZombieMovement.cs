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
        if (MainCharacterRef)
        {
            agent.SetDestination(MainCharacterRef.position);
            ChasePlayer();
            agent.speed = moveSpeed;
        }
    }

    public void ChasePlayer()
    {
        Vector3 direction = (MainCharacterRef.position - transform.position).normalized;
        moveDirection = direction;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }
}
