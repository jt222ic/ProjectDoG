using UnityEngine;
using System.Collections;

public class MovingHorizontelplatform : MonoBehaviour
{

    // Use this for initialization

    Vector3 WorldMousePos;
    Vector3 MovingHorizontel;
    float distance = 0;
    Color originalColor;

    //Renderer myRenderer;
    public float MaxDistanceTodown;
    Vector3 DownDirectionnewTransform;
    bool drag;
    BoxCollider2D myCollider;
    Rigidbody2D myRigi;
    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
        //myRenderer = GetComponent<Renderer>();
        //originalColor = myRenderer.material.color;
        //myRenderer.material.color = myRenderer.material.color = originalColor + new Color(0.2f, 0.2f, 0.2f);
        DownDirectionnewTransform.y = transform.position.y - MaxDistanceTodown;
    }
    // Update is called once per frame
    void Update()
    {
        WorldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //if(transform.position.y <= DownDirectionnewTransform.y)
        //{
        //    Debug.Log("DropTheBomb");
        //    //    //
        //    if (!drag)
        //    {
        //        myRigi = gameObject.AddComponent<Rigidbody2D>();
        //        //myCollider.isTrigger = true;
        //        drag = true;
        //    }
        //}
    }
    void OnMouseDrag()
    {
        //myRenderer.material.color = originalColor;
        MovingHorizontel = new Vector3(transform.position.x, WorldMousePos.y, distance);
        transform.position = MovingHorizontel;

    }

   

    
    }

