using UnityEngine;
using System.Collections;

public class CoinToMeter : MonoBehaviour
{

    // Use this for initialization
    public GameObject meter;
    public float Incremential = 7f;

    void Start()
    {
        meter = GameObject.Find("alienGreen_walk2 (1)");
    }
    void Update()
    {

        transform.position = Vector3.Lerp(transform.position, meter.transform.position, Incremential * Time.deltaTime);
    }

}