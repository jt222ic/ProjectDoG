using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Deathmenu : MonoBehaviour {



    public string MainMenu;

    public PlayAds AdsWorkingFFS;

    
    public void RestartGame()
    {
        FindObjectOfType<GameManager>().Reset();               /// if i want to reset the ad
        //SceneManager.LoadScene("GameScene");
    }
    public void QuitToMainMenu()
    {
        StartCoroutine("FadingToMainMenu");
    }
    private IEnumerator FadingToMainMenu()
    {
        float fadings = GameObject.Find("Fading").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadings);
        SceneManager.LoadScene(MainMenu);
        FindObjectOfType<GameManager>().Reset();
    }
}
