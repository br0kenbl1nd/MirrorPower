using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerJump : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float maxHeight;

    private bool onGround = true;

    public string groundTag = "Ground";

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    } //awake

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log(jumpForce);
            rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
        }


    } //fixed update


} //class
