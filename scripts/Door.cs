using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;
    private LightEvent Light;
    [SerializeField] private PassSystem pass;

    private void Awake()
    {
        Light = GameObject.Find("LightEvent").GetComponent<LightEvent>();
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player" || other.tag == "Alien") && Light.GetAreLightsUp())
        {
            if (tag == "Untagged")
            {
                OpenDoor(true);
                audioSource.PlayOneShot(audioSource.clip);
            }
            else
            {
                if (!pass.CanInteract)
                {
                    OpenDoor(true);
                    audioSource.PlayOneShot(audioSource.clip);
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if ((other.tag == "Player" || other.tag == "Alien") && Light.GetAreLightsUp())
        {
            if (tag == "Untagged")
            {
                OpenDoor(false);
                audioSource.PlayOneShot(audioSource.clip);
            }
            else
            {
                if (!pass.CanInteract)
                {
                    OpenDoor(false);
                    audioSource.PlayOneShot(audioSource.clip);
                }
            }
        }
    }

    public void OpenDoor(bool value)
    {
        animator.SetBool("opening", value);
    }
}
