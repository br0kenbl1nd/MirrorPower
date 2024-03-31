using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody rb;

    public bool canMove;

    [Header("forces")]
    public float jumpForce;
    public float downForce;
    public float sideForce;

    [Header("Side movement")]
    public bool moveRight;
    public bool moveLeft;
    

    GameManager gameManager;

    private bool isPlayerOnTheGround = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
        moveRight = false;
        moveLeft = false;
        canMove = true;
    }

    void Update()
    {
        if(canMove == false)
        {
            return;
        }
        if (Input.GetKey("d"))
        {
            MoveRight();
        }
        if(Input.GetKeyUp("d"))
        {
            DontMoveRight();
        }
        if (Input.GetKey("a"))
        {
            MoveLeft();
        }
        if(Input.GetKeyUp("a"))
        {
            DontMoveLeft();
        }
        if (Input.GetKeyDown("w"))
        {
            Jump();
        }
        if (Input.GetKey("s"))
        {
            CancelJump();
        }
    }

    void FixedUpdate()
    {
        if(moveRight == true)
        {
            rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        
        if(moveLeft == true)
        {
            rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }

    public void Jump()
    {
        if (isPlayerOnTheGround == true)
        {
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            isPlayerOnTheGround = false;
        }
    }

    public void CancelJump()
    {
        rb.AddForce(0, -downForce * Time.deltaTime, 0, ForceMode.Impulse);
    }

    public void MoveRight()
    {
        moveRight = true;
    }

    public void DontMoveRight()
    {
        moveRight = false;
    }

    public void MoveLeft()
    {
        moveLeft = true;
    }

    public void DontMoveLeft()
    {
        moveLeft = false;
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Ground")
        {
            isPlayerOnTheGround = true;
        }
    }   


}
