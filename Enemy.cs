using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    private Character enemyCharacterScript;
    private GameObject player;
    private Rigidbody2D rb;

    public float detectRadius = 5f;
    private float lastAttackTime = -Mathf.Infinity;
    private float moveSpeed;

    private void Start()
    {
        enemyCharacterScript = GetComponent<Character>();
        rb = GetComponent<Rigidbody2D>();

        moveSpeed = enemyCharacterScript.speed;
        player = GameObject.FindWithTag("Player");
    }

    private void FixedUpdate()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < detectRadius && distance > 0.8f)
        {
            Vector2 direction = ((Vector2)player.transform.position - rb.position).normalized;
            Vector2 newPosition = rb.position + direction * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(newPosition);
        }
        else if (distance < 0.8f && Time.time > lastAttackTime + enemyCharacterScript.attackCooldown)
        {
            Character playerCharacterScript = player.GetComponent<Character>();
            playerCharacterScript.TakeDamage(enemyCharacterScript.damage);
            lastAttackTime = Time.time;
        }
    }
}
