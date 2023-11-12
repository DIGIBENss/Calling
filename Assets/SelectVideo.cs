using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Video;

public class SelectVideo : MonoBehaviour
{
    [SerializeField] private List<VideoClip> _clips;
    [SerializeField] private VideoPlayer _player;
    [SerializeField] private Canvas _menu;

    public void Select(int index) => StartCoroutine(SelectC(index));

    private IEnumerator SelectC(int index)
    {
        if (index > _clips.Count) yield break;
        _menu.enabled = false;
        _player.clip = _clips[index];
        yield return new WaitForSeconds(3);
        _player.Play();
        var value = 0;
        while (value < _player.clip.length)
        {
            yield return new WaitForSeconds(1);
            value++;
        }
        Deceline();
    }

    public void Deceline()
    {
        _menu.enabled = true;
        _player.Stop();
    }
}
