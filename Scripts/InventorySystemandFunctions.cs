using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystemandFunctions : MonoBehaviour
{
    //Ýçerisinde mermi ve eþya tutulacak olan envanter sistemi - ayrýca silah reload sonrasý silah scriptlerine mermi aktarma
    public static InventorySystemandFunctions inventorySystem;

    int storageAmmo;
    [HideInInspector]public int transferredAmmo;
    [HideInInspector]public int needAmmo;
    private void Awake()
    {
        inventorySystem = this;
    }
    void Start()
    {
        storageAmmo = 100;
        needAmmo = 0;
        UIManager.UImanager.storageAmmoUI.text = "" + storageAmmo;
    }

    
    void Update()
    {
        
    }
    public void ReloadFinish()
    {
        AnimationController.animationController.ReloadFinish();
    }
    public bool ReloadContol()
    {
        if (needAmmo <= storageAmmo)
        {
            storageAmmo = storageAmmo - needAmmo;
            transferredAmmo = needAmmo;
            UIManager.UImanager.storageAmmoUI.text = "" + storageAmmo;
        }
        else if (needAmmo > storageAmmo)
        {
            transferredAmmo = storageAmmo;
            storageAmmo = 0;
            UIManager.UImanager.storageAmmoUI.text = "" + storageAmmo;
        }
        else if (storageAmmo == 0)
        {
            return false;
        }
        return true;
    }
}
