using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunBullet : MonoBehaviour
{
    Transform mermiHedef;
    public float mermiCikisHizi;

    public GameObject mermiIzi;
    AudioSource audioSource;
    public AudioClip[] bulletDamage;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        mermiHedef = GameObject.Find("MermiHedef").GetComponent<Transform>(); 
        
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        Vector2 yon = (mermiHedef.position - transform.position).normalized;
        rb.AddForce(yon * mermiCikisHizi, ForceMode2D.Impulse);
        Destroy(this.gameObject, 2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int i = Random.Range(0, bulletDamage.Length);
        audioSource.PlayOneShot(bulletDamage[i], 1f);
        GameObject a = Instantiate(mermiIzi, transform.position,Quaternion.identity);
        Destroy(a, 1.5f);

        if(collision.gameObject.GetComponent<EnemyHealth>() != null)
        {
            collision.gameObject.GetComponent<EnemyHealth>().health -= 0.02f;
        }
        
    }
}
