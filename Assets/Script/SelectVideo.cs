using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Video;


public class SelectVideo : MonoBehaviour
{
    [SerializeField] private VideoPlayer _player;
    [SerializeField] private GameObject _menucontent;
    [SerializeField] private GameObject _textmain;
    [SerializeField] private GameObject _videoplayerobject;
    [SerializeField] private string[] _videoFileName =  new string[] { "1.mp4", "2.mp4", "3.mp4" };
    private double Length = 0;
    
    public void Select(int index) => StartCoroutine(SelectC(index));
    private void OnVideoPrepared(VideoPlayer player)
    {
        Length = player.length;
        print(player.length);
    }

    private IEnumerator SelectC(int index)
    {
        if (index > _videoFileName.Length) yield break;
        if(index == 2)
        {
            //тут реклама типа емае
        }
        string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, _videoFileName[index]);
        Notnecessary();
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
        _videoplayerobject.SetActive(true);
        _textmain.SetActive(false);
        _menucontent.SetActive(false);
    }
}
