using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestLine : MonoBehaviour
{


    public Color color1;
    public Color color2;
    private LineRenderer lineRenderer;
   
    private int i = 0;
    Vector3 mPosition;

    
    private Vector3 pos1;
    //private Vector3 pos2;
    
    List<BoxCollider2D> lineColliders;
    BoxCollider2D colliderObject;
    bool dragging = false;
 

    void Start()
    {
        //GetBoxCollider = GetComponent<BoxCollider2D>();
        lineColliders = new List<BoxCollider2D>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetColors(color1, color2);
        lineRenderer.SetWidth(0.1F, 0.4f);                                               // the widht of the stroke
        lineRenderer.SetVertexCount(0);
        // starting point will be no stroke
    }
    // Update is called once per frame
    void Update()
    {

       
        if (Input.GetMouseButton(0))
        {


            if (!dragging)
            {

                lineRenderer.SetVertexCount(i + 1);
                mPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);               // create line from the transform condition
                lineRenderer.SetPosition(i, Camera.main.ScreenToWorldPoint(mPosition));
                i++;
                addCollidertoLine();
            }
         
            //Invoke("DeactivateLine", 2);

        }
        else if (Input.GetMouseButtonUp(0))
        {
            //pos2 = mPosition;
            lineRenderer.SetVertexCount(0);                                                     // remove line of the stroke
            i = 0;

            for (int a = 0; a < lineColliders.Count; a++)
            {
                colliderObject = lineColliders[a];                                                   //set collider to unactive ... maybe use object pooling for this phase
                colliderObject.gameObject.SetActive(false);                                                                                       //  colliderObject.gameObject.SetActive(false);                                                             //colliderObject.gameObject.SetActive(false);
            }
        }
    }
     void addCollidertoLine()
    {
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);                            // convert mouse to world point x.y
        transform.position = new Vector3(worldMousePos.x, worldMousePos.y,transform.position.z);               // update transform position after conversion of the mouse    , transform.z at 2 so the line can appear in game
        colliderObject = new GameObject("ColliderLine").AddComponent<BoxCollider2D>();
                                                                                                                            // instacne new object name colliderline with addition of box collider
        colliderObject.tag = "Razor";
       colliderObject.isTrigger = true;  // can remove
        colliderObject.transform.parent = this.gameObject.transform;                        // add child object colliderbox into the parent.
        colliderObject.transform.position = lineRenderer.transform.position;                // line renderer adapting to the position of the line 
        colliderObject.size = new Vector2(0.9f, 0.9f);
        lineColliders.Add(colliderObject);           
    }
    public void  DeactivateLine()
    {
       
        lineRenderer.SetVertexCount(0);
         i = 0;
        //colliderObject.gameObject.SetActive(false);
        dragging = true;
    }


   
      
    
 
}



