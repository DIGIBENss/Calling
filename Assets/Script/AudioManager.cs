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

    public void PrepareSound(int index)
    {
        audioSource.clip = audioClips[index];
        audioSource.clip.LoadAudioData();
    }

    public void PlaySound() =>
        audioSource.Play();
    

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
