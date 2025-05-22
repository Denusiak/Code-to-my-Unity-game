using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGun : MonoBehaviour
{
    public float lifeTime = 0.2f;  // час існування
    public float damage;

    private GameObject player;

    private void Start()
    {
        Destroy(gameObject, lifeTime);

        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {

            other.GetComponent<Character>().TakeDamage(damage);  // Ворог отримує урон
            Destroy(gameObject);  
        }
    }
}
