using UnityEngine;
using System.Collections;
using TMPro;
using System;
public class Timer : MonoBehaviour
{
    public float timer = 0f;
    [SerializeField] TextMeshProUGUI timerText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        //timer = (float)(Math.Truncate(timer*100)/100);
        timerText.text = timer.ToString("F2");
    }
}
