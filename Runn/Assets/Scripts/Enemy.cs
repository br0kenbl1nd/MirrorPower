using UnityEngine;

public class Enemy : MonoBehaviour
{
    ScoreCounter scoreCounter;
    public float lifeTime;
    private float countDown;
    GameManager gameManager;
    public GameObject deathEffect;

    void Start()
    {
        countDown = lifeTime;
        gameManager = FindObjectOfType<GameManager>();
        scoreCounter = FindObjectOfType<ScoreCounter>();
    }

    void Update()
    {
        if(countDown <= 0)
        {
            scoreCounter.ScoreMultiplierReset();
            Destroy(gameObject);
        }
        countDown -= Time.deltaTime;
    }

    public void GetHit()
    {
        gameManager.DestroyEnemy();
        Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
