using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; 

public class ShakyCam : MonoBehaviour
{
    [SerializeField] CinemachineBasicMultiChannelPerlin screenshakeNoise;
    [SerializeField] float timeLimit = 20f;
    [SerializeField] float shakeLowerBound = 0.01f;
    [SerializeField] float shakeUpperBound = 0.5f;

    public Animator transitionAnim;

    private float timer = 0f;
    private bool isDead = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        screenshakeNoise = FindAnyObjectByType<CinemachineBasicMultiChannelPerlin>();
        //StartCoroutine(ShakeScreen(5f,0.1f));
        

        // If amplitude gets to 5f, then go to the game over screen
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float shakeAmount = getShakeAmount();
        screenshakeNoise.AmplitudeGain = shakeAmount;
        Debug.Log("Shake Amount: " + shakeAmount);

        if (shakeAmount == shakeUpperBound)
            startDeath();

        if(isDead)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    IEnumerator ShakeScreen(float screenshakeTime, float amplitude)
    {
        Debug.Log("I am shaking my pants rn");
        screenshakeNoise.AmplitudeGain = amplitude;
        yield return new WaitForSeconds(screenshakeTime);
        Debug.Log("I am no longer quivering no mo'");
        screenshakeNoise.AmplitudeGain = 0f;
    }

    public void setTimer(float time)
    {
        timer = time;
    }

    public void decrementTimer(float decrement)
    {
        timer -= decrement;
    }

    float getShakeAmount()
    {
        float shakeAmount = Mathf.Lerp(shakeLowerBound, shakeUpperBound, timer / timeLimit);
        return shakeAmount;
    }

    void startDeath()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
   
        transitionAnim.SetTrigger("End");
        screenshakeNoise.AmplitudeGain = 3 * shakeUpperBound;

        yield return new WaitForSeconds(1f);

        isDead = true;

    }
}


