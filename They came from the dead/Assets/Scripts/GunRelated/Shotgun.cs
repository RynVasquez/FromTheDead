using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    [SerializeField] private float offset;
    public int pellets = 8; // Number of pellets per shot
    public float spreadAngle = 30f; // Spread angle of pellets

    public override void AutomaticType()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire(bulletInventory.GetComponent<Inventory>().currentClip_Shotgun);
            Debug.Log("Alfred");
            isPressed = true;
        }
    }

    public override void Fire(int ammo)
    {
        if (ammo > 0)
        {
            nextFire = Time.time + fireRate;
            for (int i = 0; i < pellets; i++)
            {
                Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(-spreadAngle, spreadAngle));
                Instantiate(bulletPrefab, shootingPosition.position, shootingPosition.rotation * rotation);
            }
            bulletInventory.GetComponent<Inventory>().currentClip_Shotgun--;
            ammo--;

        }
    }
}
