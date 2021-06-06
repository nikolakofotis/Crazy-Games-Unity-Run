using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class AdScript : MonoBehaviour, IUnityAdsListener
{

#if UNITY_IOS
    private string gameId = "3745182";
#elif UNITY_ANDROID
    private string gameId = "3745183";
#endif

    public ManageLives lives;
    public string banner = "banner";
    public string rewarded = "rewardedVideo";
    public string normalAd = "video";
    public string nextLevelAd = "passedLevelAd";

   


    void Start()
    {

        Advertisement.AddListener(this);
        Advertisement.Initialize("3745183", false);



    }


    public void StartBanner()
    {
        StartCoroutine(ShowBannerWhenInitialized());
    }

    public void HideBanner()
    {
        Advertisement.Banner.Hide();
    }
    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(banner);
    }


    
   

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady(rewarded))
        {

            Advertisement.Show(rewarded);
        }
        else
        {
           
        }
    }

    public void OnUnityAdsDidFinish(string surfacingId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            if (surfacingId == rewarded)
            {
                StartCoroutine(lives.IncreaseLives());
            }
           
            
        }
        else if (showResult == ShowResult.Skipped)
        {
            if (surfacingId == rewarded)
            {
               
            }
            
        }
        else if (showResult == ShowResult.Failed)
        {
            if (surfacingId == rewarded)
            {
                
            }
           
            
        }
    }


    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //throw new System.NotImplementedException();
    }
}
