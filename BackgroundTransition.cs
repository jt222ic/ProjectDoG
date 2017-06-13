using UnityEngine;
using System.Collections;

public class BackgroundTransition : MonoBehaviour {

    // Use this for initialization

    public float duration;


    public SpriteRenderer sRender;
    float lerp;


    void Start () {

        sRender = GetComponent<SpriteRenderer>();
        sRender.material.SetColor("_Color", Color.black); // the bottom color
        sRender.material.SetColor("_Color2", Color.white);
        
    }
	
	// Update is called once per frame
	void Update () {


      
            lerp = Mathf.PingPong(Time.time, duration) / duration;
        sRender.material.SetColor("_Color", Color.Lerp(HexToColor("fa8856"), HexToColor("1F2123"), lerp));          // top color                Day: fa8856                Night: 1F2123      hexvalue
                                                                                                                    // lerp jumping value 0 to 1  like ping pong
        sRender.material.SetColor("_Color2", Color.Lerp(HexToColor("527fc1"), HexToColor("7ae0ec"), lerp));         //bottom color       Night :  527fc1                    day :       7ae0ec               

    }

    Color HexToColor(string hex)
    {
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);                // RGB STRING
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        return new Color32(r, g, b, 255);
    }
}
