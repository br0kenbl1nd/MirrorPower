using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemy2;

    public float spawnTime;
    private float actualSpawnTime;
    private float spawnCountDown;
    public Vector3 offset;
    float randomX;   
    float randomZ;
    float randomY;
    int randomEnemy;
    private Vector3 xadd;

    void Start()
    {
        spawnCountDown = 0f;       
    }

    void Update()
    {
        randomX = Random.Range(-5, 5);            
        randomZ = Random.Range(-2, 2);
        randomY = Random.Range(0, 2);
        randomEnemy = (int)Random.Range(0, 2);
        actualSpawnTime = Random.Range((spawnTime - 5), (spawnTime + 5));
        xadd = new Vector3(randomX, randomY, randomZ);
        if (spawnCountDown <= 0)
        {
            if (randomEnemy == 1)
            {
                Instantiate(enemy, transform.position + offset + xadd, transform.rotation);
                spawnCountDown = actualSpawnTime;
            }
            if(randomEnemy == 0)
            {
                Instantiate(enemy2, transform.position + offset + xadd, transform.rotation);
                spawnCountDown = actualSpawnTime;
            }
        }
        spawnCountDown -= Time.deltaTime;
    }

}
