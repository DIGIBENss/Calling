using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class SelectVideo : MonoBehaviour
{
    [SerializeField] private VideoPlayer _player;
    [SerializeField] private GameObject _menucontent;
    [SerializeField] private GameObject _textmain;
    [SerializeField] private GameObject _videoplayerobject;
    [SerializeField] private string[] _videoFileName =  new string[] { "1.mp4", "2.mp4", "3.mp4" };
    public void Select(int index) => StartCoroutine(SelectC(index));

    private IEnumerator SelectC(int index)
    {
      if (index > _videoFileName.Length) yield break;
        string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, _videoFileName[index]);
        Notnecessary();
      yield return new WaitForSeconds(0.15f);
      _player.url = videoPath;
      _player.Play();
      var i = 0;
        while (i < _player.clip.length)
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
