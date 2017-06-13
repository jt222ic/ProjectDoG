using UnityEngine;
using System.Collections;

public class ScorePickups : MonoBehaviour
{


    private ScoreManager scoremanager;
    public int ScoreGive;
    public bool GetCollided;
    Animator animator;
    //AudioSource Audio;
    public AudioClip Audio;
    AudioSource Audiio;
    AudioSource sound;
    //public int startingPitch = 4;           //Fading effect
    //public int timeToDecrease = 5;
    // Use this for initialization
   
    int StarCollected;


    CoinToMeter coinMeter;
   
    void Start()
    {
        scoremanager = FindObjectOfType<ScoreManager>();
        animator = GetComponent<Animator>();
        //Audiio = GetComponent<AudioSource>();
        sound = GetComponent<AudioSource>();
        coinMeter = GetComponent<CoinToMeter>();
        coinMeter.enabled = false;
        //sound.pitch = startingPitch;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(sound.pitch);
        //if (sound.pitch > 0)
        //    sound.pitch -= Time.deltaTime * startingPitch / timeToDecrease;                        /// sound pitch with fading effect

    }

    void OnTriggerEnter2D(Collider2D other)           // on collision getting the game object to detect the player TAg then add points depending on ScoreGive   " IMPORTANT TO WRITE EACH word CORRECTly or Unity wont understand  "OnTriggerEnter2D"
    {

        if (other.gameObject.tag == "Player")
        {
                                                              //Audiio.PlayOneShot(Audio,0.7f);
                                                   //AudioSource.PlayClipAtPoint(Audio, Camera.main.transform.position);
            sound = PlayClipAt(Audio);
            sound.volume = 0.1f;//AudioSource.PlayClipAtPoint(Audio, transform.position);
            GetCollided = true;
            sound.panStereo = 0 ;// to check if the object got collided
            StarCollected++;
            scoremanager.StarCollect(StarCollected);//Destroy(gameObject);  // will pick setActive and a pooler 
            scoremanager.addScore(ScoreGive);
            coinMeter.enabled= true;
            
            StartCoroutine("SetObject");//gameObject.SetActive(false);
        }
    }

    public IEnumerator SetObject()
    {
      
        yield return new WaitForSeconds(1.0f);
        gameObject.SetActive(false);
    }
    AudioSource PlayClipAt(AudioClip clip)
    {
        var tempGO = new GameObject("TempAudio");                         // create the temp object
        tempGO.transform.position = Camera.main.transform.position;      // set its position
        var aSource = tempGO.AddComponent<AudioSource>();                    // add an audio source
        aSource.clip = clip;                                            // define the clip

                               // set other aSource properties here, if desired
        aSource.Play();
                                                    // start the sound
        Destroy(tempGO, clip.length);            // destroy object after clip duration
        return aSource;                          // return the AudioSource reference
    }


}
