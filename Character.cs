using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float healPoints;
    public float damage;
    public float speed;

    public float attackCooldown;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
    	spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float value)
    {
    	healPoints -= value;

    	StartCoroutine(FlashRed());

    	if (healPoints <= 0f)
    	{
    		Destroy(gameObject);
    	}
    }


    IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;      
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;   
    }
}
