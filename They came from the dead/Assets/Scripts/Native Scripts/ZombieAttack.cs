using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public float AttackRange;
    public float Damage;
    [SerializeField] private float lastAttackTime;
    public float AttackDelay;

    public ZombieMovement ZombieMovementVar;

    private bool playerInRange = false;
    private Transform playerTransform;

    void Update()
    {
        if (playerInRange && playerTransform != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
            if (distanceToPlayer <= AttackRange && Time.time > lastAttackTime + AttackDelay)
            {
                ZombieMovementVar.MainCharacterRef = playerTransform;
                ZombieMovementVar.AttackPlayer();
                lastAttackTime = Time.time;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        MainCharacter mainChar = col.GetComponent<MainCharacter>();
        if (mainChar != null)
        {
            playerInRange = true;
            playerTransform = col.transform;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        MainCharacter mainChar = col.GetComponent<MainCharacter>();
        if (mainChar != null)
        {
            playerInRange = false;
            playerTransform = null;
        }
    }
}
