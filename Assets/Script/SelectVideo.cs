using System;
using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;
using YG;

public class SelectVideo : MonoBehaviour
{
    [SerializeField] private VideoPlayer _player;
    [SerializeField] private GameObject _menucontent;
    [SerializeField] private GameObject _textmain;
    [SerializeField] private GameObject _videoplayerobject;
    [SerializeField] private AudioManager _callbell;
    [SerializeField] private GameObject _callbellobject;
    [SerializeField] private IconCall _iconcall;
    [SerializeField] private string[] _videoFileName =  new string[] { "1.mp4", "2.mp4", "3.mp4", "4.mp4", "5.mp4" };
    private int _index;

    [SerializeField] YandexGame _sdk;
    [SerializeField] private AdvertisementManager _advertisementmanager;
    
    public void Select(int index) => StartCoroutine(SelectC(index));
    private IEnumerator SelectC(int index)
    {
        if (index > _videoFileName.Length) yield break;
        if(index == 1 || index == 3)
        {
            _sdk._RewardedShow(0);
            yield return new WaitForSeconds(1);
            
        }
        _iconcall.IndexImage(index);
        _callbell.PrepareSound(1);
        string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, _videoFileName[index]);
        Notnecessary();
        TheBell();
        yield return new WaitForSeconds(3f);
        PrepareVideo(videoPath);
        Notbell();
    }

    public void PrepareVideo(string videoPath)
    {
        _player.url = videoPath;
        _player.Prepare();
        _player.Play();
        _player.loopPointReached += OnVideoEnd;
    }
    private void OnVideoEnd(VideoPlayer player)
    {
        _index++;
        Debug.Log(_index);
        if (_index == 2)
        {
            _advertisementmanager.BeforeFeedback();
        }
        Deceline();
        _player.loopPointReached -= OnVideoEnd;
    }
    public void Deceline()
    {
        _textmain.SetActive(true);
        _videoplayerobject.SetActive(false);
        _menucontent.SetActive(true);
        _player.Stop();
    }

    private void Notnecessary()
    {
        _textmain.SetActive(false);
        _menucontent.SetActive(false);
    }

    private void TheBell()
    {
        _callbell.PlaySound();
        _callbellobject.SetActive(true);
    }

    private void Notbell()
    {
        _callbellobject.SetActive(false);
        _videoplayerobject.SetActive(true);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus) Time.timeScale = 0;
        else Time.timeScale = 1;
    }
}
