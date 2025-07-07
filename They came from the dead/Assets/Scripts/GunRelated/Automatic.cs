using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automatic : Gun
{
    public override void AutomaticType()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Fire(bulletInventory.GetComponent<Inventory>().currentClip_Automatic);
            Debug.Log("Alfred");
            isPressed = true;
        }
    }

    public override void Fire(int ammo)
    {
        
        if (ammo > 0)
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(bulletPrefab, shootingPosition.position, shootingPosition.rotation);
                bulletInventory.GetComponent<Inventory>().currentClip_Automatic--;
                ammo--;
            }

        }
    }
}
