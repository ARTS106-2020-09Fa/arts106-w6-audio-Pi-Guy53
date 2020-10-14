using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnginSound : MonoBehaviour
{
    public AudioSource AudioS;
    public UnityEngine.AI.NavMeshAgent agent;
    public float multi = 0.25f;

    void Update()
    {
        AudioS.pitch = Mathf.Lerp(AudioS.pitch, .25f + agent.velocity.magnitude * multi, Time.deltaTime * 3f);
    }
}
