using UnityEngine;
using System.Collections;

public class ClickableObject : MonoBehaviour {
    Vector3 WorldMousePos;
    float distance = 0;

    public TestLine line;

    public CircleCollider2D circle;
    private Rigidbody2D myRigidbody;
    private float colorchanging;
   


    private Vector2 speed;
   public bool addingRigidOnce;
    // Use this for initialization



    //COlor hovering

    private Renderer myRenderer;
    Color originalColor;

    void Start () {
        myRenderer = GetComponent<Renderer>();
       circle = GetComponent<CircleCollider2D>();                          //myRigidbody.gameObject.AddComponent<Rigidbody2D>();
       circle.isTrigger = true;
       addingRigidOnce = true;
       originalColor = myRenderer.material.color;
       myRenderer.material.color = myRenderer.material.color = originalColor + new Color(1f, 1f, 1f);
    }
	// Update is called once per frame
	void Update () {

        WorldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        

    }
    void OnMouseDrag()
    {
        
        if (addingRigidOnce)
        {
            myRigidbody = gameObject.AddComponent<Rigidbody2D>();
            addingRigidOnce = false;
            myRigidbody.mass = 10;
        }
        Vector3 DragMouse = new Vector3(WorldMousePos.x, WorldMousePos.y, distance);
         Camera.main.ScreenToWorldPoint(DragMouse);
         transform.position = DragMouse;
         
    }
    void OnMouseOver()
    {
        //myRenderer.material.color = myRenderer.material.color = originalColor + new Color(0f, 255f, 0f);

    }
    void OnMouseExit()
    {
        myRenderer.material.color = originalColor;

    }




}


