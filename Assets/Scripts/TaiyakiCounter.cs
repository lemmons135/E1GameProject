using UnityEngine;
using System.Collections;
using TMPro;
public class TaiyakiCounter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] TextMeshProUGUI taiyakiText;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject playerObj = GameObject.Find("Player");
        playerScript counter = playerObj.GetComponent<playerScript>();
        taiyakiText.text = "x " + counter.score;
    }
}
