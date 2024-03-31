using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Vector3 offset;
    public GameObject bullet;
    private bool canShoot;

    public float speed;

    void Start()
    {
        canShoot = true;
    }

    void Update()
    {
        if(canShoot == false)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject b = (GameObject)Instantiate(bullet, transform.position + offset, transform.rotation);
        Rigidbody rb = b.GetComponent<Rigidbody>();
        rb.AddForce(0, 0, speed * Time.deltaTime, ForceMode.Impulse);
    }

    public void ToggleOnShoot()
    {
        canShoot = true;
    }
    
    public void ToggleOffShoot()
    {
        canShoot = false;
    }

}
