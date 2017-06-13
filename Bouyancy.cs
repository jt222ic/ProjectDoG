using UnityEngine;
using System.Collections;

public class Bouyancy : MonoBehaviour {

    // Use this for initialization
    public float UpwardForce = 12.72f;
    public float DownwardForce = 20f;
    public GameObject SplashParticles;
    private bool isInWater = false;
    private bool splash = false;


    Rigidbody2D rigi;
    BoxCollider2D boxCollider;


    private void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();

        rigi.freezeRotation = true;
    }
    void OnTriggerEnter2D(Collider2D Other)
    {
        //Debug.Log("BOOBBIES");
        if (Other.tag == "Player")
        {
            boxCollider.isTrigger = false;
        }
        if (Other.tag == "Water")
        {
            isInWater = true;
            rigi.drag = 5f;
            rigi.angularDrag = 5f;
            
        }
        if (Other.tag == "Water" && !splash)
        {
            Instantiate(SplashParticles, transform.position, Quaternion.identity);
            splash = true;
        }
    }

    void OnTriggerExit2D(Collider2D Other)
    {

        if (Other.tag == "Water")
            {
            splash = false;
                isInWater = false;
                rigi.drag = 0.5f;
                rigi.angularDrag = 0.5f;
            }
    }
    void FixedUpdate()
    {

        //Vector2 shiraTEnsei = Vector2.down * DownwardForce;
        //rigi.AddForce(shiraTEnsei,ForceMode2D.Force);

        if (isInWater)
        {
            Vector2 force = Vector2.up * UpwardForce;
            rigi.AddForce(force, ForceMode2D.Force);
           
        }
    }
}
