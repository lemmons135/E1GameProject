using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    bool optionScreneOpen = false;
    [SerializeField] GameObject optionsMenu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoToNextScene()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Luke's Land");
        Debug.Log("ooh im playing!");
    }

    public void OptionScrene()
    {
        if (optionScreneOpen)
        {
            optionsMenu.SetActive(false);
            optionScreneOpen = false;
            Debug.Log("ooh im options open!");
        }
        else
        {
            optionsMenu.SetActive(true);
            optionScreneOpen = true;
            Debug.Log("ooh im options close!");
        }
        
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("ooh im quit!");

    }

}
