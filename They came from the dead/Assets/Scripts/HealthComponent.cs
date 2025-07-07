using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public enum enemyType
{
    player,
    enemy
}

public class HealthComponent : MonoBehaviour
{
    public Image healthBar;
    public float maxHealth = 100f;
    public float currentHealth;
    public enemyType enemyTypeVar;
    public bool test;

    [SerializeField] private Slider slider;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform healthTarget;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    private void Start()
    {
        currentHealth = maxHealth;

        if(healthBar)
            healthBar.fillAmount = currentHealth / maxHealth;

        if (slider)
            slider.value = currentHealth / maxHealth;
    }

    void Update()
    {
        if (slider)
        {
            slider.transform.rotation = cam.transform.rotation;
            slider.transform.position = target.position + offset;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }

        if(healthBar)
            healthBar.fillAmount = currentHealth / maxHealth;

        if(slider)
            slider.value = currentHealth / maxHealth;

        CheckHealth();
    }

    private void CheckHealth()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);

    }

}
