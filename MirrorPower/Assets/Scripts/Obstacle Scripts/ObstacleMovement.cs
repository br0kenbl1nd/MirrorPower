using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{

    [SerializeField]
    private float startMovementSpeed;

    [SerializeField]
    private float maxZ;

    private float movementSpeed;

    private void Awake()
    {
        movementSpeed = startMovementSpeed;
    } //awake

    private void Update()
    {

        transform.Translate(0f, 0f, -movementSpeed * Time.deltaTime, Space.World);

        if(transform.position.z <= maxZ)
        {
            Destroy(gameObject);
        }

    } //update

} //class
