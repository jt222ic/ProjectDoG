using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Pausemenu : MonoBehaviour {

    public string MainMenu;
    public GameObject PauseScreen;
   public GameObject trail;
    //public GameObject Deathmenu;
    


    public void ResumeGame()
    {
        PauseScreen.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        PauseScreen.gameObject.SetActive(true);
        //Deathmenu.SetActive(false);
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        PauseScreen.gameObject.SetActive(false);
        FindObjectOfType<GameManager>().Reset();
        StartCoroutine("RestartingScarf");
    }

    private IEnumerator RestartingScarf()
    {
        trail.SetActive(false);
        yield return new WaitForSeconds(0.4f);                            // so the scarf wont stretch from the end position when you resetted to the newly placed started position
        trail.SetActive(true);

    }
    public void QuitToMainMenu()
    {

        //SceneManager.LoadScene(MainMenu);
        Time.timeScale = 1;
        StartCoroutine("FADE");
    }

    private IEnumerator FADE()
    {
        FindObjectOfType<GameManager>().Reset();
        float fadings = GameObject.Find("Fading").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadings);
        SceneManager.LoadScene(MainMenu);
        

    }
}
