using System;
using System.Collections;
using UnityEngine;
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
    [SerializeField] private string[] _videoFileName =  new string[] { "1.mp4", "2.mp4", "3.mp4", "4.mp4" };
    private double Length = 0;

    [SerializeField] YandexGame _sdk;
    
    public void Select(int index) => StartCoroutine(SelectC(index));
    private void OnVideoPrepared(VideoPlayer player)
    {
        Length = player.length;
    }

    private IEnumerator SelectC(int index)
    {
        if (index > _videoFileName.Length) yield break;
        if(index == 1 || index == 3)
        {
            _sdk._RewardedShow(0);
            yield return new WaitForSeconds(1);
            
        }
        Debug.Log(index);
        _iconcall.IndexImage(index);
        string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, _videoFileName[index]);
        Notnecessary();
        TheBell();
        yield return new WaitForSeconds(3f);
        Notbell();
        _player.url = videoPath;
        _player.Prepare();
        bool isLoading = true;
        _player.prepareCompleted += (value) =>
        {
            OnVideoPrepared(value);
            isLoading = false;
        };
        
        while (isLoading)
        {
            yield return null;
        }

        _player.Play();
        var i = 0;
        while (i < Length)
        {
            yield return new WaitForSeconds(1);
            i++;
        }
        Deceline();
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
        _callbell.PlaySound(1);
        _callbellobject.SetActive(true);
    }
    private void Notbell()
    {
        _callbellobject.SetActive(false);

        _videoplayerobject.SetActive(true);
    }
}
