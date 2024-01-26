using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPyhsic : MonoBehaviour
{
    //Projeden kaldýrýldý. Silahýn ateþ esnasýnda ürettiði nesne(mermi) scripti. 
    public float bulletSpeed;
    Rigidbody rigid;
    
    void Start()
    {
        StartCoroutine(Destroy());
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = transform.forward * bulletSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 force = transform.forward * 10f;
            rb.AddForce(force, ForceMode.Impulse);
            Debug.Log("Çarpýþtý");
        }
        Debug.Log(other.gameObject.tag);
        this.gameObject.SetActive(false);
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3.5f);
        this.gameObject.SetActive(false);
    }
}
