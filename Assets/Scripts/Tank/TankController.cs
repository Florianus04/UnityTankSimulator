using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public Transform hedef;

    AudioSource audioSource;
    Animator anim;

    public float donusHizi = 50f;
    public float ileriHareketHizi = 2f;
    public float geriHareketHizi = 0.5f;

    float yatay, dikey, speed;

    public GameObject Camera;
    KameraAnims cam;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        cam = Camera.GetComponent<KameraAnims>();
    }
    void Update()
    {
        Donus();
        Gaz();
        Anim();
        Zoom();
    }
    void Zoom()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Vector3 zoomTarget = hedef.position;
            cam.Move(zoomTarget, 1f);
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            Vector3 zoomTarget = transform.position;
            cam.Move(zoomTarget, 1f);
        }
    }
    void Anim()
    {
        
        if(yatay<0)
        {
            yatay *= -1;          
        }
        if(dikey < 0)
        {
            dikey *= -1;
        }
        speed = yatay + dikey;
        anim.SetFloat("Speed", speed);
    }
    void Donus()
    {
        float yatayHareket = Input.GetAxis("Horizontal");
        yatay = yatayHareket;
        transform.Rotate(Vector3.forward * -yatayHareket * donusHizi * Time.deltaTime);
    }

    void Gaz()
    {
        float ileriGeriHareket = Input.GetAxis("Vertical");
        dikey = ileriGeriHareket;
        if (ileriGeriHareket > 0)
        {
            // ileri gitme
            Vector3 hedefYon = hedef.position - transform.position;
            float hedefAcisi = Mathf.Atan2(hedefYon.y, hedefYon.x) * Mathf.Rad2Deg - 90f;
            Quaternion hedefRotasyon = Quaternion.Euler(new Vector3(0, 0, hedefAcisi));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, hedefRotasyon, donusHizi * Time.deltaTime);

            transform.Translate(Vector3.up * ileriHareketHizi * Time.deltaTime);
            audioSource.pitch = 1.3f;

            cam.Size(6, 1f);
        }
        else if (ileriGeriHareket < 0)
        {
            // geri gitme
            Vector3 hedefYon = transform.position - hedef.position;
            float hedefAcisi = Mathf.Atan2(hedefYon.y, hedefYon.x) * Mathf.Rad2Deg - 90f;
            Quaternion hedefRotasyon = Quaternion.Euler(new Vector3(0, 0, hedefAcisi));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, hedefRotasyon, donusHizi * Time.deltaTime);

            transform.Translate(Vector3.down * geriHareketHizi * Time.deltaTime);
            audioSource.pitch = 1.2f;

            cam.Size(5.5f, 1f);
        }
        else if (yatay != 0)
        {
            audioSource.pitch = 1.15f;
        }
        else
        {
            audioSource.pitch = 1;
            cam.Size(5, 0.5f);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        cam.Shake(0.05f, 0.05f);
    }
}