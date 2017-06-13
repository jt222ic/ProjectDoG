using UnityEngine;
using System.Collections;

public class Smoothfollow : MonoBehaviour
{

    public GameObject player; //assign this in the editor or find it in the start function.


    private float vello = 0;
    public float smoothingTime;

    

    private void LateUpdate()
    {
        //this.gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, player.transform.position, ref _velocity, 10);
        float smoothing = Mathf.SmoothDamp(gameObject.transform.position.x,player.transform.position.x + 15f, ref vello, smoothingTime);    // camera adjust to player position
        //change the last value to the time you want to complete the movement.
        Camera.main.transform.position = new Vector3(smoothing, transform.position.y, transform.position.z);

       


    }
}


