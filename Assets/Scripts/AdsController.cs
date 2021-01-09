using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsController : MonoBehaviour, IUnityAdsListener
{
	private String GooglePlay_ID = "3967929";
	private bool TestMode = false;
	string myPlacementId = "rewardedVideo";

    // Start is called before the first frame update
    void Start()
    {
	    Advertisement.AddListener(this);
		Advertisement.Initialize(GooglePlay_ID, TestMode);
		Advertisement.Load(myPlacementId);
    }

    /*public void DisplayInterstitialAd()
    {
	    Advertisement.Show();
    }*/

    public void DisplayVideoAD()
    {
	    Advertisement.Show(myPlacementId);
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish (string placementId, ShowResult showResult) {
	    // Define conditional logic for each ad completion status:
	    if (showResult == ShowResult.Finished) {
		    Debug.Log("Ehre.");
		    // Reward the user for watching the ad to completion.
	    } else if (showResult == ShowResult.Skipped) {
		    Debug.Log("Unehre.");
		    // Do not reward the user for skipping the ad.
	    } else if (showResult == ShowResult.Failed) {
		    Debug.Log("The ad did not finish due to an error.");
	    }
    }

    public void OnUnityAdsReady (string placementId) {
	    // If the ready Placement is rewarded, show the ad:
	    if (placementId == myPlacementId) {
		    // Optional actions to take when the placement becomes ready(For example, enable the rewarded ads button)
	    }
    }

    public void OnUnityAdsDidError (string message) {
	    // Log the error.
    }

    public void OnUnityAdsDidStart (string placementId) {
	    // Optional actions to take when the end-users triggers an ad.
    }


    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy() {
	    Advertisement.RemoveListener(this);
    }
}
