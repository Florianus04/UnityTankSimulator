using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaretController : MonoBehaviour
{
    public float donusHizi = 3f;

    private Vector3 hedefYon;

    void Update()
    {
        NamluKontrol();
    }

    void NamluKontrol()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = transform.position.z;
        Vector3 mouseWorldSpace = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        
        hedefYon = mouseWorldSpace - transform.position;

        
        float step = donusHizi * Time.deltaTime;
        Vector3 yeniYon = Vector3.RotateTowards(transform.up, hedefYon, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, yeniYon);
    }
}