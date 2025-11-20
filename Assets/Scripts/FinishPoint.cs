using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneController.instance.NextLevel();
        }
    }
}