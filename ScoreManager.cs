using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{


    public Text scoreText;
    public Text HighscoreText;
    public Text EndScoreText;

    public static float scoreCount;
    public static float StarCount;

    public float HighscoreCount;

    public float PointperSecond;
    public bool scoreIncreasing;

    public Text AnnounchingScore;
    private GameManager gamemanager;

   public bool HasDogBark;
    public AudioSource DogBark;

    bool PlayerHasAlreadyPlayOnce;
    // Use this for initialization
    void Start()
    {

        gamemanager = FindObjectOfType<GameManager>();
        DogBark = GetComponent<AudioSource>();
       

    }

    // Update is called once per frame
    void Update()
    {
        AnnounchingScore.text = ("");          // EMPTY FRONT PAGE
        PlayerHasAlreadyPlayOnce = gamemanager.PlayOnce;
        
        if (scoreIncreasing)   // to be able to stop the score increase if the player dies  to set the bool loop to control from outside the class
        {
            scoreCount += PointperSecond * Time.deltaTime;
        }
        if (scoreCount > HighscoreCount)         // when reaching new height in highscore
        {
            
            if (PlayerHasAlreadyPlayOnce == true && scoreCount > HighscoreCount)
            {
                if (!HasDogBark)
                {
                    DogBark.Play();
                    HasDogBark = true;
                }
                HighscoreCount.ToString("");
                AnnounchingScore.text = ("New HighScore!");
                StartCoroutine("Highscore");
            }
            HighscoreCount = scoreCount;         // the highscore became the score
        }
        scoreText.text = " x score: " + Mathf.Round(scoreCount);       // roundof to whole number
        HighscoreText.text = "highscore :" + Mathf.Round(HighscoreCount);
        EndScoreText.text = "End Result :" + Mathf.Round(scoreCount) +"           Star:         x" + Mathf.Round(StarCount); ;
    }

    public void addScore(int ScoreGive)
    {
        scoreCount += ScoreGive;
    }

    public void StarCollect(int StarCollection)
    {
        StarCount += StarCollection;
    }

    IEnumerator Highscore()
    {
        while (AnnounchingScore.text == "New HighScore!ads")
        {
             
            yield return new WaitForSeconds(3f);
            AnnounchingScore.text = "";
        }
        
    }




}

