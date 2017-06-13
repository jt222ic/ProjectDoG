using UnityEngine;
using System.Collections;

public class InstructionOptions : MonoBehaviour {

    // Use this for initialization
    public GameObject FirstPic;
    public GameObject SecondPic;
    public GameObject thirdPic;
    int j = 0;
	void Start () {

        thirdPic.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Exit()
    {
        j = 0;
        FirstPic.SetActive(false);
        SecondPic.SetActive(false);
        thirdPic.SetActive(true);
        gameObject.SetActive(false);
    }
    public void ActivateFirstPic()
    {
        j++;
        thirdPic.SetActive(false);
        if (j == 1)
        {
            FirstPic.SetActive(true);
            SecondPic.SetActive(false);
          
                }
        else if(j == 2)
        {
            FirstPic.SetActive(false);
            SecondPic.SetActive(true);
           
        }
    }
}
