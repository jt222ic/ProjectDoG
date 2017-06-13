using UnityEngine;
using System.Collections;

public class ScreenResolution : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
     
    }
	
	// Update is called once per frame
	void Update () {

          Screen.SetResolution(1280, 720, true);
	
	}
}
