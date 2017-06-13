using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{


    public float movespeed;
    public float jumpforce;

    public Rigidbody2D myRigidBody;
    public Collider2D myCollider;
    private Animator myAnimator;


    public bool grounded;
    public LayerMask WhatisGround;
    public Transform groundCheck;
    public float groundCheckRadius;


    public float speedMilestoneCount;
    public float speedMultiplier;            // when the player start to speed up
    public float speedIncreaseMilestone;


    public float movespeedStore;
    public float speedMileStoneStore;

    public bool jumpOnce = true;
    public bool Death;
    public int DeadCount;


    float TimerInAir = 1;
    //float V_verticaljumpspeed;
    float gravity;

    float Timejumos =2;
    
    
    public GameManager theGameManager;
   
    public bool TimeHastoRewind;

    // find the slope

    public float maxDashTime = 1.0f;
    public float dashSpeed = 1.0f;
    public float dashStoppingSpeed = 0.1f;
    private float currentDashTime;
    public Vector3 MoveDirection;


    //public GameObject SnowDust;
    public ObjectPooling objectPool;
    GameObject PoolEffect;
    // public float slopeFriction;
    public PhysicsMaterial2D Slope;

    public PlayAds playads;
    // Music add on

    

    private AudioSource sound;
    // Use this for initialization


    // rotation in the air

    float justifyAir = 0.1f;

    float currentDashSpeed;
    float MaxDashSpeed = 30;
    float Distancejump = 40;
    float timeClicking = 2;
    float speed = 40;
    PowerupManager pwupManager;
    TimeController TimeManager;
    BasicTimeSkip timeskipColor;

    public bool Rewinding;

    void Start()
    {
        timeskipColor = FindObjectOfType<BasicTimeSkip>();
        pwupManager = FindObjectOfType<PowerupManager>();
        Death = false;
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
        myAnimator = GetComponent<Animator>();
        speedMilestoneCount = speedIncreaseMilestone;
        movespeedStore = movespeed;
        speedMileStoneStore = speedMilestoneCount;

        sound = GetComponent<AudioSource>();
        currentDashTime = maxDashTime;
        TimeManager = FindObjectOfType<TimeController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //if (!TimeManager.isReversing)
        //{
            RotationAtTheAir();

            if (transform.position.x > speedMilestoneCount)              // if player position reach speed milestone 
            {
                speedMilestoneCount += speedIncreaseMilestone;

                speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;      // increase the distance to the next milestone by the speed milestone
                movespeed = movespeed * speedMultiplier;             // inicreased speedmultiplier.
            }
            //grounded = Physics2D.IsTouchingLayers(myCollider, WhatisGround);   //if myCollider(Collider2d) touching the layerMask(whatisGround)


            /* var distance = myRigidBody.velocity.x * Time.deltaTime; */ // knowing the distance  


            if (movespeed < 21)
            {
                myRigidBody.gravityScale = 7.5f;
            }

            if (movespeed == 22)
            {

                myRigidBody.gravityScale = 8.5f;
            }
            if (movespeed > 23 && movespeed < 29)
            {
                myRigidBody.gravityScale = 9.15f;
            }
            if (movespeed >= 30)
            {
                movespeed = 30;
                myRigidBody.gravityScale = 9.15f;
            }
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatisGround);
            myRigidBody.velocity = new Vector2(movespeed, myRigidBody.velocity.y);

            // RotationAtTheAir();
            //if (pwupManager.JumpOn)
            //{
            //    Debug.Log("Jump!");
            //    currentDashSpeed = 100;
            //    myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpforce);
            //    //myRigidBody.AddForce(new Vector2(myRigidBody.velocity.x * currentDashSpeed, myRigidBody.velocity.y), 0);
            //}
            if (jumpOnce)
            {
                jumpOnce = false;
                if (!grounded)
                {
                    myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpforce);
                    sound.Play();
                    //Instantiate(SnowDust, transform.position, Quaternion.identity);
                    //objectPool.getPooledObject();
                    //for(int i = 0;  i< objectPool.Length; i++)
                    //{
                    //    objectPool[i].getPooledObject();
                    //}
                    PoolEffect = objectPool.getPooledObject();
                    PoolEffect.SetActive(true);
                    PoolEffect.transform.position = transform.position;
                    PoolEffect.transform.rotation = transform.rotation;
                    // have a destruction point to set the object inactive
                }
            }

            if (grounded)
            {
                jumpOnce = true;
            }
            ifSlope();
            //}

            myAnimator.SetFloat("Speed", movespeed);
            myAnimator.SetBool("Grounded", grounded);
        //}
    }   
    void RotationAtTheAir()
    {
        if (!grounded)
        {
            myRigidBody.freezeRotation = true;
        }
    }

    void ifSlope()     // need for research
    {

      if(grounded)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 1f, WhatisGround);
            // vertical normalisation
                
            if (hit.collider != null && Mathf.Abs(hit.normal.x) > 0.1f)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x - (hit.normal.x * Slope.friction), myRigidBody.velocity.y);
                Vector3 pos = transform.position;
                pos.y += -hit.normal.x * Mathf.Abs(myRigidBody.velocity.x) * Time.deltaTime * (myRigidBody.velocity.x - hit.normal.x > 0 ? 1 : -1);
                transform.position = pos;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Death")
            {
            //Rewinding = true;
            //if (!pwupManager.RewindOn)
            //{
                Death = true;
                theGameManager.RestartGame();
                movespeed = movespeedStore;
                speedMilestoneCount = speedMileStoneStore;
                DeadCount++;
                if (DeadCount == 4)
                {
                    playads.ADWORK();
                    DeadCount = 0;
            //    }
            }
        }
            if (other.gameObject.tag == "Master" || other.gameObject.tag == "Razor")
            {

                Physics2D.IgnoreCollision(other.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Death")
        {

            Death = true;
                theGameManager.RestartGame();
                movespeed = movespeedStore;
                speedMilestoneCount = speedMileStoneStore;
                DeadCount++;
                if (DeadCount == 4)
                {
                    playads.ADWORK();
                    DeadCount = 0;
                }
        }
    } 
    //void Calculate()                  // need more research                                                            // captial letter to showing them in physics Term
    //{
    //    var H_Height = jumpforce;
    //    var D_jumpDistance = myRigidBody.velocity.x * Time.deltaTime;  
    //                                                                                        // Normal Jump Distance
    //    var T_airCounting = TimerInAir / D_jumpDistance;                                 // counting the time in air divided by jumpdistance
        
    //     gravity = 2 * H_Height / (2*(T_airCounting / 2));                                 // cannot add in ^2 for some reason     attributes for gravity
    //    //V_verticaljumpspeed = myRigidBody.gravityScale * T_airCounting / 2;
    //}
}
