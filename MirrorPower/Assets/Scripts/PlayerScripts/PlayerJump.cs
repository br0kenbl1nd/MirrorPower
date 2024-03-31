using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerJump : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float cancelJumpForce;

    private bool onGround = true;

    public string groundTag = "Ground";

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    } //awake

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            if(onGround == true)
            {
                rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
                onGround = false;
            }
            
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForce(0f, -cancelJumpForce, 0f, ForceMode.Impulse);
        }

    } //fixed update

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(groundTag))
        {
            onGround = true;
        }
    }

} //class
