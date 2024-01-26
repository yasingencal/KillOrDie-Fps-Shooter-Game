using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    //UI bile�enlerine ula�t���m�z UI Manager
    public static UIManager UImanager;

    public GameObject InventoryUI;
    public TextMeshProUGUI ammoUI;
    public TextMeshProUGUI storageAmmoUI;
    private void Awake()
    {
        UImanager = this;
    }

    //Update sonraki ad�mlarda kald�r�lacak ve � tu� atamas� ba�ka yere ta��nacak
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
