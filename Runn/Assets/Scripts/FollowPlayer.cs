using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;
    private Transform playerPosition;
    public Vector3 positionOffset;

    // Update is called once per frame
    void Update()
    {

        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        else
        {
            UpdatePlayerPosition();
            transform.position = playerPosition.position + positionOffset;
        }
    }

    void UpdatePlayerPosition()
    {
        playerPosition = player.transform;
    }
}
