using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Karakterin yürüme saða sola gitme gibi hareketlerini saðlayan script
    public static PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = this;
    }

    public float MovementSpeed;
    Rigidbody rb;

    public float vertical, horizontal;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {

        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(horizontal, 0f, vertical) * MovementSpeed;
        rb.velocity = transform.right * move.x + transform.forward * move.z;
    }
    
    
}
