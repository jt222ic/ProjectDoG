using UnityEngine;
using System.Collections;

public class RewindPowerUp : MonoBehaviour {

    // Use this for initialization
    PowerupManager PwUpManager;
    bool RewindTrue;
    float rewindTime = 1.5f;
    void Start () {
        PwUpManager = FindObjectOfType<PowerupManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)           // on collision getting the game object to detect the player TAg then add points depending on ScoreGive   " IMPORTANT TO WRITE EACH word CORRECTly or Unity wont understand  "OnTriggerEnter2D"
    {
        if (other.gameObject.tag == "Player")
        {
            RewindTrue = true;
            //PwUpManager.ActivateRewindingTime(RewindTrue, rewindTime);
            gameObject.SetActive(false);
        }
    }
}
