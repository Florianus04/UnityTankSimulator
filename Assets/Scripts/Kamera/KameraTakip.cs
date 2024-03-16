using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    public Transform target; // Takip edilecek karakterin Transform bileþeni
    public float smoothSpeed = 5f; // Kamera takip hýzý

    private void LateUpdate()
    {
        if (target != null)
        {
            // Hedef pozisyonunu karakterin pozisyonuna yaklaþtýrýn ve yumuþakça takip edin
            Vector3 desiredPosition = target.position;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
        }
        SetTransformZ(-10f);
    }
    void SetTransformZ(float z)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, z);
    }
}
