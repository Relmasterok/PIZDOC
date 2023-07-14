using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ADS : MonoBehaviour, IUnityAdsInitializationListener
{
    public bool testMod;
    private string androidGameId = "5347677";
    private string IOSGameId = "5347676";
    private string gameId;
    void Awake()
    {
        InitializedADS();
    }

 
    public void InitializedADS()
    {
        gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? IOSGameId : androidGameId;
        Advertisement.Initialize(gameId, testMod);
    }
    public void OnInitializationComplete()
    {
        throw new System.NotImplementedException();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        throw new System.NotImplementedException();
    }
}
