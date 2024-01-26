using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using System.Threading;


public class PistolRecoilSystem : MonoBehaviour
{
    //Tabanca için tüm silah hareketleri = reload tetiklemek için input alma, sol týk ile ateþ etme , silahýn tepmesi , ses efekti , flash efekti gibi silaha özgü olan tüm herþey
    //Raycast ile ýþýn göndererek Rigidbody bileþenine sahip nesneler ile etkileþimde bulunan script(ateþ etme)
    public Transform aimPosition;
    public GameObject bullet;
    public Transform bulletExitPosition;
    AudioSource audio;


    [SerializeField] private float recoilUp;
    [SerializeField] private float recoilHorizontal;
    [SerializeField] private VisualEffect muzzleFlash;
    public float recoilSpeed;
    public float recoilResetSpeed;

    bool rayActivate = false;
    
    Quaternion resetRotation;
    Quaternion recoilRotation;
    Vector3 resetPosition;

    int bulletCapacity = 12;
    int currentBullet = 12;
    
    void Start()
    {
        resetRotation = transform.localRotation;
        resetPosition = transform.localPosition;
        audio = GetComponent<AudioSource>();
        UIManager.UImanager.ammoUI.text = "" + currentBullet;
    }

    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.R) && InventorySystemandFunctions.inventorySystem.ReloadContol())
        {
            AnimationController.animationController.Reload();
            currentBullet += InventorySystemandFunctions.inventorySystem.transferredAmmo;
            UIManager.UImanager.ammoUI.text = "" + currentBullet;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (currentBullet > 0)
            {
                Shoot();
                currentBullet--;
                InventorySystemandFunctions.inventorySystem.needAmmo = bulletCapacity - currentBullet;
                UIManager.UImanager.ammoUI.text = "" + currentBullet;
            }
        }
        if (Input.GetMouseButton(1))
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, aimPosition.localPosition, 5f * Time.deltaTime);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, aimPosition.localRotation, 5f * Time.deltaTime);
        }
        else
        {
            if (transform.localRotation != resetRotation)
            {
                transform.localRotation = Quaternion.Slerp(transform.localRotation, resetRotation, recoilResetSpeed * Time.deltaTime);
            }

            if (transform.localPosition != resetPosition)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, resetPosition, 5f * Time.deltaTime);
            }
        }
        
    }
    

    public void Shoot()
    {


        Ray ray = new Ray(bulletExitPosition.transform.position, bulletExitPosition.transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 350f))
        {
            Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 force = ray.direction * 45f;
                rb.AddForce(force, ForceMode.Impulse);
            }
        }
        recoilRotation = Quaternion.Euler(transform.localRotation.x - recoilUp, 0, 0);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, recoilRotation, recoilSpeed * Time.deltaTime);
        muzzleFlash.Play();
        audio.Play();
    }

}
