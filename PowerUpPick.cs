using UnityEngine;
using System.Collections;

public class PowerUpPick : MonoBehaviour
{

    // Use this for initialization
    
    public bool ShieldOn;
    float powerupDuration =8;
    PowerupManager PwUpManager;

    public AudioClip Audio;
    AudioSource Audiio;
    AudioSource sound;
    void Start()
    {
        PwUpManager = FindObjectOfType<PowerupManager>();
        sound = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)           // on collision getting the game object to detect the player TAg then add points depending on ScoreGive   " IMPORTANT TO WRITE EACH word CORRECTly or Unity wont understand  "OnTriggerEnter2D"
    {

        if (other.gameObject.tag == "Player")
        {
            ShieldOn = true;
            sound = PlayClipAt(Audio);
            sound.volume = 0.2f;
            sound.panStereo = 0;
            //Debug.Log("dont bash");
            PwUpManager.ActivatePowerUp(ShieldOn, powerupDuration);
            gameObject.SetActive(false);
        }
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
