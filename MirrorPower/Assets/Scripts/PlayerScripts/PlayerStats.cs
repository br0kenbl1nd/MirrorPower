using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private GameObject player;

    public string PlayerTag = "Player";

    [SerializeField]
    private int startLives;

    private int lives;

    private void Awake()
    {
        lives = startLives;

        player = GameObject.FindGameObjectWithTag(PlayerTag);
    } //awake

    private void Update()
    {
        
    }

} //class
