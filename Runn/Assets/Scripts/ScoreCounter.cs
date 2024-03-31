using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [HideInInspector]
    public float scoreMultiplier;
    [HideInInspector]
    public float score;   

    public bool isClassic;
    public bool isSurvival;

    GameManager gameManager;
    public Text scoreText;
    public Text scoreMultiplierText;
    public float killBounty;

    float distanceTravelled;
    int enemiesKilled;
    int totalEnemies;
    int startLives;

    [Header("UI")]
    public Text gameOverScoreText;
    public Text gameWinScoreText;
    public GameObject gameOverUI;
    public GameObject gameWinUI;
    bool enemyKilled;

    

    private bool scoreCounton;


    // Start is called before the first frame update
    void Start()
    {
        scoreCounton = true;
        gameManager = FindObjectOfType<GameManager>();
        totalEnemies = gameManager.enemiesToDestroy;
        startLives = gameManager.playerLives;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreMultiplierCounter();
        distanceTravelled = gameManager.obstacleSpeed * Time.deltaTime;
        if(gameManager.enemiesToDestroy < totalEnemies)
        {
            enemiesKilled += totalEnemies - gameManager.enemiesToDestroy;
            enemyKilled = true;           
            totalEnemies = gameManager.enemiesToDestroy;
        }
        ScoreCount();
        scoreMultiplierText.text = "x" + scoreMultiplier.ToString("00.00");
        scoreText.text = score.ToString("0");
        if(gameOverUI.activeSelf)
        {
            scoreCounton = false;
            gameOverScoreText.text = "SCORE:" + score.ToString("0");
        }
        if(gameWinUI.activeSelf)
        {
            scoreCounton = false;
            gameWinScoreText.text = "SCORE" + score.ToString("0");
        }
        if(isClassic == true)
        {
            if(score > MainMenu.classicHighScore)
            {
                MainMenu.classicHighScore = (int)score;
            }
        }
        if(isSurvival == true)
        {
            if(score > MainMenu.survivalHighScore)
            {
                MainMenu.survivalHighScore = (int)score;
            }
        }
    }

    void ScoreMultiplierCounter()
    {
        if (scoreMultiplier <= 20)
        {
            scoreMultiplier += 0.25f * Time.deltaTime;
        }
        if(startLives > gameManager.playerLives)
        {
            ScoreMultiplierReset();
            startLives = gameManager.playerLives;
        }
    }

    public void ScoreMultiplierReset()
    {
        scoreMultiplier = 0f;
    }

    void ScoreCount()
    {
        if (scoreCounton == false)
        {
            return;
        }
        score += distanceTravelled * scoreMultiplier;
        if(enemyKilled == true)
        {
            
            score += killBounty;            
            enemyKilled = false;
        }
    }

}
