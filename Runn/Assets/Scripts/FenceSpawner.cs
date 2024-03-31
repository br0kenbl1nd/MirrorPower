using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceSpawner : MonoBehaviour
{
    GameManager gameManager;
    public GameObject fence;
    public float fenceSpawnTime;
    private float fenceSpawnCountDown;
    private bool canSpawnFence;
    

    // Start is called before the first frame update
    void Start()
    {        
        canSpawnFence = true;
        fenceSpawnCountDown = 0f;       
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawnFence == false)
        {
            return;
        }
        if(fenceSpawnCountDown <= 0)
        {
            Instantiate(fence, transform.position, transform.rotation);
            fenceSpawnCountDown = fenceSpawnTime;
            
        }
        fenceSpawnCountDown -= Time.deltaTime;
    }

    public void ToggleFenceSpawner()
    {
        canSpawnFence = !canSpawnFence;
    }

}
