using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;

    public Transform shootFrom;

    public float shootForce = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        GameObject thisBullet = Instantiate(bullet, shootFrom.transform.position, shootFrom.transform.rotation);
        thisBullet.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce, ForceMode.Impulse);
    }
}
