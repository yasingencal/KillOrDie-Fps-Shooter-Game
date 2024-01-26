using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Fiziksel kamerada olan script. Kamera nesnesini direkt olarak rigidbody bileþeni içeren bir nesnenin child ý yaparsak bazý titreþim sorunlarý ile karþýlaþýyoruz.
    // o yüzden tüm kamera hareketlerini saðlayan cameraMovementSystem adlý scripti rigidbody componenti içeren karakterimize atýyoruz ve bu nesnenin hareketlerini
    //bu kod ile kopyalýyoruz.
    public Transform CameraPosition;
    public float damp;
    Vector3 refVelocity = Vector3.zero;
    
    void LateUpdate()
    {
        transform.position = CameraPosition.position;
        transform.rotation = CameraPosition.rotation;
    }
}
