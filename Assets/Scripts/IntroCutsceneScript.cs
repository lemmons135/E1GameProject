using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroCutsceneScript : MonoBehaviour
{
    float currentCutsceneTimer = 0;
    float cutsceneDuration = 5f;
    public void GoToNextScene()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Level 1");
        Debug.Log("ooh im playing!");
    }

    void FixedUpdate()
    {
        if (currentCutsceneTimer <= cutsceneDuration)
        {
            // increment the dash timer
            currentCutsceneTimer += Time.deltaTime;

        }
        else
        {
            GoToNextScene();
        }
    }
}
