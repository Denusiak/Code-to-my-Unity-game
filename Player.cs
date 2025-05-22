using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private Player playerScript;
	private Character playerCharacter;

    public GameObject[] handGunPrefabs;
    public float fistDistance = 1.0f;

    private float lastAttackTime;
    private bool isAtac = false;

    private GameObject activeGun;
    private GameObject newGun;
    private bool isHandGunActive = true;


    private void Start()
    {
    	playerScript = GetComponent<Player>();
    	playerCharacter = GetComponent<Character>();

        activeGun = handGunPrefabs[0];
    }

    void Update()
    {

    	if (Time.time >= lastAttackTime + playerCharacter.attackCooldown)
        {
            isAtac = true;
        }
        else
        {
        	isAtac = false;
        }
        
        if (Input.GetMouseButtonDown(0) && isAtac && isHandGunActive)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = (mousePos - transform.position).normalized;

            Vector3 spawnPosition = transform.position + direction * fistDistance;
            spawnPosition.z = 0;  

            GameObject handGun = Instantiate(activeGun, spawnPosition, Quaternion.identity);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            handGun.transform.rotation = Quaternion.Euler(0, 0, angle);

            lastAttackTime = Time.time;
            isAtac = false;
        }
    }

    public void TakeGun(GameObject gun)
    {
        if (gun == null)
        {
            activeGun = handGunPrefabs[0];
            isHandGunActive = true;

            Destroy(newGun);
            return;
        }

        InventoryObject io = gun.GetComponent<InventoryObject>();

        if (io.type == "handgun")
        {
            switch (io.name)
            {
                case "katana":
                    activeGun = handGunPrefabs[1];
                    isHandGunActive = true;
                    return;
            } 
        }

        isHandGunActive = false;

        switch (io.name)
        {
            case "pistol":
                activeGun = handGunPrefabs[2];
                break;
            case "m4":
                activeGun = handGunPrefabs[3];
                break;
            case "shotgun":
                activeGun = handGunPrefabs[4];
                break;
        }

        newGun = Instantiate(activeGun, gameObject.transform);
    }



}
