using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementSystem : MonoBehaviour
{
    // Kameranýn mouse girdilerine göre hareketini saðlayan ve bobbing dediðimiz hareket halinde titreþim yaparak gerçekçilik katan script
    public float MouseSensitivity;
    public Transform PlayerBody;
    float xRotation = 0f;
    float yRotation = 0f;

    //Bobbing
    public float bobbingHeight;
    public float bobbingSpeed;
    public float midpoint;

    private float timer = 0.0f;

    public float damp;

    float mouseX, mouseY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {

        mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.fixedDeltaTime;
        mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.fixedDeltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -70f, 70f);

        yRotation += mouseX;

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        Quaternion targetRotation = Quaternion.Euler(0, yRotation, 0);
        PlayerBody.localRotation = Quaternion.Slerp(PlayerBody.localRotation, targetRotation, damp);

        //Düzeltme lazým
        timer += PlayerMovement.playerMovement.vertical * bobbingSpeed * Time.deltaTime;
        float yBob = Mathf.Sin(timer) * bobbingHeight;

        transform.localPosition = new Vector3(transform.localPosition.x, midpoint + yBob, transform.localPosition.z);
    }
}
