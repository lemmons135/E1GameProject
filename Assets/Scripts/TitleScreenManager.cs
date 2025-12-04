using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{

    //OPTIONS
    bool optionScreneOpen = false;
    [SerializeField] GameObject optionsMenu;

    public void GoToNextScene()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Intro Cutscene");
        Debug.Log("ooh im playing!");
    }

    public void OptionScrene()
    {
        if (optionScreneOpen)
        {
            optionsMenu.SetActive(false);
            optionScreneOpen = false;
            Debug.Log("ooh im options close!");
        }
        else
        {
            optionsMenu.SetActive(true);
            optionScreneOpen = true;
            Debug.Log("ooh im options open!");
        }
        
    }

    public void Credits()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Credits");
        Debug.Log("ooh im crediting!");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("ooh im quit!");

    }

}
