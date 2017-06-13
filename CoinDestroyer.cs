using UnityEngine;
using System.Collections;

public class CoinDestroyer : MonoBehaviour {

    // Use this for initialization

    public GameObject platformDestructionPoint;

    //private CoinDestroyer[] CoinList;
    //private PlayerController player;

    void Start () {
        platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");
        //player = FindObjectOfType<PlayerController>();
        //CoinList = FindObjectsOfType<CoinDestroyer>();

     
    }
	
	// Update is called once per frame
	void Update () {


        if (transform.position.x < platformDestructionPoint.transform.position.x)
        {
            gameObject.SetActive(false);
        }
      
            //if (transform.position.x < platformDestructionPoint.transform.position.x)
            //{
            //    for (int i = 0; i < CoinList.Length; i++)
            //    {
            //        if (CoinList[i].gameObject.activeInHierarchy)
            //        {
            //            CoinList[i].gameObject.SetActive(false);
            //        }
            //    }
            //}
        }
      

    
}
