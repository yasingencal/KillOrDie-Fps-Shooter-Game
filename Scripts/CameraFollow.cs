using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Fiziksel kamerada olan script. Kamera nesnesini direkt olarak rigidbody bile�eni i�eren bir nesnenin child � yaparsak baz� titre�im sorunlar� ile kar��la��yoruz.
    // o y�zden t�m kamera hareketlerini sa�layan cameraMovementSystem adl� scripti rigidbody componenti i�eren karakterimize at�yoruz ve bu nesnenin hareketlerini
    //bu kod ile kopyal�yoruz.
    public Transform CameraPosition;
    public float damp;
    Vector3 refVelocity = Vector3.zero;
    
    void LateUpdate()
    {
        transform.position = CameraPosition.position;
        transform.rotation = CameraPosition.rotation;
    }
}
