using UnityEngine;

public class Call : MonoBehaviour
{
    [SerializeField] AudioManager _audioManager;
    [SerializeField] AdvertisementManager _advertisementManager;
    [SerializeField] GameObject _accept;
    [SerializeField] GameObject _decline;

    public void StartTheBell()
    {
        _audioManager.TheBell();
        _audioManager.PrepareSound(1);
        _audioManager.PlaySound();
    }

    public void AcceptFeedback()
    {
        _audioManager.IsNotBell = true;
        _audioManager.PrepareSound(0);
        _audioManager.PlaySound();
        _decline.SetActive(false);
        _accept.SetActive(false); 
        _advertisementManager.StartCoroutine(_advertisementManager.CloseFeedback());
    }

}
