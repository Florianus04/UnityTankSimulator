using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBullet : MonoBehaviour
{
    Transform topHedef;
    public float topCikisHizi;

    public GameObject patlama;
    AudioSource audioSource;
    public AudioClip bomm;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        topHedef = GameObject.Find("TopHedef").GetComponent<Transform>();

        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        Vector2 yon = (topHedef.position - transform.position).normalized;
        rb.AddForce(yon * topCikisHizi, ForceMode2D.Impulse);

        Destroy(this.gameObject, 4f);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {       
        audioSource.PlayOneShot(bomm, 1f);
        GameObject a = Instantiate(patlama, transform.position,Quaternion.identity);
        Destroy(a, 5f);
        
        collision.gameObject.GetComponent<EnemyHealth>().health -= 0.5f;
    }
}
