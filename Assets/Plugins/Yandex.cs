 using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;


public class Yandex : MonoBehaviour
{
    public static Yandex instance = null;

    public string Language;
    public string Domain;

    private bool _isAdvReady = false;

    public event Action OnAdvOpenEvent;
    public event Action OnAdvCloseEvent;
    public event Action OnRewardedCloseEvent;
    public event Action OnRewardEvent;

    private void Awake()
    {
        if (instance == null)
        { 
            instance = this;
        }
        else if (instance == this)
        { 
            Destroy(gameObject); 
        }
        DontDestroyOnLoad(gameObject);
    }

    [DllImport("__Internal")]
    private static extern void ShowSimpleAdv();

    [DllImport("__Internal")]
    private static extern void ShowRewardAdv();

    [DllImport("__Internal")]
    private static extern string GetCurrentLanguage();

    [DllImport("__Internal")]
    private static extern string GetCurrentDomain();

    [DllImport("__Internal")]
    private static extern void SaveGame(string value);

    [DllImport("__Internal")]
    private static extern string LoadGame();

    [DllImport("__Internal")]
    private static extern void Rate();

    public bool IsAdvReady()
    {
        return _isAdvReady;
    }

    public void ShowAdv()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            if(_isAdvReady)
            {
                ShowSimpleAdv();
                StartCoroutine(AdvShowTimer());
            }
            
        }
    }

    public void ShowRewarded()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            ShowRewardAdv();
        }
    }

    public void GetLanguage()
    {
        if(Application.platform == RuntimePlatform.WebGLPlayer)
        {
            Language = GetCurrentLanguage();
        }
    }

    public void GetDomain()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            Domain = GetCurrentDomain();
        }
    }

    public void Save(string value)
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            SaveGame(value);
        }
    }

    public string Load()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            return LoadGame();
        }
        return null;
    }

    public void RateGame()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            Rate();
        }
    }



    public void OnAdvOpen()
    {
        OnAdvOpenEvent?.Invoke();
    }

    public void OnAdvClose()
    {
        OnAdvCloseEvent?.Invoke();
    }

    public void OnRewardedClose()
    {
        OnRewardedCloseEvent?.Invoke();
    }

    public void OnReward ()
    {
        OnRewardEvent?.Invoke();
    }

    private IEnumerator AdvShowTimer()
    {
        _isAdvReady= false;
        yield return new WaitForSeconds(180f);
        _isAdvReady= true;
    }


}
