using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;

    public Vector3 zOffset;

    public string PlayerTag = "Player";

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag(PlayerTag);
    } //awake

    private void LateUpdate()
    {
        transform.position = player.transform.position + zOffset;
    } //late update

} //class
