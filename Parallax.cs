using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {


    // reference background gameobject// transform
    public Transform DestrctionPoint;
    public Transform[] background;
    private float[] parallaxScales;
    public float smoothing;
    float Width;
    private Vector3 previousCameraPosition;

    public Vector3 StartingPosition;
    public PlayerController checkplayer;

	// Use this for initialization
	void Start () {

        checkplayer = FindObjectOfType<PlayerController>();
           //background.GetComponent(Rende).bounds.extents.x;
           previousCameraPosition = transform.position;
        parallaxScales = new float[background.Length];        //  same size as the transform background

        for(int i = 0; i< parallaxScales.Length; i++)
        {
            parallaxScales[i] = background[i].position.x * -0.5f;
                                                             // moving the background x position by 01f   moving the first object
        }
	}
    // Update is called once per frame
    void LateUpdate() {

        
        for (int i = 0; i < background.Length; i++)
        {
          
               Vector3 Paralax = (previousCameraPosition - transform.position) * (parallaxScales[i] / smoothing);

            background[i].position = new Vector3(background[i].position.x + Paralax.x, background[i].position.y + Paralax.y, background[i].position.z);
            StartingPosition = background[i].position;

            if (background[i].position.x < DestrctionPoint.transform.position.x)
            {
                background[i].position = new Vector3(background[i].position.x + 100, background[i].position.y, background[i].position.z);
            }
            else if(checkplayer.Death)
            {
                background[i].position = StartingPosition;
             
            }
        }
        previousCameraPosition = transform.position;
        
	}
}
