using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    // Use this for initialization

   public  string GameLevel;

  public GameObject OptionMenu;
    public GameObject StoreMenu;
    public GameObject InstructionMenu;
    public AudioSource Audio;

    private string ANDROID_RATE_URL = "market://details?id=com.OneArmy.Dog_Dash#details-reviews";

    public void PlayGame()
    {
        //SceneManager.LoadScene(GameLevel);
        StartCoroutine("GameChanging");
    }

    public void OpenOption()
    {
        Audio.Play();
        OptionMenu.SetActive(true);
    }
    public void StoreOption()
    {
        Audio.Play();
        StoreMenu.SetActive(true);
    }
    private IEnumerator GameChanging()
    {
        Audio.Play();
        float fadings = GameObject.Find("_Fading").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadings);
        SceneManager.LoadScene(GameLevel);
    }


    public void RateGame()
    {
        Application.OpenURL(ANDROID_RATE_URL);
    }


    public void InstructionOpen()
    {
        Audio.Play();
        InstructionMenu.SetActive(true);
    }
}

