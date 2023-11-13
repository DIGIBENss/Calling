using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] audioClips;
    [SerializeField] private AudioSource audioSource;
    public bool IsNotBell;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(int soundIndex)
    {
        if (soundIndex >= 0 && soundIndex < audioClips.Length)
        {
            audioSource.clip = audioClips[soundIndex];
            audioSource.Play();
        }
        else if (soundIndex >= 1 && soundIndex < audioClips.Length)
        {
            audioSource.clip = audioClips[soundIndex];
            audioSource.Play();
        }
        else if (soundIndex >= 2 && soundIndex < audioClips.Length)
        {
            audioSource.clip = audioClips[soundIndex];
            audioSource.Play();
        }
        else if (soundIndex >= 3 && soundIndex < audioClips.Length)
        {
            audioSource.clip = audioClips[soundIndex];
            audioSource.Play();
        }
        else if (soundIndex >= 4 && soundIndex < audioClips.Length)
        {
            audioSource.clip = audioClips[soundIndex];
            audioSource.Play();
        }
        else if (soundIndex >= 5 && soundIndex < audioClips.Length)
        {
            audioSource.clip = audioClips[soundIndex];
            audioSource.Play();
        }
        else
        {
            Debug.LogError("Invalid sound index");
        }
    }
    private void Bell()
    {
        if (!IsNotBell)
        {
            audioSource.clip = audioClips[1];
            audioSource.Play();
        }
    }
    public void TheBell()
    {
        InvokeRepeating("Bell", 0.2f, 1.6f);
    }
}
