using UnityEngine;

public class Call : MonoBehaviour
{
    [SerializeField] AudioManager _audioManager;
    [SerializeField] AdvertisementManager _advertisementManager;

    public void StartTheBell()
    {
        _audioManager.TheBell();
        _audioManager.PrepareSound(0);
    }

    public void AcceptFeedback()
    {
        _audioManager.IsNotBell = true;
        _audioManager.PlaySound();
        _advertisementManager.StartCoroutine(_advertisementManager.CloseFeedback());
    }

}
