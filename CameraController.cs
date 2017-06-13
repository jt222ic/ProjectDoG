using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    // Use this for initialization

    PlayerController Theplayer;
    private Vector3 LastPlayerPosition;
    private float DistanceToMove;
    private float DistanceHeightOfPlayer;
    //private float posY = 10;

    void Start () {
        Theplayer = FindObjectOfType<PlayerController>();
        LastPlayerPosition = Theplayer.transform.position;
    }
	
	// Update is called once per frame
	void LateUpdate () {                       // call the late update, so it wont fixiated onto the playercontroller position      ///+DistanceHeightOfPlayer to transform.y

        DistanceToMove = Theplayer.transform.position.x - LastPlayerPosition.x;
        
        /* DistanceHeightOfPlayer = Theplayer.transform.position.y -LastPlayerPosition.y;    */                                    // know the distance how much camera had to move
        transform.position = new Vector3(transform.position.x + DistanceToMove, transform.position.y, transform.position.z);
        //transform.position = Vector3.Lerp(new Vector3(Theplayer.transform.position.x, posY, -10f), new Vector3(transform.position.x, posY, -10f), 10f * Time.deltaTime);
        //transform.position = Vector3.Lerp(new Vector3(transform.position.x + DistanceToMove, posY, -10f), new Vector3(Theplayer.transform.position.x, posY, -10f), 9f * Time.deltaTime);
        // just add in the camera distance move   "transform.postion = thisclass.position"
        LastPlayerPosition = Theplayer.transform.position;

        
	
	}


}
