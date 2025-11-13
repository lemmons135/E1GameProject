
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndRollScript : MonoBehaviour
{
    [SerializeField] private float textScrollSpeed = 30;
    [SerializeField] private float limitPosition = 730f;
    private bool isStopEndRoll;
    private Coroutine endRollCoroutine;

    void Update()
    {
        if (isStopEndRoll) {
            endRollCoroutine = StartCoroutine(GoToNextScene());
        } else {
            if (transform.position.y <= limitPosition) {
                transform.position = new Vector2(transform.position.x, transform.position.y + textScrollSpeed * Time.deltaTime);
            } else {
                isStopEndRoll = true;
            }
        }
    }

    IEnumerator GoToNextScene() {
        yield return new WaitForSeconds(5f);

        if(Input.GetKeyDown("space")) {
            StopCoroutine(endRollCoroutine);
            SceneManager.LoadScene("EndRollStartScene");
        }

        yield return null;
    }
}
