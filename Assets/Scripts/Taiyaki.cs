using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Taiyaki : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            playerScript TaiyakiCounter = other.gameObject.GetComponent<playerScript>();
            if(TaiyakiCounter == null)
            {
                return;
            }
            TaiyakiCounter.AddScore(1);
        }
    }
}
