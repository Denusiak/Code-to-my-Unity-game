using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Chest : MonoBehaviour
{
    private GameObject player;
    private float distance;
    private bool isPlayerNearby;
    private bool isOpen;

    public GameObject[] contents; // список речей

    public TextMeshProUGUI infoText;
    public GameObject buttonImage;



    private void Update()
    {
    	// перевіряєм чи чест відкритий
    	if (isOpen)
    	{
    		return;
    	}

        player = GameObject.FindWithTag("Player");
    	distance = Vector3.Distance(transform.position, player.transform.position);

    	// перевіряємо дистанцію до гравця
    	if(distance <= 3f)
    	{
    		isPlayerNearby = true;
            Debug.Log(555);
    	}
    	else
    	{
    		isPlayerNearby = false;
    	}

    	// відслідковуєсо натискання клавіши
    	if (Input.GetKeyDown(KeyCode.F) && isPlayerNearby)
    	{
    		isOpen = true;

    		buttonImage.SetActive(false);

    		StartCoroutine(PrintContent());

    		return;
    	}

    	ShowInfo();
    }

    // виводимо інформацію на канвас
    private void ShowInfo()
    {
    	if (!isPlayerNearby)
    	{
    		infoText.text = "";
    		buttonImage.SetActive(false);
    		return;
    	}

    	buttonImage.SetActive(true);

    	
    }

    // виводимо знайдені речі та передаєм їх в InventoryManager
    IEnumerator PrintContent()
    {
        foreach (GameObject content in contents)
        {
        	InventoryObject ioScript = content.GetComponent<InventoryObject>();
        	InventoryManager imScript = player.GetComponent<InventoryManager>();

        	infoText.text = ioScript.name + " x" + ioScript.count; 
        	imScript.AddComponent(content);

            yield return new WaitForSeconds(1f);
        }
        infoText.text = "";
    }
}
