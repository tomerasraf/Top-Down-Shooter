using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float dealyDestroy;
    
    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.CompareTag("Enemy")){
            Destroy(gameObject);
            Spawner.enemyCounter--;
        }
    }
    void Update()
    {
        Destroy(gameObject, dealyDestroy);
    }
}
