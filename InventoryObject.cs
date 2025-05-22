using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

public class InventoryObject : MonoBehaviour, IPointerClickHandler
{
	private InventoryManager inventoryManager;

	public string name;
	public string type;
	public int count;
	public TextMeshProUGUI countText;

	//=======
	public bool isActiveWeapon;

    private void Start()
    {
    	inventoryManager = FindObjectOfType<InventoryManager>();
    }

    private void Update()
    {
    	if (type == "weapon" || type == "handgun")
    	{
    		countText.text = "";
    		return;
    	}
    	
    	if (count > 1)
    	{
    		countText.text = "x" + count;
    	}
    	else if (count <= 1)
    	{
    		countText.text = "";
    	}
    	
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        inventoryManager.SelectWeapon(gameObject);
        Debug.Log(gameObject.name);
    }

}
