using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public TextMeshProUGUI clip;

    [SerializeField] protected Inventory bulletInventory;
    [SerializeField] protected Shooting shooting;
    [SerializeField] protected Transform shootingPosition;
    [SerializeField] protected GameObject bulletPrefab;

    protected bool isPressed = false;

    [SerializeField] protected float fireRate;
    protected float nextFire;

    //public static Shooting instance;

    // Update is called once per frame
    public virtual void Update()
    {
        AutomaticType();

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Wayer");
            Reload();

        }
    }

    public virtual void AutomaticType()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("READYORNOT");
            //Fire(int ammo);
        }
    }

    public virtual void Fire(int ammo)
    {
        isPressed = true;

        if (ammo > 0)
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(bulletPrefab, shootingPosition.position, shootingPosition.rotation);
                bulletInventory.GetComponent<Inventory>().currentClip--;
            }
            
        }
    }

    public void Reload()
    {
        bulletInventory.GetComponent<Inventory>().OverallReload();
    }
}
