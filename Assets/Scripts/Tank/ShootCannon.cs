using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCannon : MonoBehaviour
{
    AudioSource audioSource;
    Animator anim;

    public AudioClip cannon, machineGun;

    public Transform topNamlu, tufekNamlu;
    public GameObject top, mermi;
    public GameObject bulletSmoke, cannonSmoke, bulletLight;

    float timer = 5;

    public GameObject Camera;
    KameraAnims cam;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        cam = Camera.GetComponent<KameraAnims>();
    }

    void Update()
    {
        Shoot();
    }
    void Shoot()
    {
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Cannon();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            StartCoroutine(MachineGun());
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            StopAllCoroutines();
            bulletLight.SetActive(false);
        }
    }
    void Cannon()
    {
        if (timer > 5f)
        {
            timer = 0;
            audioSource.PlayOneShot(cannon, 1f);
            anim.SetTrigger("Shoot");
            cam.Shake(0.5f, 1f);

            Pooling.SpawnObject(top, topNamlu.position);
            GameObject smoke = Instantiate(cannonSmoke, topNamlu.position,Quaternion.identity);
            Destroy(smoke, 2f);
        }        
    }
    IEnumerator MachineGun()
    {
        while (true)
        {           
            yield return new WaitForSeconds(0.08f);
            audioSource.PlayOneShot(machineGun, 0.4f);
            bulletLight.SetActive(true);
            cam.Shake(0.2f, 0.1f);
            Pooling.SpawnObject(mermi, tufekNamlu.position);
            GameObject smoke = Instantiate(bulletSmoke, tufekNamlu.position, Quaternion.identity);
            Destroy(smoke, 2f);
            yield return new WaitForSeconds(0.01f);
            bulletLight.SetActive(false);
        }
    }
}
