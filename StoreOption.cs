using UnityEngine;
using System.Collections;

public class StoreOption : MonoBehaviour {





    public void AddScore1000()
    {

        //ScoreManager.scoreCount = 1000;
        IAPmanager.Instance.Buy1000Star();
    }

    public void AddScore2000()
    {

        //ScoreManager.scoreCount = 2000;

        IAPmanager.Instance.Buy2000Star();
    }

    public void AddScore3000()
    {

        //ScoreManager.scoreCount = 3000;

        IAPmanager.Instance.Buy3000Star();
    }

    public void NoADs()
    {
        Debug.Log("NOADS");

        IAPmanager.Instance.BuyNoAds();
    }
    public void ExitStore()
    {

        gameObject.SetActive(false);
    }
}
