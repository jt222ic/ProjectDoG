using UnityEngine;
using System.Collections;

public class ColorSwitchOnDrag : MonoBehaviour {

    // Use this for initialization

    Renderer myRenderer;
    Color originalColor;
	void Start () {

        myRenderer = GetComponent<Renderer>();
        originalColor = myRenderer.material.color;
        myRenderer.material.color = myRenderer.material.color = originalColor;

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDrag()
    {
        myRenderer.material.color = new Color(0.5f, 0.5f, 0.5f);
    }


    void OnMouseExit()
    {
        myRenderer.material.color = myRenderer.material.color = originalColor;
    }
}
