using UnityEngine;
using System.Collections;
public class Timer : MonoBehaviour
{
    public float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
    }
}
