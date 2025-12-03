using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class ShakyCam : MonoBehaviour
{
    [SerializeField] CinemachineBasicMultiChannelPerlin screenshakeNoise;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        screenshakeNoise = FindAnyObjectByType<CinemachineBasicMultiChannelPerlin>();
        StartCoroutine(ShakeScreen(10f,1f));
        

        // If amplitude gets to 5f, then go to the game over screen
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ShakeScreen(float screenshakeTime, float amplitude){
    Debug.Log("I am shaking my pants rn");
    screenshakeNoise.AmplitudeGain = amplitude;
    yield return new WaitForSeconds(screenshakeTime);
    Debug.Log("I am no longer quivering no mo'");
    screenshakeNoise.AmplitudeGain = 0f;
    }
}


