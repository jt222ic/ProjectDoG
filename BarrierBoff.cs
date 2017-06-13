using UnityEngine;
using System.Collections;

public class BarrierBoff : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)           // on collision getting the game object to detect the player TAg then add points depending on ScoreGive   " IMPORTANT TO WRITE EACH word CORRECTly or Unity wont understand  "OnTriggerEnter2D"
    {

        if (other.gameObject.tag == "Barrrier")
        {
            //Debug.Log("BOFF");
            this.gameObject.SetActive(false);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Barrrier")
        {
            //Debug.Log("BAM");
            this.gameObject.SetActive(false);
        }

    }
}