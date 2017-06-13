using UnityEngine;
using System.Collections;

public class TimeController : MonoBehaviour {

    // Use this for initialization

    public GameObject player;
    public ClickableObject itemRewinding;
    public ArrayList playerPositions;
    public ArrayList ItemPosition;
    public bool isReversing;
    public PowerupManager pwnManager;


  
	void Start () {

        playerPositions = new ArrayList();           // add in player movement in list
                                                 // counting from the last player position
        ItemPosition = new ArrayList();
        pwnManager = FindObjectOfType<PowerupManager>();

    //- 1 count so we go back one step for Array List
    }
	
	// Update is called once per frame
	//void Update () {

 //       //if (Input.GetKey(KeyCode.Space))
 //       //{
 //       //    Debug.Log("PRESSED");
 //       //    isReversing = true;

 //       //}
 //       //else
 //       //{
 //       //    isReversing = false;
 //       //}
 //   }

    void Update()
    {
        //itemRewinding = FindObjectOfType<ClickableObject>();
        //if (itemRewinding != null)
        //{
            if (!isReversing)
            {
                playerPositions.Add(player.transform.position);
                //ItemPosition.Add(itemRewinding.transform.position);
            }
            else
            {
                //itemRewinding.circle.isTrigger = false;
                player.transform.position = (Vector3)playerPositions[playerPositions.Count - 1];
                playerPositions.RemoveAt(playerPositions.Count - 1);
                //itemRewinding.transform.position = (Vector3)ItemPosition[ItemPosition.Count - 1];
                //ItemPosition.RemoveAt(ItemPosition.Count - 1);
        
            }
        }
    }

