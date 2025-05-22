using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public GameObject bulletPrefab;

    public float damage;
    public float bulletForce = 20f;

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle - 180, Vector3.forward);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
	{
	    GameObject bullet = Instantiate(bulletPrefab, gameObject.transform.position, gameObject.transform.rotation);
	    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
	    rb.AddForce(gameObject.transform.right * bulletForce * -1, ForceMode2D.Impulse);

	    Bullet bulletScript = bullet.GetComponent<Bullet>(); 
	    bulletScript.damage = damage;
	}
    

}
