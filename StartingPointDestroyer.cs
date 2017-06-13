using UnityEngine;
using System.Collections;

public class StartingPointDestroyer : MonoBehaviour {

    // Use this for initialization
    public GameObject player;
    public bool startOnce = true;
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {


        if (player.transform.position.x -20f > this.gameObject.transform.position.x)
        {
            if (startOnce)
            {
                gameObject.SetActive(false);
                //StartCoroutine("StartingpointActive");
                startOnce = false;
            }
        }
    }
    //IEnumerator StartingpointActive()
    //{
    //    yield return new WaitForSeconds(6);
        
    //    gameObject.SetActive(false);
    //}
}
