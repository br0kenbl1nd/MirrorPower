using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    [Header("Player Movement")]
    [SerializeField]
    private float movementSpeed = 10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    } //awake

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");

        rb.AddForce(x * Time.deltaTime * 500f * movementSpeed, 0f, 0f);


    } //fixedupdate


} //class
