using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class AdvertisementManager : MonoBehaviour
{
    [Header("FullscreenShow")]
    [SerializeField] private TextMeshProUGUI _textad;
    [SerializeField] private YandexGame _sdk;
    [SerializeField] private GameObject _fulladScreen;

    [Header("Feedback")]
    [SerializeField] private GameObject _feedback;
    [SerializeField] private Call _call;
    private void Start()
    {
        //StartCoroutine(BeforeAdvertising());
        //StartCoroutine(BeforeFeedback());
    }
   
    private IEnumerator BeforeFeedback()
    {
        yield return new WaitForSeconds(30f);
        _feedback.SetActive(true);
        _call.StartTheBell();
    }
    public IEnumerator CloseFeedback()
    {
        yield return new WaitForSeconds(13f);
        _feedback.SetActive(false);
    }
    private IEnumerator BeforeAdvertising()
    {
        yield return new WaitForSeconds(60f);
        _fulladScreen.SetActive(true);
        StartCoroutine(AfterAdvertising());
    }
    private IEnumerator AfterAdvertising()
    {
        for (int i = 10; i >= 0; i--)
        {
            yield return new WaitForSeconds(1f);
            _textad.text = i.ToString();
            if(i == 0)
            {
                _sdk._FullscreenShow();
                _fulladScreen.SetActive(false);
            }
        }
    }
}
