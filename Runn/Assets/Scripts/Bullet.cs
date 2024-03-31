using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public float time;
    public float speed;
    float distance;
    GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        time += Time.deltaTime;
        if(time >= 2f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {       
        if(collisionInfo.collider.tag == "Enemy")
        {
            Enemy e = collisionInfo.gameObject.GetComponent<Enemy>();
            e.GetHit();
            Destroy(gameObject);
        }        
    }
}
