using UnityEngine;
using System.Collections;

public class CoinToPowerup : MonoBehaviour {

    // Use this for initialization
    public GameObject PowerAbsorbCoin;
    public float Incremential = 10f;
    PowerupManager PwnManager;

    void Start()
    {
        PwnManager = FindObjectOfType<PowerupManager>();
        if(PwnManager.MagnetOn)
        {
            PowerAbsorbCoin = GameObject.Find("AbsorbCoin");
        }
    }
    void LateUpdate()
    {
        if (PwnManager.MagnetOn)
        {
            PowerAbsorbCoin = GameObject.Find("AbsorbCoin");
            if (GameObject.Find("AbsorbCoin") != null)
            {
                if (transform.position.x - 4f < PowerAbsorbCoin.transform.position.x)
                {
                    transform.position = Vector3.Lerp(transform.position, PowerAbsorbCoin.transform.position, Incremential * Time.deltaTime);
                }
                 if (transform.position.x <PowerAbsorbCoin.transform.position.x)
                {
                    transform.position = Vector3.Lerp(transform.position, PowerAbsorbCoin.transform.position, Incremential * Time.deltaTime);
                }
            }
        }
    }

}

