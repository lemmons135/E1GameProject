using UnityEngine;

public class LazersShowScript : MonoBehaviour
{
    float timeRemaining = 3f;
    [SerializeField] GameObject lasers;


    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            lasers.SetActive(true);
        }
    }
}
