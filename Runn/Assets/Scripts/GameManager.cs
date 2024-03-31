using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    PlayerMovement p;

    [Header("Do not change")]
    public float speedUpgrade;
    public float playerSpawnCountdown;
    public bool isPlayerDead;

    [Header("Game Attrbutes")]
    public GameObject player;
    public Vector3 offset;
    public int playerLives;
    public int enemiesToDestroy;    
      

    public static GameManager instance;

    //for score displaying purpose
    [Header("Score displaying purpose")]
    public float obstacleSpeed;

    [Header("UI")]
    public GameObject gameOverUI;
    public GameObject ganeWinUI;
    public Text enemyLivesText;
    public Text spawnPlayerCountdown;    
    public Image life1Image;
    public Image life2Image;
    public Image life3Image;
    

    void Start()
    {       
        instance = this;
        SpawnPlayer(); 
    }

    void Update()
    {
        if (enemyLivesText != null)
        {
            enemyLivesText.text = "enemy lives:" + enemiesToDestroy.ToString();
        }
        if(playerSpawnCountdown <= 3f)
        {
            spawnPlayerCountdown.text = playerSpawnCountdown.ToString("0");
            playerSpawnCountdown -= Time.deltaTime;
            
            if (playerSpawnCountdown <= 0)
            {
                spawnPlayerCountdown.text = "";
                playerSpawnCountdown = 10f;
            }

        }
    }

    public void SpawnPlayer()
    {
        GameObject pl = (GameObject)Instantiate(player, transform.position + offset, transform.rotation);
        isPlayerDead = false;
        p = pl.GetComponent<PlayerMovement>();
    }

    public void SpawnPlayerCountdown()
    {
        playerSpawnCountdown = 3f;
        
    }

    public void DestroyEnemy()
    {       
        enemiesToDestroy -= 1;
        if(enemiesToDestroy <= 0)
        {
            GameWon();
        }
    }

    public void DamagePlayer(GameObject player)
    {
        if(isPlayerDead == true)
        {
            return;
        }
        //freeze wavespawner and destroy the obstacls
        ToggleSpawners();

        //Destroy obstacle
        DestroyObstacles();

        //Freeze objects in environment
        FreezeObjectsInEnvironment();
        
        //reduce player lives
        playerLives -= 1;
        SpawnPlayerCountdown();
        if (playerLives <= 0)
        {
            Invoke("GameOver", 2f);
        }
        else
        {            
            Invoke("SpawnPlayer", 3f);
            if(p != null)
            {
                p.canMove = false;
            }
            Invoke("Continue", 4f);
        }

        //Update player lives UI
        UpdatePlayerLivesUI();
        
        isPlayerDead = true;
    }

    void DestroyObstacles()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }
    }

    void FreezeObjectsInEnvironment()
    {
        GameObject[] environments = GameObject.FindGameObjectsWithTag("Environment");
        foreach (GameObject environment in environments)
        {
            ObstacleMovement ob = environment.GetComponent<ObstacleMovement>();
            ob.Freeze();
        }
    }

    public void ToggleSpawners()
    {
        WaveSpawner waveSpawner = FindObjectOfType<WaveSpawner>();
        if (waveSpawner != null)
        {
            waveSpawner.ToggleSpawnWave();
        }
        GameObject[] fenceSpawners = GameObject.FindGameObjectsWithTag("EnvironmentSpawner");
        foreach (GameObject fenceSpawner in fenceSpawners)
        {
            FenceSpawner f = fenceSpawner.GetComponent<FenceSpawner>();
            f.ToggleFenceSpawner();
        }
    }

    void Continue()
    {
        ToggleSpawners();                  
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Environment");
        foreach (GameObject obstacle in obstacles)
        {                   
            ObstacleMovement ob = obstacle.GetComponent<ObstacleMovement>();
            ob.UnFreeze();
        }
        p.canMove = true;
    }

    void GameOver()
    {              
        gameOverUI.SetActive(true);
    }

    void GameWon()
    {
        ganeWinUI.SetActive(true);
    }

    void UpdatePlayerLivesUI()
    {
        if (playerLives == 2)
        {
            life1Image.enabled = false;
        }
        if (playerLives == 1)
        {
            life2Image.enabled = false;
        }
        if (playerLives == 0)
        {
            life3Image.enabled = false;
        }
    }

}
