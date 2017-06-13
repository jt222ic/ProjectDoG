using UnityEngine;
using System.Collections;

public class PlatformDestroyer : MonoBehaviour {

    public GameObject platformDestructionPoint;


    private PlatformDestroyer[] platformlist;
    

    // Use this for initialization
    void Start () {

        platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");        /// fidn the Gameobject.. if you havent put an component into the 
        
    }

    // Update is called once per frame
    void Update () {

        if (transform.position.x < platformDestructionPoint.transform.position.x)
        {
            platformlist = FindObjectsOfType<PlatformDestroyer>();
            
           // gameObject.SetActive(false);
            for (int i = 1; i < platformlist.Length; i++)
            {
                //Debug.Log(platformlist[i]);
                //Destroy(platformlist[i]);
                this.platformlist[i].gameObject.SetActive(false);
            }
            //////gameObject.SetActive(false);
            ////this.gameObject.SetActive(false);
            //////Destroy(this.gameObject);
        }
    }
}
