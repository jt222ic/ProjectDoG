using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class OptionMenu : MonoBehaviour {

    // Use this for initialization

    public Scrollbar volumeSlider;
    public AudioSource source1;

        public void VolumeValueChange()
    {

        AudioListener.volume = volumeSlider.value;
    }
    public void ExitButton()
    {

        gameObject.SetActive(false);
    }
    public void MuteSound()
    {
        if(AudioListener.volume == 0)
            {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
        }
    }
}
