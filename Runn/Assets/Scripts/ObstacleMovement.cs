using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float startSpeed;
    public float speed;
    GameManager gameManager;

    void Start()
    {
        speed = startSpeed;
        gameManager = GameManager.instance;
        speed += gameManager.speedUpgrade;       
    }

    void Update()
    {
        transform.Translate(Vector3.forward * -speed * Time.deltaTime, Space.World);
        if(transform.position.z <= -9)
        {
            Destroy(gameObject);
        }
        //for displaying score purpose
        gameManager.obstacleSpeed = speed;
    }

    public void Freeze()
    {
        speed = 0f;
    }

    public void UnFreeze()
    {
        speed = startSpeed + gameManager.speedUpgrade;
    }
}
