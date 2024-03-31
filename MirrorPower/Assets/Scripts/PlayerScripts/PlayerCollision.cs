using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private string ObstacleTag = "Obstacle";

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(ObstacleTag))
        {
            Debug.Log("We have been hit");
            Destroy(gameObject);
        }
    }

} //class
