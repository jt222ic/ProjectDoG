using UnityEngine;
using System.Collections;

public class DeathOutside : MonoBehaviour {

    // Use this for initialization

    GameManager theGameManager;
    PlayerController player;
   
    public PlayAds playads;
    void Start () {
        player = FindObjectOfType<PlayerController>();
        theGameManager = FindObjectOfType<GameManager>();
      
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.tag == "Player")
        {
            theGameManager.RestartGame();

            player.movespeed = player.movespeedStore;
            player.speedMilestoneCount = player.speedMileStoneStore;
            player.DeadCount++;
            if (player.DeadCount == 4)
            {
                playads.ADWORK();
                player.DeadCount = 0;
            }
        }
    }
    }

