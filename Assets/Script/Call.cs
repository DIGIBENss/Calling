using System.Collections;

using UnityEngine;

public class Call : MonoBehaviour
{
    [SerializeField] AudioManager _audioManager;
    [SerializeField] AdvertisementManager _advertisementManager;
    public void StartTheBell()
    {
        _audioManager.TheBell();
    }
    public void AcceptFeedback()
    {
        _audioManager.IsNotBell = true;
        _audioManager.PlaySound(0);
        _advertisementManager.StartCoroutine(_advertisementManager.CloseFeedback());
    }

}
