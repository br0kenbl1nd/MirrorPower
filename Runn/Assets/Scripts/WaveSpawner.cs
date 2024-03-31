using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    [Header("Difficulty")]
    public int obstacleNumber;
    public int obstacleSpeed;

    [Header("obstacle attributes")]
    public GameObject shortObstacle;
    public GameObject tallObstacle;
    public float waveNumber;
    public int waveUpgradeLevel;
    public float speedUpgradeValue;
    public bool canSpawnWave;

    [Header("time")]
    public float spawnInterval;
    public float spawnCountDown; 
    
    [Header("offset vectors")]
    public Vector3 position1Offset;
    public Vector3 position2Offset;
    public Vector3 position3Offset;
    public Vector3 tallposition1Offset;
    public Vector3 tallposition2Offset;
    public Vector3 tallposition3Offset;

    GameManager gameManager;


    void Start()
    {
        waveNumber = 1;
        spawnCountDown = 0f;
        waveUpgradeLevel = 0;
        gameManager = GameManager.instance;
        canSpawnWave = true;
    }

    void Update()
    {
        if(canSpawnWave == false)
        {
            return;
        }
        if(spawnCountDown <= 0f)
        {
            SpawnWave();
            spawnCountDown = spawnInterval;
            waveNumber++;
        }
        spawnCountDown -= Time.deltaTime;
    }

    void SpawnWave()
    {
        
        if (waveNumber == 1)
        {
            SpawnType1Obstacle();
        }

        if(waveNumber % 10 == 2)
        {
            SpawnType6Obstacle();
            UpgradeWave();
            
        }       

        if(waveNumber % 10 == 3)
        {
            SpawnType6Obstacle();        

        }

        if(waveNumber % 10 == 4)
        {
            SpawnType4Obstacle();
            UpgradeWave();
        }

        if(waveNumber % 10 == 5)
        {
            SpawnType6Obstacle();
        }

        if(waveNumber % 10 == 6)
        {
            SpawnType2Obstacle();
            UpgradeWave();
        }

        if(waveNumber % 10 == 7)
        {
            SpawnType6Obstacle();
        }

        if(waveNumber % 10 == 8)
        {
            SpawnType5Obstacle();
            UpgradeWave();
        }

        if(waveNumber % 10 == 9)
        {
            SpawnType6Obstacle();
        }

        if(waveNumber % 10 == 0)
        {
            int randomNumber = Random.Range(0, 2);
            if(randomNumber == 0)
            {
                SpawnType1Obstacle();
            }
            if(randomNumber == 1)
            {
                SpawnType3Obstacle();
            }
            UpgradeWave();
        }
    }

    void SpawnObstacle(GameObject obstacle, Vector3 offset)
    {
        Instantiate(obstacle, transform.position + offset, transform.rotation);
    }

    void SpawnType1Obstacle()
    {
        int randomNumber = Random.Range(0, 3);
        if(randomNumber == 0)
        {
            SpawnObstacle(tallObstacle, tallposition1Offset);
        }
        if(randomNumber == 1)
        {
            SpawnObstacle(tallObstacle, tallposition2Offset);
        }
        if(randomNumber == 2)
        {
            SpawnObstacle(tallObstacle, tallposition3Offset);
        }
    }

    void SpawnType2Obstacle()
    {
        float randomNumber = Random.Range(1f, 300f);
        
        if (randomNumber >= 0 && randomNumber <= 100)
        {
            SpawnObstacle(tallObstacle, tallposition1Offset);
            randomNumber = (int)Random.Range(0, 2);           
            if (randomNumber == 0)
            {
                SpawnObstacle(tallObstacle, tallposition2Offset);
            }
            else
            {
                SpawnObstacle(tallObstacle, tallposition3Offset);
            }
        }
        if (randomNumber > 100 && randomNumber <= 200)
        {
            SpawnObstacle(tallObstacle, tallposition2Offset);
            randomNumber = (int)Random.Range(0, 2);           
            if (randomNumber == 0)
            {
                SpawnObstacle(tallObstacle, tallposition1Offset);
            }
            else
            {
                SpawnObstacle(tallObstacle, tallposition3Offset);
            }
        }
        if (randomNumber > 200 && randomNumber <= 300)
        {
            SpawnObstacle(tallObstacle, tallposition3Offset);
            randomNumber = (int)Random.Range(0, 2);           
            if (randomNumber == 0)
            {
                SpawnObstacle(tallObstacle, tallposition1Offset);
            }
            else
            {
                SpawnObstacle(tallObstacle, tallposition2Offset);
            }
        }
    }

    void SpawnType3Obstacle()
    {
        SpawnObstacle(shortObstacle, position1Offset);
        SpawnObstacle(shortObstacle, position2Offset);
        SpawnObstacle(shortObstacle, position3Offset);
    }

    void SpawnType4Obstacle()
    {
        int randomNumber = (int)Random.Range(0, 3);

        if(randomNumber == 0)
        {
            SpawnObstacle(tallObstacle, tallposition1Offset);
            SpawnObstacle(shortObstacle, position2Offset);
            SpawnObstacle(shortObstacle, position3Offset);
        }

        if (randomNumber == 1)
        {
            SpawnObstacle(tallObstacle, tallposition2Offset);
            SpawnObstacle(shortObstacle, position1Offset);
            SpawnObstacle(shortObstacle, position3Offset);
        }

        if(randomNumber == 2)
        {
            SpawnObstacle(tallObstacle, tallposition3Offset);
            SpawnObstacle(shortObstacle, position1Offset);
            SpawnObstacle(shortObstacle, position2Offset);
        }
    }

    void SpawnType5Obstacle()
    {
        int randomNumber = (int)Random.Range(0, 3);

        if (randomNumber == 0)
        {
            SpawnObstacle(shortObstacle, position1Offset);
            SpawnObstacle(tallObstacle, tallposition2Offset);
            SpawnObstacle(tallObstacle, tallposition3Offset);
        }

        if (randomNumber == 1)
        {
            SpawnObstacle(shortObstacle, position2Offset);
            SpawnObstacle(tallObstacle, tallposition1Offset);
            SpawnObstacle(tallObstacle, tallposition3Offset);
        }

        if (randomNumber == 2)
        {
            SpawnObstacle(shortObstacle, position3Offset);
            SpawnObstacle(tallObstacle, tallposition1Offset);
            SpawnObstacle(tallObstacle, tallposition2Offset);
        }
    }

    void SpawnType6Obstacle()
    {
        int spawnedTall = 0;       
        for(int i = 0; i < 2; i++)
        {
            if (i == 0)
            {
                int randomNumber = (int)Random.Range(0, 3);
                if (randomNumber == 1)
                {
                    SpawnObstacle(shortObstacle, position1Offset);
                }
                if(randomNumber == 2)
                {
                    SpawnObstacle(tallObstacle, tallposition1Offset);
                    spawnedTall += 1;
                }
            }
            if(i == 1)
            {
                int randomNumber = (int)Random.Range(0, 3);
                if (randomNumber == 1)
                {
                    SpawnObstacle(shortObstacle, position2Offset);
                }
                if (randomNumber == 2)
                {
                    SpawnObstacle(tallObstacle, tallposition2Offset);
                    spawnedTall += 1;
                }
            }
            if(i == 2)
            {
                int randomNumber = (int)Random.Range(0, 3);
                if (randomNumber == 1)
                {
                    SpawnObstacle(shortObstacle, position3Offset);
                }
                if (randomNumber == 2 && spawnedTall < 2)
                {
                    SpawnObstacle(tallObstacle, tallposition3Offset);                    
                }
            }
        }
    }

    void UpgradeWave()
    {
        waveUpgradeLevel += 1;
        if (waveUpgradeLevel <= obstacleSpeed)
        {
            gameManager.speedUpgrade = gameManager.speedUpgrade + (speedUpgradeValue / 5);           
        } 
        
        if (waveUpgradeLevel <= obstacleNumber)
        {         
            spawnInterval = spawnInterval - (spawnInterval / 10);
        }           
    }

    public void ToggleSpawnWave()
    {
        canSpawnWave = !canSpawnWave;
    }
}
