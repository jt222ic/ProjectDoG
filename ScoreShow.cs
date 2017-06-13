using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreShow : MonoBehaviour {

    // Use this for initialization

    public Text ScoreText;

	void Start () {

        ScoreText.text = " x Score :" + Mathf.Round(ScoreManager.scoreCount= 0);
    }
	
	// Update is called once per frame
	void Update () {

        ScoreText.text = " x Score :" + Mathf.Round(ScoreManager.scoreCount);
	}
}
