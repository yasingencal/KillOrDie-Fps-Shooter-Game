using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    //UI bileþenlerine ulaþtýðýmýz UI Manager
    public static UIManager UImanager;

    public GameObject InventoryUI;
    public TextMeshProUGUI ammoUI;
    public TextMeshProUGUI storageAmmoUI;
    private void Awake()
    {
        UImanager = this;
    }

    //Update sonraki adýmlarda kaldýrýlacak ve ý tuþ atamasý baþka yere taþýnacak
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (InventoryUI.active == false)
            {
                InventoryUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                InventoryUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
            
        }
    }

}
