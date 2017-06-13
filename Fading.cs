using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour {

    // Use this for initialization

    public Texture2D FadeOutTexture;
    public float FadeSpeed;


    private int DrawDepth = -1000;                  // drawing in hierackty 
    private float alpha = -1.0f;


    private int fadeDirection;                 //if the value is -1 it will fade in  if the value is 1 it will fade out
	


    void OnGUI()
    {
        alpha += fadeDirection * FadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);                                         // gui use alpha value between 0 and 1  use clamp return 0 or 1

        GUI.color = new Color(GUI.color.r,GUI.color.g,GUI.color.b,alpha);                          // RGB scale with alpha
        GUI.depth = DrawDepth;
        GUI.DrawTexture( new Rect (0, 0, Screen.width, Screen.height),FadeOutTexture);    //draw texture to fill out the whole screen
    }
    public float BeginFade(int Direction)
    {
        fadeDirection = Direction;
        return (FadeSpeed);
    }
    void OnLevelWasLoaded()
    {
        //Debug.Log("LEVEL IS LOADED");
        alpha = 1;     // use this if the alpha is not set to 1 by default
        BeginFade(-1);  // call the fade in function
    }
}
