using UnityEngine;
using System.Collections;

public class TeetherToother : MonoBehaviour
{



    public bool rotatingLeft;
    public bool rotatingRight;
    public float currentZ;
    public bool Leftsidecollided;
    float HIGHERPOW;

    Rigidbody2D myRigidbody;
    BoxCollider2D myCollider;

   public GameObject player;
    Rigidbody2D playerRigid;

    public float pushVerticalJump;
    public float pushHorizontalJump;
    // Use this for initialization
    void Start()
    {
        rotatingLeft = false;
        rotatingRight = false;
        
        currentZ = transform.localEulerAngles.z;
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
        transform.localEulerAngles = new Vector3(0, 0, -65);         // start position for angle

        playerRigid = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localEulerAngles.z < currentZ)              // telling where the rotation is 
        {
            currentZ = transform.localEulerAngles.z;
            rotatingRight = true;
            rotatingLeft = false;
            myRigidbody.AddForce(transform.forward);


        }
        else if (transform.localEulerAngles.z > currentZ)
        {
            currentZ = transform.localEulerAngles.z;
            rotatingRight = false;
            rotatingLeft = true;
        }
        else
        {
            rotatingRight = false;
            rotatingLeft = false;
        }

    }
    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.tag =="Master")
        {
            myCollider.isTrigger = false;
            myRigidbody.velocity = new Vector2(280,0);
            myRigidbody.AddForce(myRigidbody.velocity);
            playerRigid.transform.position = new Vector3(player.transform.position.x + myRigidbody.position.x,player.transform.position.y,player.transform.position.z);
            playerRigid.velocity = new Vector2(pushVerticalJump, playerRigid.velocity.y + pushHorizontalJump);


            StartCoroutine("triggerhappy");
            
        }
    }
    public IEnumerator triggerhappy()
    {
        yield return new WaitForSeconds(0.6f);             // when missing the timing of the jump
        myCollider.isTrigger = true;
      
      
    }
    }


