using UnityEngine;
using System.Collections;

public class DeactivateWing : MonoBehaviour {

    // Use this for initialization
    public GameObject Wings;
    PowerupManager PWnManager;
	void Start () {

        PWnManager = FindObjectOfType<PowerupManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        PWnManager.WingsDuration = 0;
        
    }
}
