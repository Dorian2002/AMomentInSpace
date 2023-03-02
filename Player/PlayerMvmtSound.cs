using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerMvmtSound : MonoBehaviour
{
    [SerializeField] AudioClip[] walkAudioClips;
    [SerializeField] AudioClip[] runAudioClips;
    [SerializeField] AudioClip[] jumpAudioClips;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !audioSource.isPlaying)
        {
            AudioClip clip = GetRandomJumpClip();
            audioSource.PlayOneShot(clip);
        }
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Q))
        {
            if (!audioSource.isPlaying && Input.GetKey(KeyCode.LeftShift))
            {
                AudioClip clip = GetRandomRunClip();
                audioSource.PlayOneShot(clip);
            }
            else if (!audioSource.isPlaying)
            {
                AudioClip clip = GetRandomWalkClip();
                audioSource.PlayOneShot(clip);
            }
        }
    }

    private AudioClip GetRandomWalkClip()
    {
        int index = UnityEngine.Random.Range(0, walkAudioClips.Length - 1);
        return walkAudioClips[index];
    }
    private AudioClip GetRandomRunClip()
    {
        int index = UnityEngine.Random.Range(0, runAudioClips.Length - 1);
        return runAudioClips[index];
    }
    private AudioClip GetRandomJumpClip()
    {
        int index = UnityEngine.Random.Range(0, walkAudioClips.Length - 1);
        return walkAudioClips[index];
    }
}
