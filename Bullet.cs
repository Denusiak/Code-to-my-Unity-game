using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
	
	private void Start()
    {
    	Destroy(gameObject, 30f);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
    	if (other.CompareTag("Player"))
	    {
	        return;
	    }

    	if (other.CompareTag("Enemy"))
	    {
	        other.gameObject.GetComponent<Character>().TakeDamage(damage);
	        
	    }

	    Destroy(gameObject);
    }


    
}
