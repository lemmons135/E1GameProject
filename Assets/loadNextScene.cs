using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class loadNextScene : MonoBehaviour
{
    void OnJump()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex + 1
        );
    }
}
