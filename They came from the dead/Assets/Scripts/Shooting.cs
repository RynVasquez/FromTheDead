using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shooting : MonoBehaviour
{
    public TextMeshProUGUI clip_Pistol;
    public TextMeshProUGUI clip_Shotgun;
    public TextMeshProUGUI clip_Automatic;
    public InterfaceManager interfaceManagerReference;

    private bool isPressed = false;

    [SerializeField] private Inventory bulletInventory;
    [SerializeField] private Pistol pistol;
    [SerializeField] private Shotgun shotgun;
    [SerializeField] private Automatic automatic;

    // Update is called once per frame
    void Update()
    {
        AutomaticType();

    }

    public void AutomaticType()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("READYORNOT");
            Fire();
        }
    }

    //private IEnumerator FireContinuously()
    //{
    //    while (isPressed)
    //    {
    //        Fire();
    //        yield return null;
    //    }
    //}

    public void Fire()
    {
        isPressed = true;

        if (bulletInventory.GetComponent<Inventory>().currentEquipWeaponReference == CurrentEquipWeapon.pistol)
        {
            pistol.Fire(bulletInventory.GetComponent<Inventory>().currentClip);
            //interfaceManagerReference.UpdateClipCount(bulletInventory.GetComponent<Inventory>().currentClip);
            //bulletPrefab.GetComponent<BulletMovement>().damage = 10;
        }

        if (bulletInventory.GetComponent<Inventory>().currentEquipWeaponReference == CurrentEquipWeapon.shotgun)
        {
            shotgun.Fire(bulletInventory.GetComponent<Inventory>().currentClip_Shotgun);
            //interfaceManagerReference.UpdateClipCount(bulletInventory.GetComponent<Inventory>().currentClip_Shotgun);
            //bulletPrefab.GetComponent<BulletMovement>().damage = 10;
        }

        if (bulletInventory.GetComponent<Inventory>().currentEquipWeaponReference == CurrentEquipWeapon.automatic && isPressed == true)
        {
            automatic.Fire(bulletInventory.GetComponent<Inventory>().currentClip_Automatic);
            //interfaceManagerReference.UpdateClipCount(bulletInventory.GetComponent<Inventory>().currentClip_Automatic);
            //bulletPrefab.GetComponent<BulletMovement>().damage = 15;
        }
    }

    public void Reload()
    {
        Debug.Log("Wayer");
        bulletInventory.GetComponent<Inventory>().OverallReload();
    }
}
