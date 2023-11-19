using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Proba : MonoBehaviour
{
    [SerializeField] private string[] _videoFileName = new string[] { "1.mp4", "2.mp4", "3.mp4", "4.mp4", "5.mp4" };
    [SerializeField] private VideoPlayer _player;
    void Start()
    {
        adas();
    }

    private void adas()
    {
        string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, _videoFileName[1]);
        _player.url = videoPath;
        _player.Prepare();
        _player.Play();
    }
}
