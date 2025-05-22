using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
	private Player player;

    private List<GameObject> inventory = new List<GameObject>();      // логічний список елементів
    private List<GameObject> itemPool = new List<GameObject>();       // об'єкти з пулу

    public Transform gridParent; // контейнер елементів інвентаря
    public GameObject inventoryPanel;
    private bool isInventoryOpen;

    public Transform weaponSlot; // слот зброї
    private bool isWeaponSelected;
    private GameObject activeWeapon;

    private void Start()
    {
    	player = FindObjectOfType<Player>();
        UpdateInventory();

        player.TakeGun(null);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isInventoryOpen = !isInventoryOpen;
            inventoryPanel.SetActive(isInventoryOpen);
        }
    }

    public void SelectWeapon(GameObject element)
	{
	    InventoryObject io = element.GetComponent<InventoryObject>();

	    if (io.isActiveWeapon)
	    {
	        element.transform.SetParent(gridParent);
	        io.isActiveWeapon = false;
	        isWeaponSelected = false;
	        activeWeapon = null;

	        player.TakeGun(null);
	    }
	    else if ((io.type == "weapon" || io.type == "handgun") && !isWeaponSelected)
	    {
	        element.transform.SetParent(weaponSlot);
	        io.isActiveWeapon = true;
	        isWeaponSelected = true;
	        activeWeapon = element;

	        player.TakeGun(element);
	    }
	}

    private void UpdateInventory()
	{
	    for (int i = 0; i < inventory.Count; i++)
	    {
	        GameObject item;

	        if (i < itemPool.Count)
	        {
	            item = itemPool[i];
	            item.SetActive(true);
	        }
	        else
	        {
	            item = Instantiate(inventory[i], gridParent);
	            itemPool.Add(item);
	        }

	        item.transform.SetParent(gridParent);
	        var source = inventory[i].GetComponent<InventoryObject>();
	        var target = item.GetComponent<InventoryObject>();

	        target.name = source.name;
	        target.count = source.count;
	        target.type = source.type;

	        if (item == activeWeapon)
	        {
	            target.isActiveWeapon = true;
	        }
	        else
	        {
	            target.isActiveWeapon = false;
	        }
	    }

	    for (int i = inventory.Count; i < itemPool.Count; i++)
	    {
	        itemPool[i].SetActive(false);
	    }
	}

    public void AddComponent(GameObject content)
	{
	    InventoryObject contentScript = content.GetComponent<InventoryObject>();
	    int elementIndex = FindElement(contentScript.name);

	    if (elementIndex != -1)
	    {
	        InventoryObject existingScript = inventory[elementIndex].GetComponent<InventoryObject>();
	        existingScript.count += contentScript.count;
	    }
	    else
	    {
	        GameObject newItem = Instantiate(content);   // Створюємо копію для інвентаря.
	        inventory.Add(newItem);                      // Додаємо до списку.
	    }

	    UpdateInventory();  
	}


    private int FindElement(string elementName)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            InventoryObject ioScript = inventory[i].GetComponent<InventoryObject>();
            if (ioScript.name == elementName)
            {
                return i;
            }
        }
        return -1;
    }
}
