using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour {

    Vector3 WorldMousePos;
    float distance = -1.2f;
    Vector3 startposition;
    bool dragging = true;
    Vector3 LeftDirectionnewTransform;
    Vector3 RightDirectionnewTransform;
    Vector3 DragMouse;
    public float MaxDistanceToRight;
    public float MaxDistanceToLeft;
    //bool thatstrue = false;


    float velocity = 3;
    public GameObject Wheel;
    float duration;
    bool movingobject;
    Color originalColor;

    Animator anime;

    
	void Start () {
        anime = Wheel.GetComponent<Animator>();
        LeftDirectionnewTransform.x = transform.position.x - MaxDistanceToLeft;
        RightDirectionnewTransform.x = transform.position.x + MaxDistanceToRight;
    }
	
	// Update is called once per frame
	void Update () {

        WorldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(transform.position.x <= LeftDirectionnewTransform.x || transform.position.x >= RightDirectionnewTransform.x)
        {
            
            dragging = false;
            movingobject = false;
        }
         if(transform.position.x >= LeftDirectionnewTransform.x)
        {
             //Debug.Log("YEs");
        }


        if(movingobject)
        {
            transform.position += Vector3.left * velocity * Time.deltaTime;
        }
    }
    void OnMouseDrag()
    {
        
        if (dragging)
        {
            anime.SetBool("IfHolding", true);
            //myRenderer.material.color = new Color(0.5f, 0.5f, 0.5f);
            DragMouse = new Vector3(WorldMousePos.x, transform.position.y, distance);
            transform.position = DragMouse;
            
            movingobject = true;

        }
    }
    //void OnMouseExit()
    //{
    //    transform.position += Vector3.left * velocity * Time.deltaTime;
    //}
}
