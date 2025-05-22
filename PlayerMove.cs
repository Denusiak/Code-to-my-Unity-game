using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	private Character playerCharacter;

    private float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
    	playerCharacter = GetComponent<Character>();

    	rb = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>(); 

    	moveSpeed = playerCharacter.speed;
    }

    void Update()
    {
        // Зчитування клавіш
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Відзеркалення спрайту
        if (movement.x > 0)
            spriteRenderer.flipX = false;  
        else if (movement.x < 0)
            spriteRenderer.flipX = true;   
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
