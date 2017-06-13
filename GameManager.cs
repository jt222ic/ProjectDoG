using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization

        //public Transform platformGenerator;
    private Vector3 platformstartpoint;



    private PlatformGenerator plat;

    public PlayerController Theplayer;
    private Vector3 playerstartpoint;
    private PlatformDestroyer[] platformList;
    private ScoreManager theScoreManager;
    private PowerupManager thePowerupManager;
    public Deathmenu deathMenuScreen;
    private ObjectPooling pooling;
    private CoinDestroyer[] coinList;
    public Pausemenu PausemenuScreen;
    public TimeController timeManagement;
    public StartingPointDestroyer startingPoint;
    
    public bool PlayOnce;
    public GameObject BackgroundPosition;

   

	void Start () {

        
        startingPoint = FindObjectOfType<StartingPointDestroyer>();
        plat = FindObjectOfType<PlatformGenerator>();
        thePowerupManager = FindObjectOfType<PowerupManager>();
        theScoreManager = FindObjectOfType<ScoreManager>();
        //platformstartpoint = platformGenerator.position;
        platformstartpoint = plat.transform.position;
        timeManagement = FindObjectOfType<TimeController>();
       

        playerstartpoint = Theplayer.transform.position;
        pooling = FindObjectOfType<ObjectPooling>();
        PlayOnce = false;
    }
	
	// Update is called once per frame
	void Update () {
    
    }
    public void RestartGame()
    {
      
        Theplayer.gameObject.SetActive(false);
        theScoreManager.scoreIncreasing = false;
        deathMenuScreen.gameObject.SetActive(true);
        //platformGenerator.gameObject.SetActive(true);
        plat.gameObject.SetActive(true);
        PausemenuScreen.gameObject.SetActive(false);
        //timeManagement.gameObject.SetActive(false);
       

    }
     public void Reset()
    {
        Theplayer.Death = false;
        startingPoint.gameObject.SetActive(true);
        startingPoint.startOnce = true;
        thePowerupManager.MagnetUpDuration = 0;
        thePowerupManager.PowerUpDuration = 0;
        //thePowerupManager.TimeRewindingDuration = 0;
        plat.ForEvery = 650;
        plat.MagnetEvery = 400;
        plat.WingEvery = 200;
        //plat.ForRewinery = 300;
        //timeManagement.gameObject.SetActive(true);
        ScoreManager.scoreCount = 0;
        ScoreManager.StarCount = 0;// i like to use static variable
        theScoreManager.scoreIncreasing = true;
        theScoreManager.HasDogBark = false;
        PlayOnce = true;
        Theplayer.gameObject.SetActive(false);
        deathMenuScreen.gameObject.SetActive(false);
        PausemenuScreen.gameObject.SetActive(true);
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++)                     // looping throuught the array list then set the list gameobject to false;
        {  
            platformList[i].gameObject.SetActive(false);                             // då kommer alla platformer vara uppladdade sätta till false eller måste instantierar på nytt
        }
        coinList = FindObjectsOfType<CoinDestroyer>();
        for(int j = 0; j < coinList.Length; j++)
        {
            coinList[j].gameObject.SetActive(false);
        }
        Theplayer.transform.position = playerstartpoint;
        //platformGenerator.position = platformstartpoint;
        plat.transform.position = platformstartpoint;
        Theplayer.gameObject.SetActive(true);
    }
}
