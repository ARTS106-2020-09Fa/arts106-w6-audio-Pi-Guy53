using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public AudioClip deathSound;
    public AudioSource audioS;

    private void OnCollisionEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        Destroy(gameObject);
    }

}