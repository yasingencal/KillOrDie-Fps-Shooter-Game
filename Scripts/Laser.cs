using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    //Baþlangýç ve bitiþ noktasý sürekli güncellenen lazer eklenti scripti
    private LineRenderer lineRenderer;
    public Transform bulletExit;
    public float lazerUzunlugu = 100f;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        
        Vector3 startPoint = bulletExit.position;
        Vector3 endPoint = bulletExit.position + bulletExit.forward * lazerUzunlugu;

        
        UpdateLineRenderer(startPoint, endPoint);
    }

    void UpdateLineRenderer(Vector3 startPoint, Vector3 endPoint)
    {
        
        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.SetPosition(1, endPoint);
    }
    private void Update()
    {
        Vector3 startPoint = bulletExit.position;
        Vector3 endPoint = bulletExit.position + bulletExit.forward * lazerUzunlugu;

        UpdateLineRenderer(startPoint, endPoint);

    }
}
