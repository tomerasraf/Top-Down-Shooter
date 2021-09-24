using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform Player;
    public Rigidbody2D playerRb;
    public Rigidbody2D EnemyRb;
    public float moveSpeed = 5f;
    private Vector2 movment;
    private float angle;


    // Update is called once per frame

    void Update()
    {
        Player = GameObject.FindWithTag("Player").transform;
        RotatePlayer();
        
    }
    void FixedUpdate()
    {
        moveEnemy();
    }

    void RotatePlayer()
    {
        Vector2 diraction = (Vector2)Player.position - EnemyRb.position;
        angle = Mathf.Atan2(diraction.y, diraction.x) * Mathf.Rad2Deg;
    }

    void moveEnemy()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.position, moveSpeed * Time.deltaTime);
        EnemyRb.rotation = angle;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet")){
            Destroy(gameObject);
        }
    }
}
