using UnityEngine;
using System.Collections;

public class RopeTriggered : MonoBehaviour {

    // Use this for initialization
    bool GotCut;
    //HingeJoint2D myJoint;
    Collider2D myCollider;
    Rigidbody2D myRigid;
    bool gotCutted = false;

   public TestLine line;
    
	void Start () {

        myCollider = GetComponent<Collider2D>();
        //myJoint = GetComponent<HingeJoint2D>();
        myRigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.tag == "Razor")
        {
            gotCutted = true;
            myCollider.isTrigger = false;
            gameObject.SetActive(false);
            line.DeactivateLine();
           // Destroy(this.gameObject);
        }
    }
    
}
