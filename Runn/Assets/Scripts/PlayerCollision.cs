using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{   
    GameManager gameManager;

    public GameObject playerDeathEffect;

    void Start()
    {       
        gameManager = FindObjectOfType<GameManager>();       
    }

    void Update()
    {
        if(transform.position.x >= 18f || transform.position.x <= -18f)
        {
            Destroy(gameObject);
            gameManager.DamagePlayer(gameObject);
            Instantiate(playerDeathEffect, transform.position, transform.rotation);
        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Obstacle")
        {
            Destroy(gameObject);           
            gameManager.DamagePlayer(gameObject);
            Instantiate(playerDeathEffect, transform.position, transform.rotation);
        }
        if(collisionInfo.collider.tag == "Earth")
        {            
            Destroy(gameObject);                     
            gameManager.DamagePlayer(gameObject);
            Instantiate(playerDeathEffect, transform.position, transform.rotation);
        }

    }
}
