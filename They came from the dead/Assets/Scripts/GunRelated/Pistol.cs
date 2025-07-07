using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Pistol : Gun
{
    public override void AutomaticType()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire(bulletInventory.GetComponent<Inventory>().currentClip);
            Debug.Log("Alfred");
            isPressed = true;
        }
    }

    public override void Fire(int ammo)
    {
        if (ammo > 0)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bulletPrefab, shootingPosition.position, shootingPosition.rotation);
            bulletInventory.GetComponent<Inventory>().currentClip--;
            ammo--;

        }
    }
}
