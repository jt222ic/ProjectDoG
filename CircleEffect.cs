using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CircleEffect : MonoBehaviour {

    // Use this for initialization
    float timer;
    float angle;
    int amount;
    int many;
    
    void Start()
    {
        
    }

        // Update is called once per frame
        void Update () {
        timer -= Time.deltaTime;
        angle = timer;

        transform.position = new Vector3(transform.position.x + Mathf.Cos(angle)*2, transform.position.y +Mathf.Sin(angle)*2, transform.position.z);
	
	}
}
