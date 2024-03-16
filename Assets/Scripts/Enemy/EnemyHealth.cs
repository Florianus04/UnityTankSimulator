using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 10f, maxHealth;

    public GameObject healthBar;
    void Start()
    {
        health = maxHealth;
    }
    void Update()
    {
        Bar();
    }
    void Bar()
    {
        healthBar.transform.localScale = new Vector3(health, transform.localScale.y, transform.localScale.z);
    }
}
