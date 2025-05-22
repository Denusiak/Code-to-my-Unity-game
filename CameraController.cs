using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
    	player = GameObject.FindWithTag("Player");
    }

	private void Update()
    {
    	Vector3 newPosition = player.transform.position;
        newPosition.z = -10f;  
        transform.position = newPosition;
    }
}
