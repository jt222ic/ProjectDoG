using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class PlayAds : MonoBehaviour
{

    // Use this for initialization
    
    void Start()
    {   
    }
    private void HandleAdResult(ShowResult result)               //handle the ad fucntioning
    {
        switch (result)
        {
            case ShowResult.Finished:
                //Debug.Log("finish");
                break;
            case ShowResult.Skipped:
                //Debug.Log("player did not see a whole clio");
                break;
            case ShowResult.Failed:
                //Debug.Log("playerfail internet");
                break;
        }
    }
    public void ADWORK()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("", new ShowOptions() { resultCallback = HandleAdResult });          // string to put the id of the commercial 
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        
    }
}
