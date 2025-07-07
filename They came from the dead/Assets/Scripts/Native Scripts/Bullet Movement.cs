using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed;
    public float destroyDelay = 5f;
    public int damage;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
        Destroy(gameObject, destroyDelay);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        HealthComponent health = col.GetComponent<HealthComponent>();
        if (health != null)
        {
            health.TakeDamage(damage);
            Destroy(gameObject); // destroy bullet on hit
        }
    }
}
