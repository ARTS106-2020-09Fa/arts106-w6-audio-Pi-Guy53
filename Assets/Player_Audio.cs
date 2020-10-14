using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Player_Audio : MonoBehaviour
{
    public AudioClip splashSound;

    public AudioSource audioS;

    public AudioMixerSnapshot IdleSnapshot;
    public AudioMixerSnapshot AuxInSnapshot;
    public AudioMixerSnapshot ambIdleSnapshot;
    public AudioMixerSnapshot ambInShapshot;

    public LayerMask enemyMask;

    bool enemyNear;

    public AudioClip[] grassSteps;
    public AudioClip[] woodSteps;
    public AudioClip[] hardSteps;

    private void Update()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, 5f, transform.forward, 0f, enemyMask);
        if (hits.Length > 0)
        {
            enemyNear = true;
        }
        else
        {
            enemyNear = false;
        }

        if (!AudioManager.manager.eventRunning)
        {
            if (enemyNear)
            {
                if (!AudioManager.manager.auxIn)
                {
                    AuxInSnapshot.TransitionTo(0.5f);
                    AudioManager.manager.currantAudioMixerSnapshot = AuxInSnapshot;
                    AudioManager.manager.auxIn = true;
                }
                else
                {
                    if(AudioManager.manager.currantAudioMixerSnapshot == AudioManager.manager.eventSnap)
                    {
                        AuxInSnapshot.TransitionTo(0.5f);
                        AudioManager.manager.currantAudioMixerSnapshot = AuxInSnapshot;
                        AudioManager.manager.auxIn = true;
                    }
                }
            }

            else
            {
                if (AudioManager.manager.auxIn)
                {
                    IdleSnapshot.TransitionTo(0.5f);
                    AudioManager.manager.currantAudioMixerSnapshot = IdleSnapshot;
                    AudioManager.manager.auxIn = false;
                }

                else
                {
                    if (AudioManager.manager.currantAudioMixerSnapshot == AudioManager.manager.eventSnap)
                    {
                        IdleSnapshot.TransitionTo(0.5f);
                        AudioManager.manager.currantAudioMixerSnapshot = IdleSnapshot;
                        AudioManager.manager.auxIn = false;
                    }
                }
            }
        }
    }
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Water"))
            {
                audioS.PlayOneShot(splashSound);
            }
            if (other.CompareTag("EnemyZone"))
            {
                AuxInSnapshot.TransitionTo(0.5f);
            }
            if (other.CompareTag("Bird"))
            {
                ambInShapshot.TransitionTo(0.5f);
            }

        }

        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Water"))
            {
                audioS.PlayOneShot(splashSound);
            }
            if (other.CompareTag("EnemyZone"))
            {
                IdleSnapshot.TransitionTo(0.5f);
            }
            if (other.CompareTag("Bird"))
            {
                ambIdleSnapshot.TransitionTo(0.5f);
            }
        }

    public void Footsteps()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, -transform.up);
        int r = Random.Range(0, 3);
        if(Physics.Raycast(ray, out hit, 1f))
        {
            switch(hit.transform.tag)
            {
                case"WoodFloor":
                    audioS.PlayOneShot(woodSteps[r]);
                    break;

                case "HardFloor":
                    audioS.PlayOneShot(hardSteps[r]);
                    break;

                case "GrassFloor":
                    audioS.PlayOneShot(grassSteps[r]);
                    break;

                default:
                    audioS.PlayOneShot(grassSteps[r]);
                    break;
            }
        }
    }

}